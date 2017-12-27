using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using OnlineShop.Common;
using Model.ViewModels.Account;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index(int? page, string searchString, string currentFilter, string sortOrder)

        {
            // lấy sort order đẩy xuống view
            ViewBag.CurrentSort = sortOrder;

            //kiểm tra sort xem có trùng với trường hợp nào không?
            // đẩy xuồng view thông qa viewbag
            ViewBag.IDSortPara = string.IsNullOrEmpty(sortOrder) ? "ID_Desc" : "";
            ViewBag.UserNameSortPara = sortOrder == "UserName" ? "UserName_Desc" : "UserName";
            ViewBag.NameSortPara = sortOrder == "Name" ? "Name_Desc" : "Name";
            ViewBag.EmailSortPara = sortOrder == "Email" ? "Email_Desc" : "Email";
            ViewBag.StatusSortPara = sortOrder == "Status" ? "Status_Desc" : "Status";

            // nếu searchString == null thì gán bằng currentfilter khi chuyển trang k bị mất searchString
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            // lấy ra page từ url, nếu không tồn tại mặc định là 1
            int pageNumber = page ?? 1;
            //pageSize của mỗi page
            int pageSize = 5;
            IEnumerable<Account> model = AccountDAO.Instance.GetAllAccountPaged(pageNumber, pageSize, searchString, sortOrder);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Status,Phone,Password,Email,Name,Address")]Account account)
        {
            if (ModelState.IsValid)
            {
                //mã hóa mật khẩu thành md5
                account.PassWord = Encryptor.MD5Hash(account.PassWord);
                account.CreatedDate = DateTime.Now;
                long id = AccountDAO.Instance.Insert(account);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản thất bại!");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Account account = AccountDAO.Instance.GetAccountByID(id);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status")] AccountEditByAdmin account)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommontConstant.USER_SESSION];
                account.ModifiedBy = session.UserID;
                AccountDAO.Instance.Update(account);
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Không chỉnh sửa được thông tin tài khoản");
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            AccountDAO.Instance.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            AccountDAO.Instance.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Account model = AccountDAO.Instance.GetAccountByID(id);
            return View(model);
        }

    }
}