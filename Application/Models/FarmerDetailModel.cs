using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using Application.Common;
using System.Web.Mvc;
namespace Application.Models
{
    public class FarmerDetailModel
    {
        public FarmerDetailEntities farmerDetail { get; set; }
        public List<SelectListItem> crops { get; set; }
        public IEnumerable<SelectListItem> farmerTypes { get; set; }
        public List<SelectListItem> DealerList { get; set; }
        public List<SelectListItem> irrigationSourceList { get; set; }
        public List<SelectListItem> pocketList { get; set; }
        public IEnumerable<SelectListItem> countryCodes { get; set; }

        public bool isInDetailMode = false;
        public ActionTypeEnum Action { get; set; }
    }
}