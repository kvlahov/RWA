using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class UnitEnergy
    {
        public UnitOfMesurement Unit { get; set; }
        public float Kcal { get; set; }
        public float Value { get; set; }
    }
}