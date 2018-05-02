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
    [Route("api/Size")]
    public class SizeController : Controller
    {
        SizeRepo repo = new SizeRepo();
        

        // GET: api/Size
        [HttpGet]
        public IActionResult GetAllSize()
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

        // GET: api/Size/5
        [HttpGet("{id}", Name = "GetSizeByIdMenu")]
        public IActionResult GetSizeByIdMenu(int id)
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
        
        // POST: api/Size
        [HttpPost]
        public IActionResult Post([FromBody]SizeModel value)
        {
            try
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
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        
        // PUT: api/Size/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SizeModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_size;
                data = value;
                data.id_size = id_part;

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
