using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class UnitEnergy
    {
        public UnitOfMesurement Unit { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double Kcal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double Value { get; set; }

        internal void UpdateEnergyValues(double calculatedCalorie)
        {
            Value = calculatedCalorie / Kcal * Value;
            Kcal = calculatedCalorie;
        }
    }
}