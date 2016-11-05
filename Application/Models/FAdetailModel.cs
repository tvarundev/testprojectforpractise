using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using BusinessEntities.PageUIValues;
using System.Web.Mvc;
namespace Application.Models
{
    public class FAdetailModel
    {
        public FAdetailEntities faDetailEntities{get;set;}
        public FAdetailPageUIvalues faDetailPageUIvalues { get; set; }
        public bool isInDetailMode = false;
        public ActionTypeEnum ActionType { get; set; }
    }
}