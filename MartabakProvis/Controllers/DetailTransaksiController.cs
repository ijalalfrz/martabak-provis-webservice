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
    [Route("api/DetailTransaksi"),Authorize]
    public class DetailTransaksiController : Controller
    {
        DetailTransaksiRepo repo = new DetailTransaksiRepo();
        // GET: api/DetailTransaksi
        [HttpGet(Name = "GetAllDetail")]
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

        // GET: api/DetailTransaksi/5
        [HttpGet("{id}", Name = "GetDetailById")]
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

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("detail/{id}", Name = "GetByIdTransaksi")]
        public IActionResult GetByIdTransaksi(int id)
        {
            var data = repo.GetByIdTransaksi(id);
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

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("detail/{id}", Name = "GetByIdMenu")]
        public IActionResult GetByIdMenu(int id)
        {
            var data = repo.GetByIdMenu(id);
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
