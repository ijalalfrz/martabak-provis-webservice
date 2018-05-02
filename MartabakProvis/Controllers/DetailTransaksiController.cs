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
        public IActionResult GetAllDetail()
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET: api/DetailTransaksi/5
        [HttpGet("{id}", Name = "GetDetailById")]
        public IActionResult GetDetailById(int id)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("transaksi/{id}", Name = "GetDetailByIdTransaksi")]
        public IActionResult GetDetailByIdTransaksi(int id)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET: api/DetailTransaksi/detail/1
        [HttpGet("menu/{id}", Name = "GetDetailByIdMenu")]
        public IActionResult GetDetailByIdMenu(int id)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
