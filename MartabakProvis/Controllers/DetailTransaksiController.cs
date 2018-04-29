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
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // GET: api/DetailTransaksi/5
        [HttpGet("{id}", Name = "GetDetailById")]
        public IActionResult GetById(int id)
        {
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("detail/{id}", Name = "GetByIdTransaksi")]
        public IActionResult GetByIdTransaksi(int id)
        {
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("detail/{id}", Name = "GetByIdMenu")]
        public IActionResult GetByIdMenu(int id)
        {
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // POST: api/DetailTransaksi
        [HttpPost]
        public IActionResult Post([FromBody]DetailTransaksiModel value)
        {
            try
            {
                if (repo.Insert(value)){
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch
            {
                return BadRequest();
            }
            
        }
        
        // PUT: api/DetailTransaksi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DetailTransaksiModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_detail_transaksi;
                data = value;
                data.id_detail_transaksi = id_part;

                if (repo.Update(value))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch
            {
                return BadRequest();
            }
            
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = repo.GetById(id);
                
                if (repo.Delete(data)){
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
