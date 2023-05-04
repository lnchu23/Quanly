using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDienThoai.Models;
using QuanLyDienThoai.DAL;

namespace QuanLyDienThoai.Controllers
{
    public class HomeController : Controller
    {
        

        Product_DAL ob = new Product_DAL();

        public ActionResult Index(int? brandID)
        {
            if (brandID != null)
            {
                return View(ob.Get_Product_ByBrand(brandID));
            }
            else
            {
                return View(ob.Get_Product());
            }
        }



    }
}