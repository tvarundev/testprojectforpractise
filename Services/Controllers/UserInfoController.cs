using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.EntityClasses;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using Services.Common;
using Enums = BusinessEntities.Enums;

namespace Services.Controllers
{
    [RoutePrefix("api/UserInfo")]
    public class UserInfoController : ApiController
    {
        IUserInformationOperation userInformatinOperations = new UserInformationOperation();
        // GET: api/UserInformationEntity
        public IEnumerable<UserInformationEntity> Get()
        {
            try
            {
                IEnumerable<UserInformation> userInfoList = userInformatinOperations.GetUserInformationList();
                List<UserInformationEntity> userInfoEntityList = MapEntities.MapIEnumerableCollection<UserInformation, UserInformationEntity>(userInfoList).ToList();

                userInfoEntityList.ForEach(x =>
                {
                    x.UserID = userInfoList.Select(y => y).Where(z => z.UserID == x.UserID).First().UserTypeID;
                    x.UserName = userInfoList.Select(y => y).Where(z => z.UserName == x.UserName).First().UserName;
                    x.UserTypeID = userInfoList.Select(y => y).Where(z => z.UserTypeID == x.UserTypeID).First().UserTypeID;
                    //x.UserType.TypeName= userInfoList.Select(y => y).Where(z => z.UserTypeID == x.UserTypeID).First().UserType.TypeName;
                    x.Password = userInfoList.Select(y => y).Where(z => z.Password == x.Password).First().Password;
                    x.MobileNumber = userInfoList.Select(y => y).Where(z => z.MobileNumber == x.MobileNumber).First().MobileNumber;
                });

                return userInfoEntityList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        // GET: api/UserInformationEntity/5
        public UserInformationEntity Get(int userID)
        {
            try
            {
                UserInformation userInfo = userInformatinOperations.GetUserInformationByID(userID);
                UserInformationEntity userInfoEntity = MapEntities.Map<UserInformation, UserInformationEntity>(userInfo);

                userInfoEntity.UserID = userInfo.UserID;
                userInfoEntity.UserName = userInfo.UserName;
                userInfoEntity.UserTypeID = userInfo.UserTypeID;
                //userInfoEntity.UserType.TypeName = userInfo.UserType.TypeName;
                userInfoEntity.Password = userInfo.Password;
                userInfoEntity.MobileNumber = userInfo.MobileNumber;

                return userInfoEntity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("RetriveUserInfo")]
        public UserInformationEntity PostUserInfo(UserInformationEntity userInfoInsert)
        {
            try
            {
                UserInformation userInfo = userInformatinOperations.GetUserInformationuserNameAndPassword(userInfoInsert.UserName, userInfoInsert.Password);

                if (userInfo != null)
                {
                    UserInformationEntity userInfoEntity = MapEntities.Map<UserInformation, UserInformationEntity>(userInfo);

                    userInfoEntity.UserID = userInfo.UserID;
                    userInfoEntity.UserName = userInfo.UserName;
                    userInfoEntity.UserTypeID = userInfo.UserTypeID;
                    //userInfoEntity.UserType.TypeName = userInfo.UserType.TypeName;
                    userInfoEntity.Password = userInfo.Password;
                    userInfoEntity.MobileNumber = userInfo.MobileNumber;

                    return userInfoEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: api/UserInformationEntity
        [Route("CreateAdminUser")]
        public UserInformationEntity Post(UserInformationEntity userInfoInsert)
        {
            try
            {
                UserInformationEntity inserteduserInfo = new UserInformationEntity();
                UserInformation userInfoToInsert = MapEntities.Map<UserInformationEntity, UserInformation>(userInfoInsert);
                UserInformation existingUserInfo = new UserInformation();
                existingUserInfo = userInformatinOperations.CheckUserInformationExistByUserName(userInfoToInsert.UserName);
                if (existingUserInfo != null && existingUserInfo.UserID > 0)
                {
                    inserteduserInfo = MapEntities.Map<UserInformation, UserInformationEntity>(existingUserInfo);
                    inserteduserInfo.ErrorMessage = "User Already Exists";
                }
                else
                {
                    userInfoToInsert = userInformatinOperations.InsertUserInformation(userInfoToInsert);
                    inserteduserInfo = MapEntities.Map<UserInformation, UserInformationEntity>(userInfoToInsert);
                }

                return inserteduserInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT: api/FarmerDetail/5
        public UserInformationEntity Put(UserInformationEntity userInfoUpdated)
        {
            try
            {
                UserInformation userInfoToUpdate = MapEntities.Map<UserInformationEntity, UserInformation>(userInfoUpdated);
                userInfoToUpdate = userInformatinOperations.UpdateUserInformation(userInfoToUpdate);
                return MapEntities.Map<UserInformation, UserInformationEntity>(userInfoToUpdate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/UserInformationEntity/5
        public int Delete(int userID)
        {
            try
            {
                return userInformatinOperations.DeleteUserInformation(userID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}