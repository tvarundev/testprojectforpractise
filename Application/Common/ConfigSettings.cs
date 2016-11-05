using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Application.Common
{
    public static class ConfigSettings
    {
        static string serviceString = ConfigurationManager.AppSettings["ServiceBaseAddress"];
        static string experienceYearsToShow = ConfigurationManager.AppSettings["ExperienceYearsToShow"];
        static string allowMaximumExperienceDetailToInsert = ConfigurationManager.AppSettings["AllowMaximumExperienceDetailToInsert"];
        static string defaultDropDownText = ConfigurationManager.AppSettings["DefaultDropDownText"];
        static string defaultDropDownLoadingText = ConfigurationManager.AppSettings["defaultDropdownLoadingText"];


        public static string WebApiBaseAddress { get { return serviceString; } }

        public static string ExperienceYearsToShow { get { return experienceYearsToShow; } }

        public static string AllowMaximumExperienceDetailToInsert { get { return allowMaximumExperienceDetailToInsert; } }
        public static string DefaultDropDownText { get { return defaultDropDownText; } }
        public static string DefaultDropDownLoadingText { get { return defaultDropDownLoadingText; } }
    }
}