using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDienThoai.Models;
using QuanLyDienThoai.DAL;

namespace QuanLyDienThoai.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            List<product_detail> ShoppingCart = Session["Shopping"] as List<product_detail>;
            return View(ShoppingCart);
        }

        public RedirectToRouteResult AddToCart(int id)
        {
            if (Session["Shopping"] == null)
            //Neu gio hang chua dc khoi tao
            {
                Session["Shopping"] = new List<product_detail>();
                //Khoi tao session ["Khoi tao"]
            }

            List<product_detail> ShoppingCart = Session["Shopping"] as List<product_detail>;//gan qua bien gio hang (de code)
            //Kiem tra xem san pham khach chon da co trong gio hang chua

            if (ShoppingCart.FirstOrDefault(m => m.id_product == id) == null)
            //khong co trong gio hang
            {
                Product_Detail_DAL db = new Product_Detail_DAL();
                product_detail products = db.findproducts(id);//Tim san pham theo ID
                product_detail newItem = new product_detail()
                {
                    id_product = products.id_product,
                    name_product = products.name_product,
                    quantity = 1,
                    images = products.images,
                    description = products.description,
                    price = products.price
                }; //Tao ra 1 cartItem moi

                ShoppingCart.Add(newItem);// Them CartItem vao gio
            }
            else
            {
                //Neu san pham khach chon da co trong gio hang thi khong them vao gio hangnua
                product_detail cartItem = ShoppingCart.FirstOrDefault(m => m.id_product == id);
                cartItem.quantity++;
            }

            // Action nay se chuyen huong ve trang
            return RedirectToAction("Index", "Shopping", "Views");


        }
        public ActionResult CapNhapGioHang(int id, FormCollection f)
        {
            //Tim cartItem muon sua
            List<product_detail> ShoppingCart = Session["Shopping"] as List<product_detail>;
            product_detail EditAmount = ShoppingCart.FirstOrDefault(m => m.id_product == id);
            if (EditAmount != null)
            {
                EditAmount.quantity = int.Parse(f["txtsoluong"].ToString());

            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult RemoveItem(int id)
        {

            List<product_detail> ShoppingCart = Session["Shopping"] as List<product_detail>;
            product_detail DelItem = ShoppingCart.FirstOrDefault(m => m.id_product == id);
            if (DelItem != null)
            {
                ShoppingCart.Remove(DelItem);
            }
            return RedirectToAction("Index");
        }
    }
}