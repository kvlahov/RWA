using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class User
    {
        public int Id { get; set; }
        public string EntityID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Weight { get; set; }
        public char Sex { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOFBirth { get; set; }
        [Display(Name = "Level Of Activity")]
        public int LevelOfActivityID { get; set; }
        [Display(Name = "Diabetes Type")]
        public int DiabetesType { get; set; }

    }
}