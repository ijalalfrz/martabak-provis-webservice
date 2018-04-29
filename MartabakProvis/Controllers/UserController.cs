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
    [Route("api/User")]
    public class UserController : Controller
    {
        UserRepo repo = new UserRepo();
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
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

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult Get(int id)
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

        // POST: api/Menu
        [HttpPost(Name = "InsertUser")]
        public IActionResult Insert([FromBody]UserModel value)
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

        // PUT: api/Menu/5
        [HttpPut("{id}", Name = "UpdateUser")]
        public IActionResult Update(int id, [FromBody]UserModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_user;
                data = value;
                data.id_user = id_part;

                if (repo.Update(value)){
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
