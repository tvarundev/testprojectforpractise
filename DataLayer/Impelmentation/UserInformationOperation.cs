using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;

namespace DataLayer.Impelmentation
{
    public class UserInformationOperation : IUserInformationOperation
    {
        DBentities db = new DBentities();

        public UserInformationOperation()
        {
            if (!db.Database.Exists())
            {
                db.Database.Create();
            }
        }

        public UserInformation GetUserInformationByID(int userID)
        {
            try
            {
                return db.UserInformations.FirstOrDefault(x => x.UserID == userID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public UserInformation CheckUserInformationExistByUserName(string UserName)
        {
            try
            {
                return db.UserInformations.FirstOrDefault(x => x.UserName == UserName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserInformation GetUserInformationuserNameAndPassword(string UserName, string Password)
        {
            try
            {
                return db.UserInformations.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<UserInformation> GetUserInformationList()
        {
            try
            {
                return db.UserInformations.Select(x => x);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserInformation InsertUserInformation(UserInformation userInformationEntity)
        {
            try
            {
                db.UserInformations.Add(userInformationEntity);
                SaveChanges();
                return userInformationEntity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserInformation UpdateUserInformation(UserInformation userInformationEntity)
        {
            try
            {
                UserInformation userInfoExisting = GetUserInformationByID(userInformationEntity.UserID);
                userInfoExisting.UserName = userInformationEntity.UserName;
                userInfoExisting.Password = userInformationEntity.Password;
                userInfoExisting.MobileNumber = userInformationEntity.MobileNumber;
                userInfoExisting.UserTypeID = userInformationEntity.UserTypeID;

                db.Entry(userInfoExisting).State = System.Data.Entity.EntityState.Modified;
                SaveChanges();
                return userInfoExisting;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteUserInformation(int userID)
        {
            try
            {
                UserInformation existingUserInfo = GetUserInformationByID(userID);
                if (existingUserInfo != null)
                {
                    db.Entry(existingUserInfo).State = System.Data.Entity.EntityState.Deleted;
                    return SaveChanges();
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
