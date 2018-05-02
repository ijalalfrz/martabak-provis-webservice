using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MartabakProvis.Models
{
    [Table("t_toko")]
    public class TokoModel
    {
        [Key]
        public int id_toko { get; set; }
        public string nama_toko { get; set; }
        public string telepon_toko { get; set; }
        public string alamat_toko { get; set; }

    }

    public class TokoViewModel
    {
        public TokoModel toko { get; set; }
        public UserModel user { get; set; }
    }
}
