using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
namespace Application.Common
{
    public static class ExceptionLoging
    {
        public static void LogException(Exception exception)
        {
            ServiceInputObject inputObject = new ServiceInputObject
            {
                baseURL = ConfigSettings.WebApiBaseAddress,
                controllerName = "ProjectException",
                methodName = "PostException"
            };

            ProjectExceptionEntities generatedException = new ProjectExceptionEntities();
            generatedException.CreatedDate = DateTime.Now;
            generatedException.Message = exception.Message;
            generatedException.ProjectType = Convert.ToString(ProjectTypeEnum.ServiceLayer);
            generatedException.StackTrace = exception.StackTrace;
            ServiceMethods.GeneratePostRequestWithIntDestinationEntity<ProjectExceptionEntities>(generatedException, inputObject);
        }
    }
}