using Model.EF;
using OnlineShopModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        #region Index Action
        // GET: Admin/Content
        public ActionResult Index(int? page, string searchString, string currentFilter, string sortOrder)
        {

            //lưu currentsort khi chuyển trang
            ViewBag.CurrentSort = sortOrder;

            //Kiểm tra thuộc tính sort

            if (sortOrder == null)
            {
                ViewBag.IDSortPara = "ID_Desc";
                ViewBag.UserNameSortPara = "UserName_Desc";
                ViewBag.StatusSortPara = "Status_Desc";
                ViewBag.NameSortPara = "Name_Desc";
                ViewBag.DescriptionSortPara = "Description_Desc";
            }
            else
            {
                ViewBag.IDSortPara = string.IsNullOrEmpty(sortOrder) ? "ID_Desc" : "";
                ViewBag.UserNameSortPara = sortOrder == "UserName" ? "UserName_Desc" : "UserName";
                ViewBag.StatusSortPara = sortOrder == "Status" ? "Status_Desc" : "Status";
                ViewBag.NameSortPara = sortOrder == "Name" ? "Name_Desc" : "Name";
                ViewBag.DescriptionSortPara = sortOrder == "Description" ? "Description_Desc" : "Description";
            }


            

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            int pageNumber = page ?? 1;
            int pageSize = 10;
            var model = ContentDAO.Instance.GetAllContentPaged(pageNumber, pageSize, searchString, sortOrder);
            return View(model);
        }


        #endregion

        #region Create Action

        [HttpGet]
        public ActionResult Create()
        {
            //set CategoryID cho bài viết bằng dropdowlist thông qua viewbag
            SetViewBag();

            return View();
        }

        [HttpPost, ValidateInput(false)] //ValidateInput(false)  loại bỏ việc kiểm tra html
        public ActionResult Create(Content content)
        {
            //kiểm tra xem trạng thái của model có sẵn hay không
            if (ModelState.IsValid)
            {
                //thêm bài viết vào db
                content.CreatedDate = DateTime.Now;
                content.ModifiedDate = DateTime.Now;

                content.CreatedBy = Common.CommontConstant.USER_SESSION;
                content.ModifiedBy = Common.CommontConstant.USER_SESSION;
                int id = ContentDAO.Instance.Insert(content);
                //nếu thêm thành công thì redirect về index của contentcontroller
                if (id > 0)
                {
                    SetModalBox("Thêm bài viết thành công", "success");
                    return RedirectToAction("Index");

                }
                //thất bại thì thêm  errormessage
                else
                {
                    ModelState.AddModelError("", "Thêm bài viết thất bại!");
                }
            }
            SetViewBag();
            return View();
        }


        #endregion

        #region Edit Action

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //lấy ra content cần sửa từ db thông qa dao
            Content model = ContentDAO.Instance.GetByID(id);
            //set categoryid cho view thông qua SetViewBag
            SetViewBag(model.CategoryID);

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedBy = Common.CommontConstant.USER_SESSION;
                ContentDAO.Instance.Update(model);
                //tạo thông báo cho người dùng
                SetModalBox("Chỉnh sửa bài viết thành công!", "success");
                return RedirectToAction("Index", "Content");
            }
            else
            {
                ModelState.AddModelError("", "Không chỉnh sửa được bài viết");
            }

            //set categoryid cho bài viết nếu edit thất bại
            SetViewBag(model.CategoryID);
            return View();
        }

        #endregion

        #region Delete Action

        public ActionResult Delete(int ID)
        {
            ContentDAO.Instance.Delete(ID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Detail Region

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = ContentDAO.Instance.GetByID(id);
            return View(model);
        }

        #endregion

        #region Change status Action

        public JsonResult ChangeStatus(int id)
        {
            var result = ContentDAO.Instance.ChangeStatus(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Methods


        /// <summary>
        /// set data for viewbag tranfer to view
        /// </summary>
        public void SetViewBag(int? selectedID = null)
        {
            var listCategory = NewsCategoryDAO.Instance.GetListCategory();
            ViewBag.CategoryID = new SelectList(listCategory, "ID", "Name", selectedID);
        }

        #endregion





    }
}