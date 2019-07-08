using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public DateTime ForDay { get; set; }
        public User User { get; set; }
        public IList<Meal> Meals { get; set; }        
    }
}