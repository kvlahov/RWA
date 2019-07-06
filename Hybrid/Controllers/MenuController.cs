﻿using Hybrid.Models.DAL;
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
    public class MenuController : Controller
    {
        private IRepository repo = RepoFactory.GetRepository();
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.userName = repo.GetUser(User.Identity.GetUserId()).Name;
            return View();
        }

        public ActionResult Generate()
        {
            return View(repo.GetMealNames(3).ToList());
        }

        [HttpGet]
        ActionResult SetupUser()
        {
            ViewBag.activity = repo.GetLvlsOfActivity();
            return View();
        }

        [HttpPost]
        ActionResult SetupUser(User user)
        {
            user.EntityID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                repo.InsertUser(user);
                return RedirectToAction("Index", "Menu");
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