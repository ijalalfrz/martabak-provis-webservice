using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Models
{
    [Table("t_menu_2")]
    public class MenuModel
    {
 
        [Key]
        public int id_menu { get; set; }
        public string topping { get; set; }
        public string kategori_menu { get; set; }
        public string gambar { get; set; }
        public string deskripsi { get; set; }

       
    }

    public class MenuViewModel
    {

        [Key]
        public int id_menu { get; set; }
        public string topping { get; set; }
        public string kategori_menu { get; set; }
        public IFormFile gambar { get; set; }
        public string deskripsi { get; set; }


    }
}
