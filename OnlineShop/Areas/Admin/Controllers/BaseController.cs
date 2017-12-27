using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // kiểm tra xem có tồn tại session hay không
            var session = (UserLogin)Session[CommontConstant.USER_SESSION];
            //nếu không tồn tại thì redirect về trang login 
            // UserLogin có 1 biến RememberMe nếu true thì lúc log out không xóa session nếu false thì lúc logout xóa sạch USER_SESSION
            if (session==null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Login" , Action = "Index" , Area = "Admin"  }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}