using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities.EntityClasses;
using BusinessEntities.Enums;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
namespace Services.Common
{
    public static class ExceptionLoging
    {
        public static void LogException(Exception exception)
        {
            IProjectExceptionOperations projectExceptionOperation = new ProjectExceptionOperations();
            ProjectException generatedException = new ProjectException();
            generatedException.CreatedDate = DateTime.Now;
            generatedException.Message = exception.Message;
            generatedException.ProjectType = Convert.ToString(ProjectTypeEnum.ServiceLayer);
            generatedException.StackTrace = exception.StackTrace;
            projectExceptionOperation.LogException(generatedException);
        }
        public static void LogExceptionFromApplication(ProjectExceptionEntities exception)
        {
            IProjectExceptionOperations projectExceptionOperation = new ProjectExceptionOperations();
            ProjectException generatedException = new ProjectException();
            generatedException.CreatedDate = DateTime.Now;
            generatedException.Message = exception.Message;
            generatedException.ProjectType = Convert.ToString(ProjectTypeEnum.ServiceLayer);
            generatedException.StackTrace = exception.StackTrace;
            projectExceptionOperation.LogException(generatedException);
        }
    }
}