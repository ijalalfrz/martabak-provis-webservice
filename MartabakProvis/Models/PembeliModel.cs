using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MartabakProvis.Models
{
    [Table("t_pembeli")]
    public class PembeliModel
    {
        [Key]
        public int id_pembeli { get; set; }
        public string nama_pembeli { get; set; }
        public string telepon_pembeli { get; set; }


    }
}
