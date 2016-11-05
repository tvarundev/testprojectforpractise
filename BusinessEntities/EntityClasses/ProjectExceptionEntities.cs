using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class ProjectExceptionEntities
    {
        public int Id { get; set; }
        public string ProjectType { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
