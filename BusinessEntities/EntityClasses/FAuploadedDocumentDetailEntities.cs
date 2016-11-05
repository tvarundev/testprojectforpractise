using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FAuploadedDocumentDetailEntities
    {
        public int Id { get; set; }
        public int FAid { get; set; }
        public int DocumentId { get; set; }
        public string UploadPath { get; set; }
        public bool IsActive { get; set; }
    }
}
