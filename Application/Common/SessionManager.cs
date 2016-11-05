using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using BusinessEntities.Enums;

public static class SessionManager
{
    #region Const
    const string _userType = "UserType";
    const string _userName = "UserName";
    #endregion

    #region Property
    public static int UserTypeID
    {
        get
        {
            int intuserType = 0;
            if (HttpContext.Current.Session[_userType] != null && HttpContext.Current.Session[_userType].ToString().Trim().Length > 0)
            {
                Int32.TryParse(HttpContext.Current.Session[_userType].ToString(), out intuserType);
            }
            return UserTypeID = intuserType;
        }
        set
        {
            HttpContext.Current.Session[_userType] = value.ToString().Trim();
        }
    }

    public static string UserName
    {
        get
        {
            String strUserName = string.Empty; ;
            if (HttpContext.Current.Session[_userName] != null && HttpContext.Current.Session[_userName].ToString().Trim().Length > 0)
            {
                strUserName = HttpContext.Current.Session[_userName].ToString();
            }
            return UserName = strUserName;
        }
        set
        {
            HttpContext.Current.Session[_userName] = value.ToString().Trim();
        }
    }
    public static int UserId
    {
        get
        {
            int userId = 0;
            if (HttpContext.Current.Session[Convert.ToString(SessionKeyTypeEnum.currentUserId)] != null && HttpContext.Current.Session[Convert.ToString(SessionKeyTypeEnum.currentUserId)].ToString().Trim().Length > 0)
            {
                userId =Convert.ToInt32( HttpContext.Current.Session[Convert.ToString(SessionKeyTypeEnum.currentUserId)].ToString());
            }
            return UserId = userId;
        }
        set
        {
            HttpContext.Current.Session[Convert.ToString(SessionKeyTypeEnum.currentUserId)] = value.ToString().Trim();
        }
    }
    #endregion
}
