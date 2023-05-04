using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using QuanLyDienThoai.Models;

namespace QuanLyDienThoai.DAL
{
    public class Product_Detail_DAL
    {
        public List<product_detail> products;

        Product_DAL ob = new Product_DAL();

        public Product_Detail_DAL() { }
        public List<product_detail> findAll()
        {
            return this.products;
        }
        public product_detail findproducts(int id_product)
        {
            var list = ob.Get_Product_ByMa(id_product).FirstOrDefault();
            this.products = new List<product_detail>()
            {
                new product_detail
                {
                    id_product = list.id_product,
                    name_product = list.name_product,
                    price = list.price,
                    images = list.images

                }
            };
            return this.products.FirstOrDefault();

        }
    }
}