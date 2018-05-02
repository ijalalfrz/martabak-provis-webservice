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
        public int jumlah { get; set; }
        public decimal harga_sekarang { get; set; }
        public decimal total_harga { get; set; }
        public int id_transaksi { get; set; }
        public int id_menu { get; set; }
        public int id_size { get; set; }
        [Computed]
        public string topping { get; set; }
        [Computed]
        public string size { get; set; }
    }
}
