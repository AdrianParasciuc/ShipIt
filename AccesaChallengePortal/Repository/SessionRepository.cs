using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesaChallengePortal.DatabaseLink;

namespace AccesaChallengePortal.Repository
{
    public class SessionRepository
    {
        public static User CurrentUser
        {
            get
            {
                if (HttpContext.Current != null)
                    return (User)HttpContext.Current.Session["CurrentUser"];
                return null;
            }
            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }
    }
}