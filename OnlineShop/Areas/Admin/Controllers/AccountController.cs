using Model.DAO;
using Model.EF;
using Model.ViewModels.Account;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        #region Index Action

        // GET: Admin/Account
        public ActionResult Index(int? page, string searchString, string currentFilter, string sortOrder)
        {
            // lấy sort order đẩy xuống view
            ViewBag.CurrentSort = sortOrder;

            if (sortOrder == null)
            {
                ViewBag.IDSortPara = "ID_Desc";
                ViewBag.UserNameSortPara = "UserName_Desc";
                ViewBag.NameSortPara = "Name_Desc";
                ViewBag.EmailSortPara = "Email_Desc";
                ViewBag.StatusSortPara = "Status_Desc";
            }
            else
            {
                //kiểm tra sort xem có trùng với trường hợp nào không?
                // đẩy xuồng view thông qa viewbag
                ViewBag.IDSortPara = string.IsNullOrEmpty(sortOrder) ? "ID_Desc" : "";
                ViewBag.UserNameSortPara = sortOrder == "UserName" ? "UserName_Desc" : "UserName";
                ViewBag.NameSortPara = sortOrder == "Name" ? "Name_Desc" : "Name";
                ViewBag.EmailSortPara = sortOrder == "Email" ? "Email_Desc" : "Email";
                ViewBag.StatusSortPara = sortOrder == "Status" ? "Status_Desc" : "Status";
            }

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
            int pageSize = 10;
            IEnumerable<Account> model = AccountDAO.Instance.GetAllAccountPaged(pageNumber, pageSize, searchString, sortOrder);
            return View(model);
        }

        #endregion Index Action

        #region Create Action

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
                var model = AccountDAO.Instance.GetAccountByUserName(account.UserName);
                if (model == null)
                {
                    //mã hóa mật khẩu thành md5
                    account.PassWord = Encryptor.MD5Hash(account.PassWord);
                    account.CreatedDate = DateTime.Now;
                    long id = AccountDAO.Instance.Insert(account);
                    if (id > 0)
                    {
                        SetModalBox("Thêm tài khoản thành công", "success");
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm tài khoản thất bại!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                }
            }
            return View();
        }

        #endregion Create Action

        #region Edit

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

        #endregion Edit

        #region DeleteAction

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

        #endregion DeleteAction

        #region Detail Action

        [HttpGet]
        public ActionResult Details(int id)
        {
            Account model = AccountDAO.Instance.GetAccountByID(id);
            return View(model);
        }

        #endregion Detail Action

        #region ChangeStatus Action

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = AccountDAO.Instance.ChangeStatus(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion ChangeStatus Action
    }
}