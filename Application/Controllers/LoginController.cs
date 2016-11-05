using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Application.Models;
using BusinessEntities.EntityClasses;
using Application.Common;
using Enums = BusinessEntities.Enums;
using Newtonsoft.Json;

namespace Application.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                ServiceInputObject serviceObject = new ServiceInputObject
                {
                    baseURL = ConfigSettings.WebApiBaseAddress,
                    controllerName = "UserInfo",
                    methodName = "RetriveUserInfo"
                };

                UserInformationEntity userInfo = new UserInformationEntity();
                userInfo.UserName = model.UserName;
                userInfo.Password = model.Password;

                userInfo = ServiceMethods.GeneratePostRequest<UserInformationEntity>(userInfo, serviceObject);
                if (userInfo != null)
                {
                    SessionManager.UserTypeID = userInfo.UserTypeID; ;
                    SessionManager.UserName = userInfo.UserName;
                    SessionManager.UserId = userInfo.UserID;
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
    }
}