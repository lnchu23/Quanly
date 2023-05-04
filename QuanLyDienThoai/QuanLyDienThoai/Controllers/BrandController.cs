using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDienThoai.Models;
using QuanLyDienThoai.DAL;

namespace QuanLyDienThoai.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        Brand_DAL ob = new Brand_DAL();
        public ActionResult Index()
        {
            var Brand_list = ob.Get_Brand();
            return View(Brand_list);
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(Brand ob1)
        {
            if (ModelState.IsValid)
            {
                ob.Insert_Brand(ob1);

            }
            return RedirectToAction("Index");
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            var Brands = ob.Get_Brand_ByMa(id).FirstOrDefault();
            return View(Brands);
        }

        // POST: Brand/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult Edit(Brand ob1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ob.Update_Brand(ob1);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            var brand = ob.Get_Brand_ByMa(id).FirstOrDefault();

            return View(brand);

        }

        // POST: Brand/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult Delete_Brand(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ob.Delete_Brand(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
