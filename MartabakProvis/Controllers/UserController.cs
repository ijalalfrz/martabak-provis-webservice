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

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult Get(int id)
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

        // POST: api/Menu
        [HttpPost(Name = "InsertUser")]
        public void Insert([FromBody]UserModel value)
        {
            repo.Insert(value);
        }

        // PUT: api/Menu/5
        [HttpPut("{id}", Name = "UpdateUser")]
        public void Update(int id, [FromBody]UserModel value)
        {
            var data = repo.GetById(id);
            var id_part = data.id_user;
            data = value;
            data.id_user = id_part;
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
