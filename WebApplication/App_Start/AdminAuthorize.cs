using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Models;

namespace WebApplication.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public int maChucNang { set; get; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            NhanVien nvSession = (NhanVien)HttpContext.Current.Session["user"];
            {
                if (nvSession != null)
                {
                    #region 2. Check quyền
                    WebApplicationEntities db = new WebApplicationEntities();
                    var user = db.PhanQuyens.Count(model => model.MaNhanVien == nvSession.MaNhanVien & model.MaChucNang == maChucNang);
                    if(user != 0)
                    {
                        return;
                    }
                    else
                    {
                        var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                            filterContext.Result = new RedirectToRouteResult(new
                                RouteValueDictionary (new 
                                {
                                    controller = "Erro",
                                    aciton = "NoRight",
                                    area = "Admin", 
                                    returnUrl = returnUrl.ToString()
                                }));
                    }
                    #endregion
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary (new 
                        {
                            controller = "HomeAdmin",
                            aciton = "Login",
                            area = "Admin", 
                            returnUrl = returnUrl.ToString()
                        }));
                }
            }
        }
    }
}