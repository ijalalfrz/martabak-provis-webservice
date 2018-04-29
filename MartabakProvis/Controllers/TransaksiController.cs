using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;
using MartabakProvis.Models;
using Microsoft.AspNetCore.Authorization;

namespace MartabakProvis.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaksi"),Authorize]
    public class TransaksiController : Controller
    {
        TransaksiRepo repo = new TransaksiRepo();
        // GET: api/Transaksi
        [HttpGet(Name = "GetAllTransaksi")]
        public IActionResult GetAll()
        {
            var data = repo.GetAll();
            IActionResult response;

            if (data != null)
            {
                response = Ok(data);
            }
            else
            {
                response = NotFound();
            }

            return response;
        }

        // GET: api/Transaksi/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var data = repo.GetById(id);
            IActionResult response;

            if (data != null)
            {
                response = Ok(data);
            }
            else
            {
                response = NotFound();
            }

            return response;
        }

        // GET: api/Transaksi/pembeli/1
        [HttpGet("pembeli/{id}", Name = "GetByIdPembeli")]
        public IActionResult GetByIdPembeli(int id)
        {
            var data = repo.GetByIdPembeli(id);
            IActionResult response;

            if (data != null)
            {
                response = Ok(data);
            }
            else
            {
                response = NotFound();
            }

            return response;
        }

        // GET: api/Transaksi/tanggal/1
        [HttpGet("tanggal/{tanggal}", Name = "GetByTanggal")]
        public IActionResult GetByTanggal(string tanggal)
        {
            var data = repo.GetByTanggal(tanggal);
            IActionResult response;

            if (data != null)
            {
                response = Ok(data);
            }
            else
            {
                response = NotFound();
            }

            return response;
        }

        // POST: api/Transaksi
        [HttpPost(Name = "InsertTransaksi")]
        public void Post([FromBody]TransaksiModel value)
        {
            repo.Insert(value);
        }
        
        // PUT: api/Transaksi/5
        [HttpPut("{id}", Name = "UpdateTransaksi")]
        public void Put(int id, [FromBody]TransaksiModel value)
        {
            var data = repo.GetById(id);
            var id_part = data.id_transaksi;
            data = value;
            data.id_transaksi = id_part;
            repo.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = repo.GetById(id);
            repo.Delete(data);
        }
    }
}
