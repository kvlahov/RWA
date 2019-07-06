using Hybrid.Models.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hybrid.Filters
{
    public class SetupRedirectFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var repo = RepoFactory.GetRepository();
            var uid = filterContext.HttpContext.User.Identity.GetUserId();
            Log(filterContext.ActionDescriptor.ActionName, repo.isUserSetup(uid), uid);
            base.OnActionExecuting(filterContext);
        }

        private void Log(string actionName, bool isSetup, string uid)
        {
            var message = $"Action: {actionName} IsSetup: {isSetup}, uid: {uid}";
            Debug.WriteLine(message);
        }
    }
}