using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Application.Models
{
    public class PocketModel
    {
        [Required]
        public int subDistrictId { get; set; }
        [Required]
        public int villageId { get; set; }
        [Required]
        public bool isInDetailMode { get; set; }
        public PocketInfoEntities pocketInfo { get; set; }
        public string pocketStatusName { get; set; }

        public ActionTypeEnum ActionType { get; set; }
    }
}