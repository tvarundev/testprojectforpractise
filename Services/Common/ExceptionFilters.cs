using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
namespace Services.Common
{
    public class ExceptionFilters : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            try
            {
                ExceptionLoging.LogException(context.Exception);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}