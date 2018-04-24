using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Models
{
    [Table("t_detail_transaksi")]
    public class DetailTransaksiModel
    {
        [Key]
        public int id_detail_transaksi { get; set; }
        public int xid_menu { get; set; }
        public int jumlah { get; set; }
        public decimal harga { get; set; }
        public int xid_transaksi { get; set; }

    }
}
