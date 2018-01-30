using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryNewsController : Controller
    {
        #region Index Action

        // GET: Admin/CategoryNews
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Details Action

        // GET: Admin/CategoryNews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        #endregion
        
        #region Create Action

        // GET: Admin/CategoryNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryNews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Edit Action

        // GET: Admin/CategoryNews/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CategoryNews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete Action

        // GET: Admin/CategoryNews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CategoryNews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
        #endregion
    }
}
