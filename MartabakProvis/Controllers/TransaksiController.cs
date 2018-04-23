using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;
using MartabakProvis.Models;

namespace MartabakProvis.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaksi")]
    public class TransaksiController : Controller
    {
        TransaksiRepo repo = new TransaksiRepo();
        // GET: api/Transaksi
        [HttpGet(Name = "GetAllTransaksi")]
        public IEnumerable<TransaksiModel> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        // GET: api/Transaksi/5
        [HttpGet("{id}", Name = "GetById")]
        public IEnumerable<TransaksiModel> GetById(int id)
        {
            var data = repo.GetById(id);
            yield return data;
        }

        // GET: api/Transaksi/pembeli/1
        [HttpGet("pembeli/{id}", Name = "GetByIdPembeli")]
        public IEnumerable<TransaksiModel> GetByIdPembeli(int id)
        {
            var data = repo.GetByIdPembeli(id);
            return data;
        }

        // GET: api/Transaksi/tanggal/1
        [HttpGet("tanggal/{tanggal}", Name = "GetByTanggal")]
        public IEnumerable<TransaksiModel> GetByTanggal(string tanggal)
        {
            var data = repo.GetByTanggal(tanggal);
            return data;
        }

        // POST: api/Transaksi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Transaksi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
