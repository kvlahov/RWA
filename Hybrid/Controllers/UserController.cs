using Hybrid.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Hybrid.Models;
using Hybrid.Filters;
using System.Diagnostics;

namespace Hybrid.Controllers
{
    [SetupRedirectFilter]
    public class UserController : Controller
    {
        private readonly IRepository repo = RepoFactory.GetRepository();
        // GET: Menu
        public ActionResult Index()
        {
            var user = repo.GetUser(User.Identity.GetUserId());
            var dates = repo.GetDatesForMenus(user.Id).Where(date => date.Date >= DateTime.Today).ToList();

            ViewBag.userName = user.Name;
            return View(dates);
        }

        public ActionResult ActiveMenu(DateTime? day)
        {
            DateTime date = day ?? DateTime.Now;

            var user = repo.GetUser(User.Identity.GetUserId());
            var menu = repo.GetMenu(date, user.Id);

            ViewBag.userCalories = user.GetCalorieIntake();
            return PartialView("~/Views/Menu/_Menu.cshtml", menu);
        }

        [HttpGet]
        public ActionResult SetupUser()
        {
            //if user types direct url redirect
            if (repo.isUserSetup(User.Identity.GetUserId()))
            {
                return RedirectToAction("Index");
            }
            ViewBag.activity = repo.GetLvlsOfActivity();
            return View();
        }

        [HttpPost]
        public ActionResult SetupUser(User user)
        {
            user.EntityID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                repo.InsertUser(user);
                return RedirectToAction("Index");
            }
            ViewBag.activity = repo.GetLvlsOfActivity();
            return View();

        }

        public ActionResult UserInfo()
        {
            var user = repo.GetUser(User.Identity.GetUserId());
            ViewBag.activity = repo.GetLvlsOfActivity().Where(x => x.Id == user.LevelOfActivityID).First();
            return View(user);
        }
    }
}