using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartabakProvis.Models;

namespace MartabakProvis.Models
{
    public class TransaksiSemuaModel
    {
        public TransaksiModel parent { get; set; }
        public List<DetailTransaksiModel> child { get; set; }

    }
}
