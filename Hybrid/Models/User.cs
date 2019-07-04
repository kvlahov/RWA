using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class User
    {
        public int Id { get; set; }
        public int EntityID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public char Sex { get; set; }
        public DateTime DateOFBirth { get; set; }
        public int LevelOfActivityID { get; set; }
        public int DiabetesType { get; set; }

    }
}