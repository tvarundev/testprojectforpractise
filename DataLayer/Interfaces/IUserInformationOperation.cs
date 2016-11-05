using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;

namespace DataLayer.Interfaces
{
    public interface IUserInformationOperation
    {
        UserInformation GetUserInformationByID(int userID);
        IEnumerable<UserInformation> GetUserInformationList();
        UserInformation InsertUserInformation(UserInformation userInformationEntity);
        UserInformation UpdateUserInformation(UserInformation userInformationEntity);
        int DeleteUserInformation(int userID);
        UserInformation GetUserInformationuserNameAndPassword(string UserName, string Password);
        UserInformation CheckUserInformationExistByUserName(string UserName);
    }
}
