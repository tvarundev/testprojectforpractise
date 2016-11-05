using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data.SqlClient;
using BusinessEntities.EntityClasses;

namespace Application.Controllers
{
    public class BaseController : Controller
    {
        public UserInformationEntity LoggedonUser { get; private set; }
        public BaseController()
        {
            
        }

        /// <summary>
        /// On Action Executing
        /// </summary>
        /// <param name="context"></param>
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (SessionManager.UserName == "")
            {
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.HttpContext.Response.End();
                }
                else
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            { "Controller", "Login" },
                            { "Action", "Login" }
                        }
                    );
                }
                return;
            }
                        
            bool loggedOnUserSet = SetLoggedOnUser(context);
            if (!loggedOnUserSet)
            {
                return;
            }          

        }
        private bool SetLoggedOnUser(ActionExecutingContext context)
        {
            int userTypeID = SessionManager.UserTypeID;

            if (userTypeID == 0 || SessionManager.UserName == string.Empty)
            {
                context.Result = new RedirectResult("/OceanAgro/Login/Logout");
                return false;
            }

            LoggedonUser = new UserInformationEntity();
            if (string.IsNullOrWhiteSpace(SessionManager.UserName) == false)
            {
                LoggedonUser.UserTypeID = SessionManager.UserTypeID;
                LoggedonUser.UserName = SessionManager.UserName;
            }
            return true;
        }
    }
}