using Hybrid.Models;
using Hybrid.Models.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hybrid.Controllers
{
    public class MenuController : Controller
    {
        private readonly IRepository repo = RepoFactory.GetRepository();
        public ActionResult Generate()
        {
            var user = repo.GetUser(User.Identity.GetUserId());
            var dates = repo.GetDatesForMenus(user.Id).Where(date => date.Date >= DateTime.Today).ToList();

            DateTime startDate = DateTime.Today;
            if (dates != null || dates.Contains(DateTime.Today))
            {
                while (dates.Contains(startDate))
                {
                    startDate = startDate.AddDays(1);
                }
            }

            ViewBag.dates = dates;
            var menu = new MenuViewModel()
            {
                ForDay = startDate
            };
            return View(menu);
        }

        [HttpPost]
        public ActionResult GenerateMeals(MenuViewModel model, int noOfMeals)
        {
            var user = repo.GetUser(User.Identity.GetUserId());
            var userCalories = user.GetCalorieIntake();
            var nutrients = repo.GetNutrientsPerMeal(noOfMeals);

            MenuViewModel menu = null;

            if (model.Meals.Count == noOfMeals)
            {
                ModelState.Clear();
                var checkedMeals = model.Meals.Where(m => m.IsChecked).Select(m => m.MealNameId).ToList();

                foreach (var meal in model.Meals)
                {
                    //fill meals and ingredients info
                    var npm = nutrients.Where(n => n.MealId == meal.MealNameId).First();
                    meal.Name = nutrients.Where(n => n.MealId == meal.MealNameId).Select(n => n.MealName).First();
                    meal.Ingredients.ToList().ForEach(ing => 
                    {
                        ing.BindIngredient(repo.GetIngredient(ing.Id));
                        var units = repo.GetUnitsOfMesurement(ing.Id);
                        ing.BaseUnitEnergy = units;

                        var calorieForType = npm.GetCalorieForType(ing.Type, userCalories);
                        ing.FillCalculatedEnergyList(calorieForType);
                    });



                    if (checkedMeals.Contains(meal.MealNameId)) continue;
                    var ingredients = new List<IngredientViewModel>();
                    meal.Ingredients
                        .Where(ing => !ing.IsChecked)
                        .ToList()
                        .ForEach(ing =>
                        {
                            
                            var newIng = GenerateIngredientViewModel(ing.TypeId, npm, userCalories);
                            ing.Id = newIng.Id;
                            ing.Name = newIng.Name;
                            ing.Type = newIng.Type;
                            ing.TypeId = newIng.TypeId;
                            ing.BaseUnitEnergy = newIng.BaseUnitEnergy;
                            ing.CalculatedUnitEnergy = newIng.CalculatedUnitEnergy;
                        });
                }

            }
            else
            {
                //Generate new menu
                menu = new MenuViewModel()
                {
                    User = user
                };

                foreach (var npm in nutrients)
                {
                    Meal meal = new Meal
                    {
                        CaloriePercent = npm.PercentCalorie,
                        Name = npm.MealName,
                        MealNameId = npm.MealId
                    };

                    repo.GetAllIngredientTypes().ToList()
                        .ForEach(entry =>
                        {
                            var ingViewModel = GenerateIngredientViewModel(entry.Value, npm, userCalories);
                            meal.Ingredients.Add(ingViewModel);
                        });

                    menu.Meals.Add(meal);
                }

            }

            ViewBag.userCalories = userCalories;

            var returnMenu = menu ?? model;

            return PartialView("_Menu", returnMenu);
        }

        private IngredientViewModel GenerateIngredientViewModel(int typeId, NutrientsPerMeal npm, double userCalories)
        {
            var ing = repo.GetRandomIngredient(typeId);
            var units = repo.GetUnitsOfMesurement(ing.Id);

            var ingViewModel = new IngredientViewModel();
            ingViewModel.BindIngredient(ing);
            ingViewModel.BaseUnitEnergy = units;

            var calorieForType = npm.GetCalorieForType(ingViewModel.Type, userCalories);

            ingViewModel.FillCalculatedEnergyList(calorieForType);

            return ingViewModel;
        }

        public ActionResult Save(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User = repo.GetUser(User.Identity.GetUserId());
                repo.InsertMenu(model);
            }
            return RedirectToAction("Index", "User");
        }

        public ActionResult History()
        {
            var user = repo.GetUser(User.Identity.GetUserId());
            var dates = repo.GetDatesForMenus(user.Id).Where(date => date.Date <= DateTime.Today).ToList();
            dates.Sort();
            return View(dates);
        }

        public ActionResult ShowMenu(DateTime day)
        {
            DateTime date = day;

            var user = repo.GetUser(User.Identity.GetUserId());
            var menu = repo.GetMenu(date, user.Id);

            ViewBag.userCalories = user.GetCalorieIntake();
            return PartialView("~/Views/Shared/_Menu.cshtml", menu);
        }
    }
}