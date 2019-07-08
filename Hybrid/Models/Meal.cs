using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriePercent { get; set; }
        public IDictionary<Ingredient, List<UnitEnergy>> IngredientEnergy{ get; set; }

    }
}