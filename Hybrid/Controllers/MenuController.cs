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
        private IRepository repo = RepoFactory.GetRepository();
        public ActionResult Generate()
        {
            return View(new MenuViewModel());
        }

        public ActionResult GenerateMeals(int noOfMeals)
        {
            var user = repo.GetUser(User.Identity.GetUserId());
            var userCalories = user.GetCalorieIntake();
            MenuViewModel menu = new MenuViewModel()
            {
                Meals = new List<Meal>(),
                User = user
            };

            foreach (var npm in repo.GetNutrientsPerMeal(noOfMeals))
            {
                Meal meal = new Meal
                {
                    CaloriePercent = npm.PercentCalorie,
                    Name = npm.MealName,
                    MealNameId = npm.MealId,
                    Ingredients = new List<IngredientViewModel>()
                };

                repo.GetAllIngredientTypes().ToList()
                    .ForEach(entry =>
                    {
                        var ing = repo.GetRandomIngredient(entry.Value);
                        var units = repo.GetUnitsOfMesurement(ing.Id);

                        var ingViewModel = new IngredientViewModel();
                        ingViewModel.BindIngredient(ing);
                        ingViewModel.BaseUnitEnergy = units;

                        var calorieForType = npm.GetCalorieForType(ingViewModel.Type, userCalories);

                        ingViewModel.FillCalculatedEnergyList(calorieForType);

                        meal.Ingredients.Add(ingViewModel);
                    });

                menu.Meals.Add(meal);
            }

            ViewBag.userCalories = userCalories;
            return PartialView("_Menu", menu);
        }

        public ActionResult Save(MenuViewModel model)
        {
            if(ModelState.IsValid)
            {
                var m = model;
            }
            return RedirectToAction("Index", "User");
        }
    }
}