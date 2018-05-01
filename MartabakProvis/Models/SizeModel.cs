using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MartabakProvis.Models
{
    [Table("t_size")]
    public class SizeModel
    {

        [Key]
        public int id_size { get; set; }
        public int id_menu { get; set; }
        public string size { get; set; }
        public decimal harga { get; set; }

        
    }
}
