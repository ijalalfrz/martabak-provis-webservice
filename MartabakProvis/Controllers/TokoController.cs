using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;
using MartabakProvis.Models;
using MartabakProvis.Helper;

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
                var data = repo.GetAllWithUser();
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

        // GET: api/Toko/5
        [HttpGet("{id}", Name = "GetToko")]
        public IActionResult GetToko(int id)
        {
            try
            {
                var data = repo.GetByIdWithUser(id);
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

        // POST: api/Toko
        [HttpPost(Name = "InsertToko")]
        public IActionResult Insert([FromBody]TokoViewModel value)
        {
            try
            {
                value.user.password = Util.GetSHA1HashData(value.user.password);

                UserRepo urepo = new UserRepo();

                if (urepo.GetByUsername(value.user.username) != null)
                {
                    return BadRequest();
                }
                else
                {
                    if (repo.InsertAll(value))
                    {
                        return Created("", value);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
