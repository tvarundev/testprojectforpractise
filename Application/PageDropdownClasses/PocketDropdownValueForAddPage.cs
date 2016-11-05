using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Application.PageDropdownClasses
{
    public class PocketDropdownValueForAddPage
    {
        public List<SelectListItem> states { get; set; }
        public List<SelectListItem> crops { get; set; }
        public List<SelectListItem> villages { get; set; }
        public List<SelectListItem> fertilizers { get; set; }
        public List<SelectListItem> pocketStatusList { get; set; }
    }
}