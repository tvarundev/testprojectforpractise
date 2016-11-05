using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Common
{
    internal class ServiceInputObject
    {
        public string baseURL { get; set; }
        public string controllerName { get; set; }
        public string methodName { get; set; }
        public string parameterValue { get; set; }
        //public string finalUrlStringForGet { get { return "api/" + controllerName + "/" + parameterValue; } }
        public string finalUrlStringForGet
        {
            get
            {
                if (string.IsNullOrEmpty(methodName))
                {
                    return "api/" + controllerName + "/" + parameterValue;
                }
                else
                {
                    return "api/" + controllerName + "/" + methodName + "/" + parameterValue;
                }
            }
        }

        public string finalUrlStringForPost { 
            get 
            {
                if (string.IsNullOrEmpty(methodName))
                {
                    return "api/" + controllerName + "/";
                }
                else
                {
                    return "api/" + controllerName + "/" + methodName + "/" ;
                }
            } 
        }
        public string finalUrlStringForPut 
        { 
            get 
            {
                if (string.IsNullOrEmpty(methodName))
                {
                    return "api/" + controllerName; 
                }
                else
                {
                    return "api/" + controllerName + "/" + methodName;
                }
            } 
        }
        public string finalUrlStringForDelete 
        { 
            get 
            {
                if (string.IsNullOrEmpty(methodName))
                {
                    return "api/" + controllerName + "/" + parameterValue;
                }
                else
                {
                    return "api/" + controllerName + "/" + methodName + "/" + parameterValue;
                }
            } 
        }

    }
}