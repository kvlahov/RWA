using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hybrid.Controllers
{
    public class SettingsController : Controller
    {
        private readonly static IRepository repo = RepoFactory.GetRepository();

        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillAccordion()
        {   
            return PartialView("_IngredientAccordion", repo.GetAllIngredients());
        }
    }
}