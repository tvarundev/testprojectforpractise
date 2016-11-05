using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EntityClasses
{
    public class UserInformationEntity
    {
        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ErrorMessage { get; set; }

        //public UserTypeEntity UserType { get; set; }
    }
}
