using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;
using MartabakProvis.Models;
using Microsoft.AspNetCore.Authorization;
using MartabakProvis.Helper;
using Microsoft.AspNetCore.SignalR;

namespace MartabakProvis.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaksi"), Authorize]
    public class TransaksiController : Controller
    {
        TransaksiRepo repo = new TransaksiRepo();


        public TransaksiController(IHubContext<PushNotif> hubcontext)
        {
            HubContext = hubcontext;
        }
        private IHubContext<PushNotif> HubContext
        {
            get;
            set;
        }
        // GET: api/Transaksi
        [HttpGet("sort/{order}/{limit?}", Name = "GetAllWithDetail")]
        public IActionResult GetAllWithDetail(string order, int? limit)
        {
            try
            {
                var data = repo.GetAllWithDetail(order, limit);
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
        [HttpGet("date/{order}/{limit?}", Name = "GetAllWithDetailDate")]
        public IActionResult GetAllWithDetailDate(string order, int? limit)
        {
            try
            {
                var data = repo.GetAllWithDetailDate(order, limit);
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

        // GET: api/Transaksi/03-03-2018/04-04-2018
        [HttpGet("date/{from}/{until}/{order}/{limit?}", Name = "GetByDateRange")]
        public IActionResult GetByDateRange(string from, string until, string order, int? limit)
        {
            try
            {
                var data = repo.GetByDateRange(from, until, order, limit);
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
        [HttpGet("status/{stat}/{order}/{limit?}", Name = "GetTransaksiByStatus")]
        public IActionResult GetTransaksiByStatus(string stat, string order, int? limit)
        {
            try
            {
                IActionResult response;
                var data = repo.GetTransaksiByStatus(stat, order, limit);
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
        [HttpGet("toko/{id}/{order}/{limit?}", Name = "GetTransaksiByIdToko")]
        public IActionResult GetTransaksiByIdToko(int id, string order, int? limit)
        {
            try
            {
                IActionResult response;
                var data = repo.GetByIdToko(id, order, limit);
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
        public IActionResult Post([FromBody]TransaksiViewModel value)
        {
            try
            {
                if (repo.InsertAll(value))
                {

                    HubContext.Clients.All.SendAsync("orderNotif",new {
                        message = "Ada pesanan baru atas nama " + value.transaksi.nama_pembeli
                    });
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
                    return Created("", value);
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
