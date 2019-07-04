using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class IngredientEnergy
    {
        public Ingredient Ingredient { get; set; }
        public UnitOfMesurement Unit { get; set; }
        public float Energy { get; set; }
        public float Value { get; set; }
    }
}