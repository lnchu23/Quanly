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
    public class Brand_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoString"].ToString();
        public List<Brand> Get_Brand()
        {
            List<Brand> Brand_list = new List<Brand>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select id_brand,name_brand,images_brand from  Brands  ";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Brand_list.Add(new Brand
                    {
                        id_brand = Convert.ToInt32(dr[0].ToString()),
                        name_brand = dr[1].ToString(),
                        images_brand = dr[2].ToString(),
                        



                    });
                }
            }
            return Brand_list;
        }
        public List<Brand> Get_Brand_ByMa(int id)
        {
            List<Brand> Brand_list = new List<Brand>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select id_brand,name_brand,images_brand from Brands where id_brand='" + id + "' ";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Brand_list.Add(new Brand
                    {
                        id_brand = Convert.ToInt32(dr[0].ToString()),
                        name_brand = dr[1].ToString(),
                        images_brand = dr[2].ToString(),
                        

                    });
                }
            }
            return Brand_list;
        }

        internal object Get_Brand_ByMa(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        //Them ,sua , xoa

        public void Insert_Brand(Brand ob)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string sql = "Insert into Brands(name_brand,images_brand) values(N'" + ob.name_brand + "','" + ob.images_brand  + "')";
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
        public void Update_Brand(Brand ob)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(conString))
                {
                    string sql = "Update Brands set name_brand='" + ob.name_brand + "',images_brand='" + ob.images_brand + "' where id_brand='" + ob.id_brand + "'";
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
        public void Delete_Brand(int id)
        {
            try
            {
                using (SqlConnection connection = new
                    SqlConnection(conString))
                {

                    string sql = "Delete from Brands where id_brand='" + id + "'";
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