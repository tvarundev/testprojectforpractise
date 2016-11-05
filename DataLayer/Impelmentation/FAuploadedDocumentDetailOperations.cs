using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAuploadedDocumentDetailOperations:IFAuploadedDocumentDetailOperations
    {
        DBentities db = new DBentities();
        public IEnumerable<FAuploadedDocumentDetail> InsertUploadedDocumentDetailIst(IEnumerable<FAuploadedDocumentDetail> uplodedDocumentDetailList)
        {
            try
            {
                db.FAuploadedDocumentDetails.AddRange(uplodedDocumentDetailList);
                db.SaveChanges();
                return uplodedDocumentDetailList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
