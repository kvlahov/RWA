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
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Generate()
        {
            var repo = RepoFactory.GetRepository();
            
            return View(repo.GetMealNames(3).ToList());
        }
    }
}