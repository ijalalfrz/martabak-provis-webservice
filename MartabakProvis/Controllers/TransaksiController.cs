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
        [HttpGet(Name = "GetAllWithDetail")]
        public IActionResult GetAllWithDetail()
        {
            try
            {
                var data = repo.GetAllWithDetail();
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

        // GET: api/Transaksi
        [HttpGet("date/{limit?}", Name = "GetAllWithDetailDate")]
        public IActionResult GetAllWithDetailDate(int? limit)
        {
            try
            {
                var data = repo.GetAllWithDetailDate(limit);
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

        // GET: api/Transaksi/5
        [HttpGet("{id}", Name = "GetById")]
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // GET: api/Transaksi/waiting
        [HttpGet("status/{stat}/{limit?}", Name = "GetTransaksiByStatus")]
        public IActionResult GetTransaksiByStatus(string stat, int? limit)
        {
            try
            {
                IActionResult response;
                var data = repo.GetTransaksiByStatus(stat, limit);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }

            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Transaksi/status/5
        [HttpPost("status/{id}", Name = "UpdateStatus")]
        public IActionResult UpdateStatus(int id)
        {
            try
            {
                if (repo.UpdateStatus(id))
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

        // GET: api/Transaksi/toko/5
        [HttpGet("toko/{id}", Name = "GetTransaksiByIdToko")]
        public IActionResult GetTransaksiByIdToko(int id)
        {
            try
            {
                IActionResult response;
                var data = repo.GetByIdToko(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST: api/Transaksi
        [HttpPost(Name = "InsertAllTransaksi")]
        public IActionResult Post([FromBody]TransaksiSemuaModel value)
        {
            try
            {
                if (repo.InsertAll(value))
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



        // PUT: api/Transaksi/5
        [HttpPut("{id}", Name = "UpdateTransaksi")]
        public IActionResult Put(int id, [FromBody]TransaksiModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_transaksi;
                data = value;
                data.id_transaksi = id_part;

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
                

                if (repo.Delete(data))
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
    }
}
