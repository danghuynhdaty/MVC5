using Model.DAO;
using Model.EF;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        //Post
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)//kiểm tra xem có lỗi nào xảy ra khi validate form không
            {
                //thực hiện đăng nhập
                int result = AccountDAO.Instance.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));

                switch (result)
                {
                    case 0:
                        ModelState.AddModelError("", "Tài khoản không tồn tại!");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Mật khẩu không chính xác!");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Tài khoản đã bị khóa!");
                        break;
                    default: // đăng nhập thành công
                        // lấy ra account đã đăng nhập thành công
                        Account account = AccountDAO.Instance.GetAccountByUserName(model.UserName);


                        // gán dữ liệu cho biến lưu vào session
                        UserLogin userLogin = new UserLogin(account.ID, account.UserName,model.RememberMe);
                        //lưu dữ liệu vào session
                        Session.Add(CommontConstant.USER_SESSION, userLogin);


                        //redirect về home
                        return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }
    }
}