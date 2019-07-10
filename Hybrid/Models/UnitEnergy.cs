using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class UnitEnergy
    {
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double Value { get; set; }

        public UnitOfMesurement Unit { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double Kcal { get; set; }
        public string DisplayValue 
        {
            get => $"{Value.ToString("0.00")} {Unit.Type}";
        }

        internal UnitEnergy CalculateEnergy(double calculatedCalorie)
        {
            return new UnitEnergy
            {
                Unit = this.Unit,
                Value = calculatedCalorie / this.Kcal * this.Value,
                Kcal = calculatedCalorie
            };
        }

    }
}