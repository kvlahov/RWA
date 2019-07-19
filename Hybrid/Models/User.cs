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

        public string FullName {
            get {
                return Name + " " + Surname;
            }
        }

        public double GetCalorieIntake()
        {
            double fDType, fSex, fActivity;

            fSex = Sex == 'M' ? 5 : -161;
            fDType = DiabetesType == 1 ? 0.99 : 0.98;

            switch (LevelOfActivityID)
            {
                case 1:
                    fActivity = 1.2;
                    break;
                case 2:
                    fActivity = 1.375;
                    break;
                case 3:
                    fActivity = 1.5;
                    break;
                default:
                    fActivity = 1.2;
                    break;
            }

            int age = DateTime.Now.Year - DateOFBirth.Year;
            if (DateOFBirth > DateTime.Now.AddYears(-age)) age--;

            return (10*Weight + 6.25*Height - 5*age + fSex) * fDType * fActivity;

        }
    }
}