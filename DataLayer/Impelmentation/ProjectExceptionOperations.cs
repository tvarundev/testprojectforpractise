using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class ProjectExceptionOperations:IProjectExceptionOperations
    {
        DBentities db = new DBentities();
        public int LogException(ProjectException exception)
        {
            db.ProjectExceptions.Add(exception);
            db.SaveChanges();
            return exception.Id;
        }
    }
}
