using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Common
{
    public class ServiceExceptions : Exception
    {
        public ServiceExceptions(string message)
            : base(message)
        {

        }
    }
}