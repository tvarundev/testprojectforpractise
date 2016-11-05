using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class FAapprovalEntities
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FAid { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<int> FAApprovedId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int PocketId { get; set; }
        public string RecommandedBYSM { get; set; }
    }
}
