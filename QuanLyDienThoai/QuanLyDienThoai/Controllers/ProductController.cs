using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDienThoai.DAL;
using QuanLyDienThoai.Models;

namespace QuanLyDienThoai.Controllers
{
    public class ProductController : Controller
    {
        Product_DAL ob = new Product_DAL();
        // GET: Product
        public ActionResult Index()
        {
            var Product_list = ob.Get_Product();
            return View(Product_list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product ob1)
        {
            if (ModelState.IsValid)
            {
                ob.Insert_products(ob1);

            }
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Products = ob.Get_Product_ByMa(id).FirstOrDefault();
            return View(Products);
        }

        // POST: Product/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult Edit(product ob1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ob.Update_products(ob1);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var Product1 = ob.Get_Product_ByMa(id).FirstOrDefault();

            return View(Product1);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_Product(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ob.Delete_products(id);
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
