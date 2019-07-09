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
        IRepository repo = RepoFactory.GetRepository();
        public ActionResult Generate()
        {
            return View(repo.GetMealNames(3).ToList());
        }

        public ActionResult GenerateMeals(int noOfMeals)
        {
            MenuViewModel menu = new MenuViewModel()
            {
                Meals = new List<Meal>()
            };

            var userCalories = repo.GetUser(User.Identity.GetUserId()).GetCalorieIntake();
            foreach (var npm in repo.GetNutrientsPerMeal(noOfMeals))
            {
                Meal meal = new Meal
                {
                    CaloriePercent = npm.PercentCalorie,
                    Name = npm.MealName
                };

                var ingUnits = new Dictionary<Ingredient, IList<UnitEnergy>>();

                repo.GetAllIngredientTypes().ToList()
                    .ForEach(entry =>
                    {
                        var ing = repo.GetRandomIngredient(entry.Value);
                        //var ing = repo.GetIngredient(1);
                        var units = repo.GetUnitsOfMesurement(ing.Id);
                        units
                        .ToList()
                        .ForEach(u => u.UpdateEnergyValues(npm.GetCalorieForType(entry.Key, userCalories)));
                        ingUnits.Add(ing, units);
                    });
                meal.IngredientEnergy = ingUnits;

                menu.Meals.Add(meal);
            }

            ViewBag.types = repo.GetAllIngredientTypes();
            ViewBag.userCalories = userCalories;
            return PartialView("_Meals", menu);
        }
    }
}