using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Models
{
    [Table("t_menu")]
    public class MenuModel
    {
 
        [Key]
        public int id_menu { get; set; }
        public string topping { get; set; }
        public string size_menu { get; set; }
        public string kategori_menu { get; set; }
        public string gambar { get; set; }
        public decimal harga { get; set; }
        public string deskripsi { get; set; }

       
    }
}
