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
    [Route("api/DetailTransaksi")]
    public class DetailTransaksiController : Controller
    {
        DetailTransaksiRepo repo = new DetailTransaksiRepo();
        // GET: api/DetailTransaksi
        [HttpGet(Name = "GetAllDetail")]
        public IEnumerable<DetailTransaksiModel> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        // GET: api/DetailTransaksi/5
        [HttpGet("{id}", Name = "GetDetailById")]
        public IEnumerable<DetailTransaksiModel> GetById(int id)
        {
            var data = repo.GetById(id);
            yield return data;
        }

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("detail/{id}", Name = "GetByIdTransaksi")]
        public IEnumerable<DetailTransaksiModel> GetByIdTransaksi(int id)
        {
            var data = repo.GetByIdTransaksi(id);
            return data;
        }

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("detail/{id}", Name = "GetByIdMenu")]
        public IEnumerable<DetailTransaksiModel> GetByIdMenu(int id)
        {
            var data = repo.GetByIdMenu(id);
            return data;
        }

        // POST: api/DetailTransaksi
        [HttpPost]
        public void Post([FromBody]DetailTransaksiModel value)
        {
            repo.Insert(value);
        }
        
        // PUT: api/DetailTransaksi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]DetailTransaksiModel value)
        {
            var data = repo.GetById(id);
            var id_part = data.id_detail_transaksi;
            data = value;
            data.id_detail_transaksi = id_part;
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
