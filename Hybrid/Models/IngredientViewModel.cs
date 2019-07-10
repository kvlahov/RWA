using Hybrid.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public IngredientType Type { get; set; }
        public bool IsChecked { get; set; }
        public IList<UnitEnergy> BaseUnitEnergy { get; set; }
        public IList<UnitEnergy> CalculatedUnitEnergy { get; set; }

        public void FillCalculatedEnergyList(double targetCalories)
        {
            CalculatedUnitEnergy = new List<UnitEnergy>();
            BaseUnitEnergy.ToList().ForEach(unit => CalculatedUnitEnergy.Add(unit.CalculateEnergy(targetCalories)));
        }

        public void BindIngredient(Ingredient ing)
        {
            Id = ing.Id;
            Name = ing.Name;
            TypeId = ing.TypeId;
            Type = ing.GetIngredientType();
            CalculatedUnitEnergy = new List<UnitEnergy>();
            BaseUnitEnergy = new List<UnitEnergy>();
        }

        public IngredientViewModel()
        {
            CalculatedUnitEnergy = new List<UnitEnergy>();
            BaseUnitEnergy = new List<UnitEnergy>();
        }
    }
}