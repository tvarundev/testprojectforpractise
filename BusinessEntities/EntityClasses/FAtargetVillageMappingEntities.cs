using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FAtargetVillageMappingEntities
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public Nullable<int> CropId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> TotalMonths { get; set; }
        public Nullable<int> NoOfSamples { get; set; }
        public Nullable<int> NoOfDemos { get; set; }
        public Nullable<int> NoOffarmerMeetings { get; set; }
        public Nullable<int> NoOfPrescriptions { get; set; }
    
    
    }
}
