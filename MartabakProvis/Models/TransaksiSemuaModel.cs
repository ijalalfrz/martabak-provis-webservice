using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Models;

namespace MartabakProvis.Models
{
    public class TransaksiSemuaModel
    {
        public TransaksiModel transaksi { get; set; }
        public List<DetailTransaksiModel> detail { get; set; }

    }
}
