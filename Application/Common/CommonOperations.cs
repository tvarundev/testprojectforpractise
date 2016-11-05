using BusinessEntities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities.Enums;
using System.Web.Mvc;
using System.Globalization;
using System.Reflection;
namespace Application.Common
{
    public static class CommonOperations
    {
        public static IEnumerable<SelectListItem> GetCountryCodes()
        {
            try
            {

                List<SelectListItem> dropDownTextValueEntities = new List<SelectListItem>();
                SelectListItem listItem;

                listItem = new SelectListItem();
                listItem.Value = "+91";
                listItem.Text = "+91";
                listItem.Selected = true;
                dropDownTextValueEntities.Add(listItem);

                listItem = new SelectListItem();
                listItem.Value = "001";
                listItem.Text = "001";
                dropDownTextValueEntities.Add(listItem);

                return dropDownTextValueEntities;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<SelectListItem> GetDropdownValueForExperience()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Yes";
            itemToAdd.Value = "true";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "No";
            itemToAdd.Value = "false";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }
        public static List<SelectListItem> GetDropdownValueForAllMonths()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            string[] monthNameList = DateTimeFormatInfo.CurrentInfo.MonthNames;
            int monthCount = 1;
            foreach (string month in monthNameList)
            {
                if (!string.IsNullOrEmpty(month))
                {
                    itemToAdd = new SelectListItem();
                    itemToAdd.Text = month;
                    itemToAdd.Value = Convert.ToString(monthCount);
                    DropdownItemList.Add(itemToAdd);
                    monthCount++;
                }
            }
            return DropdownItemList;
        }

        public static List<SelectListItem> GetDropdownValueForExperienceYears()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            int CurrentYear = DateTime.Now.Year;
            int FirstYear = CurrentYear - Convert.ToInt16(ConfigSettings.ExperienceYearsToShow);

            for (int yearCount = FirstYear; yearCount <= CurrentYear; yearCount++)
            {
                itemToAdd = new SelectListItem();
                itemToAdd.Text = Convert.ToString(yearCount);
                itemToAdd.Value = Convert.ToString(yearCount);
                if (yearCount == CurrentYear)
                {
                    itemToAdd.Selected = true;
                }
                DropdownItemList.Add(itemToAdd);
            }

            return DropdownItemList;
        }

        public static List<SelectListItem> GetDropdownValueForStateList(List<StateInfoEntities> stateList)
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            foreach (var state in stateList)
            {
                itemToAdd = new SelectListItem();
                itemToAdd.Text = state.StateName;
                itemToAdd.Value = Convert.ToString(state.StateID);
                DropdownItemList.Add(itemToAdd);
            }
            return DropdownItemList;
        }
        public static List<SelectListItem> GetDropdownValueForApprovedByList(List<FAapprovedByEntities> approvedByList)
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            foreach (var approvedBy in approvedByList)
            {
                itemToAdd = new SelectListItem();
                itemToAdd.Text = approvedBy.ApprovedBy;
                itemToAdd.Value = Convert.ToString(approvedBy.Id);
                DropdownItemList.Add(itemToAdd);
            }
            return DropdownItemList;
        }

        public static List<SelectListItem> BindDropdwon<TSource>(List<TSource> sourceEntity, string propertyForValue, string propertyForText) where TSource : class
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;
            if (sourceEntity != null)
            {
                Type type = typeof(TSource);
                PropertyInfo textProperty = type.GetProperty(propertyForText);
                PropertyInfo valueProperty = type.GetProperty(propertyForValue);

                foreach (var dropDownItem in sourceEntity)
                {
                    itemToAdd = new SelectListItem();

                    itemToAdd.Text = (string)textProperty.GetValue(dropDownItem, null);
                    itemToAdd.Value = valueProperty.GetType() == typeof(string) ? (string)valueProperty.GetValue(dropDownItem, null) : Convert.ToString((int)valueProperty.GetValue(dropDownItem, null));
                    DropdownItemList.Add(itemToAdd);
                }
            }
            return DropdownItemList;
        }





        public static List<SelectListItem> GetFarmerConsumption()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Fertilizer";
            itemToAdd.Value = "1";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "DAP";
            itemToAdd.Value = "2";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Urea";
            itemToAdd.Value = "3";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Potash";
            itemToAdd.Value = "4";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }

        public static List<SelectListItem> GetInputSource()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Pesticides";
            itemToAdd.Value = "1";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Fertilizer";
            itemToAdd.Value = "2";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Seeds";
            itemToAdd.Value = "3";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }

        public static List<SelectListItem> GetLandType()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Rainfed";
            itemToAdd.Value = "1";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Irrigated";
            itemToAdd.Value = "2";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Partially Irrigated";
            itemToAdd.Value = "3";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }

        public static List<SelectListItem> GetOwnershipType()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Owned";
            itemToAdd.Value = "1";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Leased";
            itemToAdd.Value = "2";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Others";
            itemToAdd.Value = "3";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }

        public static List<SelectListItem> GetPesticideType()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "insecticides";
            itemToAdd.Value = "1";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "fungicides";
            itemToAdd.Value = "2";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "weedicides";
            itemToAdd.Value = "3";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }

        public static List<SelectListItem> GetPesticideUnits()
        {
            List<SelectListItem> DropdownItemList = new List<SelectListItem>();
            SelectListItem itemToAdd;

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Liter";
            itemToAdd.Value = "1";
            itemToAdd.Selected = true;
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "KG";
            itemToAdd.Value = "2";
            DropdownItemList.Add(itemToAdd);

            itemToAdd = new SelectListItem();
            itemToAdd.Text = "Bag";
            itemToAdd.Value = "3";
            DropdownItemList.Add(itemToAdd);


            return DropdownItemList;
        }
    }
}