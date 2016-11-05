using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class LiteratureFormController : BaseController
    {
        // GET: LiteratureForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LiteratureForm()
        {
            return View();
        }
    }
}