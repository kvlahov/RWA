using Hybrid.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class NutrientsPerMeal
    {
        public double PercentCarbs { get; set; }
        public double PercentFat { get; set; }
        public double PercentProtein { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public int OfMeals { get; set; }
        public double PercentCalorie { get; set; }

        internal double GetCalorieForType(IngredientType type, double calories)
        {
            var caloriePerMeal = PercentCalorie / 100 * calories;
            switch (type)
            {
                case IngredientType.Carbs:
                    return PercentCarbs / 100 * caloriePerMeal;
                case IngredientType.Protein:
                    return PercentProtein / 100 * caloriePerMeal;
                case IngredientType.Fat:
                    return PercentFat / 100 * caloriePerMeal;
                default:
                    return 0;
            } 
            
            
        }
    }
}