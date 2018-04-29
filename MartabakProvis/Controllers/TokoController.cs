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
    [Route("api/Toko")]
    public class TokoController : Controller
    {
        TokoRepo repo = new TokoRepo();

        // GET: api/Toko
        [HttpGet(Name = "GetAllToko")]
        public IActionResult GetAllToko()
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

        // GET: api/Toko/5
        [HttpGet("{id}", Name = "GetToko")]
        public IActionResult GetToko(int id)
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

        // POST: api/Toko
        [HttpPost(Name = "InsertToko")]
        public IActionResult Insert([FromBody]TokoModel value)
        {
            try
            {
                if (repo.Insert(value))
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

        // PUT: api/Toko/5
        [HttpPut("{id}", Name = "UpdateToko")]
        public IActionResult Put(int id, [FromBody]TokoModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_toko;
                data = value;
                data.id_toko = id_part;

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

                if (repo.Delete(data))
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
    }
}
