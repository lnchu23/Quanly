using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuanLyDienThoai.Models
{
    public class product_detail
    {
        [Key]
        public int id_product { get; set; }
        [Required]
        [DisplayName("Tên sản phẩm")]
        public string name_product { get; set; }
        [Required]
        [DisplayName("Hình ảnh ")]
        public string images { get; set; }
        [Required]
        [DisplayName("Mô tả")]
        public string description { get; set; }
        [Required]
        [DisplayName("Giá")]
        public float price { get; set; }
        [Required]
        [DisplayName("Số lượng")]
        public int quantity { get; set; }
        [Required]
        [DisplayName("Brand ID")]
        public int brandID { get; set; }
        [DisplayName("Thành tiền")]

        public float Thanhtien
        {
            get
            {
                return quantity * price;
            }
        }
    }
}