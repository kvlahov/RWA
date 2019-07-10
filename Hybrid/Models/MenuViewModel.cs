using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ForDay { get; set; } = DateTime.Now;
        public User User { get; set; }
        public IList<Meal> Meals { get; set; }

        public MenuViewModel()
        {
            Meals = new List<Meal>();
        }
    }
}