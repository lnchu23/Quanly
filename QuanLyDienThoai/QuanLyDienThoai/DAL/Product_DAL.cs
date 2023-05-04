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
    public class Product_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoString"].ToString();
        public List<product> Get_Product()
        {
            List<product> Product_list = new List<product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select id_product,name_product,images,description,price,quantity,brandID from products, Brands where Brands.id_brand=products.brandID  ";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Product_list.Add(new product
                    {
                        id_product = Convert.ToInt32(dr[0].ToString()),
                        name_product = dr[1].ToString(),
                        images = dr[2].ToString(),
                        description = dr[3].ToString(),
                        price = float.Parse(dr[4].ToString()),
                        quantity = Convert.ToInt32(dr[5].ToString()),
                        brandID =Convert.ToInt32(dr[6].ToString()),

                        

                    });
                }
            }
            return Product_list;
        }
        public List<product> Get_Product_ByMa(int ? id)
        {
            List<product> Product_list = new List<product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select id_product,name_product,images,description,price,quantity,brandID from products ,Brands where Brands.id_brand=products.brandID and   id_product='" + id + "' ";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Product_list.Add(new product
                    {
                        id_product = Convert.ToInt32(dr[0].ToString()),
                        name_product = dr[1].ToString(),
                        images = dr[2].ToString(),
                        description = dr[3].ToString(),
                        price = float.Parse(dr[4].ToString()),
                        quantity = Convert.ToInt32(dr[5].ToString()),
                        brandID = Convert.ToInt32(dr[6].ToString()),

                    });
                }
            }
            return Product_list;
        }
        public List<product> Get_Product_ByBrand(int? id)
        {
            List<product> Product_list = new List<product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select id_product,name_product,images,description,price,quantity,brandID from products ,Brands where Brands.id_brand=products.brandID and   products.brandID='" + id + "' ";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Product_list.Add(new product
                    {
                        id_product = Convert.ToInt32(dr[0].ToString()),
                        name_product = dr[1].ToString(),
                        images = dr[2].ToString(),
                        description = dr[3].ToString(),
                        price = float.Parse(dr[4].ToString()),
                        quantity = Convert.ToInt32(dr[5].ToString()),
                        brandID = Convert.ToInt32(dr[6].ToString()),

                    });
                }
            }
            return Product_list;
        }

        internal object Get_Product_ByMa(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        //Them ,sua , xoa

        public void Insert_products(product ob)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string sql = "Insert into products(name_product,images,description,price,quantity,brandID)  values(N'" + ob.name_product + "','" + ob.images + "',N'" + ob.description + "','" + ob.price + "','" + ob.quantity + "','" + ob.brandID + "')";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {

            }
        }
        public void Update_products(product ob)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(conString))
                {
                    string sql = "Update products set name_product=N'" + ob.name_product + "',images='" + ob.images + "',description=N'" + ob.description + "',price='" + ob.price + "',quantity='" + ob.quantity + "',brandID='" + ob.brandID + "' where id_product='" + ob.id_product + "'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                
            }
        }
        public void Delete_products(int id)
        {
            try
            {
                using (SqlConnection connection = new
                    SqlConnection(conString))
                {

                    string sql = "Delete from products where id_product='" + id + "'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}