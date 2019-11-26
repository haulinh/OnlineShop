using AutoConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineShop.Common
{
    public class HaveCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized)
            //{
            //    return false;

            //}
        
            var session = (UserLogin)HttpContext.Current.Session[CommonConstants.USER_SESSTION];

            if (session==null)
            {
                return false;
            }
            List<string> privilegeLevels = this.GotCredentialByUserLogging(session.UserName);
            if (privilegeLevels.Contains(this.RoleID)|| session.GroupID==Define.ADMIN_GROUP)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        private List<string> GotCredentialByUserLogging(string userName)
        {
            var credential = (List<string>)HttpContext.Current.Session[CommonConstants.USER_CREDENTIAL];
            return credential;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }
    }
}