using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybrid.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime forDay { get; set; }
        public int UserId { get; set; }
        //public IEnumerable<Meal> MyProperty { get; set; }
    }
}