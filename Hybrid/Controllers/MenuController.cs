using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hybrid.Controllers
{
    public class MenuController : Controller
    {
        IRepository repo = RepoFactory.GetRepository();
        public ActionResult Generate()
        {
            return View(repo.GetMealNames(3).ToList());
        }

        public ActionResult GenerateMeals(int noOfMeals)
        {
            return PartialView("_Meals", menu);
        }
    }
}