using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Enums;
using BusinessEntities.EntityClasses;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using Services.Common;
namespace Services.Controllers
{
    [RoutePrefix("api/ProjectException")]
    public class ProjectExceptionController : ApiController
    {
        public int PostException(ProjectExceptionEntities generatedException)
        {
            IProjectExceptionOperations exceptionOperations = new ProjectExceptionOperations();

            ProjectException exceptionToInsert = MapEntities.Map<ProjectExceptionEntities, ProjectException>(generatedException);
            exceptionOperations.LogException(exceptionToInsert);
            return exceptionToInsert.Id;
        }
    }
}
