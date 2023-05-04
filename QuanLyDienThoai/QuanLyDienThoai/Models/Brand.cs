using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace QuanLyDienThoai.Models
{
    public class Brand
    {
        [Key]
        public int id_brand { get; set; }
        [Required]
        [DisplayName("Tên nhà sản xuất")]
        public string name_brand { get; set; }
        [Required]
        [DisplayName("Hình ảnh")]
        public string images_brand { get; set; }
       
    
       
        
    }
}