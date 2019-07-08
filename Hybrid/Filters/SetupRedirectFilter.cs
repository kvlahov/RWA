using Hybrid.Models.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hybrid.Filters
{
    public class SetupRedirectFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var repo = RepoFactory.GetRepository();
            var user = filterContext.HttpContext.User;
            if (filterContext.ActionDescriptor.ActionName != "SetupUser")
            {
                if(user.IsInRole("User"))
                {
                    if(!repo.isUserSetup(user.Identity.GetUserId()))
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary
                            {
                                {"controller", "User" },
                                {"action", "SetupUser" }
                            });
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private void Log(string actionName, bool isSetup, string uid)
        {
            var message = $"Action: {actionName} IsSetup: {isSetup}, uid: {uid}";
            Debug.WriteLine(message);
        }
    }
}