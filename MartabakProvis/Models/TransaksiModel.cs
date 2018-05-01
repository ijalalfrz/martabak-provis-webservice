using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Models
{
    [Table("t_transaksi")]
    public class TransaksiModel
    {
        [Key]
        public int id_transaksi { get; set; }
        public DateTime tanggal { get; set; }
        public int jumlah_beli { get; set; }
        public decimal total_harga { get; set; }
        public int? id_toko { get; set; }
        public string nama_pembeli { get; set; }
        public string status { get; set; }

    }
}
