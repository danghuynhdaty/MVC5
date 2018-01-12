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
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }

        #region Create Action
        [HttpGet]
        public ActionResult Create()
        {
            //set CategoryID cho bài viết bằng dropdowlist thông qua viewbag
            SetViewBag();

            return View();
        }

        [HttpPost,ValidateInput(false)] //ValidateInput(false)  loại bỏ việc kiểm tra html
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
                long id = ContentDAO.Instance.Insert(content);
                //nếu thêm thành công thì redirect về index của contentcontroller
                if (id > 0)
                {
                    return View("Index");

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
        public ActionResult Edit(long id)
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
                return RedirectToAction("Index","Content");
            }
            else
            {
                ModelState.AddModelError("","Không chỉnh sửa được bài viết");
            }

            //set categoryid cho bài viết nếu edit thất bại
            SetViewBag(model.CategoryID);
            return View();
        }

        #endregion

        #region Methods


        /// <summary>
        /// set data for viewbag tranfer to view
        /// </summary>
        public void SetViewBag(long? selectedID = null)
        {
            var listCategory = NewsCategoryDAO.Instance.GetListCategory();
            ViewBag.CategoryID = new SelectList(listCategory, "ID", "Name", selectedID);
        }

        #endregion

    }
}