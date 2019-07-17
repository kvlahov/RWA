using Hybrid.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hybrid.Models.Extensions;
namespace Hybrid.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type {
            get {
                return GetIngredientType().GetDisplayName();
            }
        }

        public IngredientType GetIngredientType()
        {
            switch (TypeId)
            {
                case 1:
                    return IngredientType.Carbs;
                case 2:
                    return IngredientType.Protein;
                case 3:
                    return IngredientType.Fat;
                default:
                    return IngredientType.Other;
            }
        }
    }
}