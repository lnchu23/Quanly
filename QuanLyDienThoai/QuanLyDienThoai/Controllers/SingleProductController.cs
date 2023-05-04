using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDienThoai.Models;
using QuanLyDienThoai.DAL;

namespace QuanLyDienThoai.Controllers
{
    public class SingleProductController : Controller
    {
        // GET: SingleProduct
        Product_DAL ob = new Product_DAL();
        public ActionResult SingleProduct(int id)
        {
            var chitiet = ob.Get_Product_ByMa(id).FirstOrDefault();
            return View(chitiet);
        }
    }
}