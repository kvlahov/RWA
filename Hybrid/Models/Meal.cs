using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class Meal
    {
        //public int Id { get; set; }
        public int MealNameId { get; set; }
        public string Name { get; set; }
        public double CaloriePercent { get; set; }
        public IList<IngredientViewModel> Ingredients { get; set; }

    }
}