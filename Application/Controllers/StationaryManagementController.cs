using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class StationaryManagementController : BaseController
    {
        // GET: StationaryManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StationaryManagement()
        {
            return View();
        }
    }
}