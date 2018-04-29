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
        public IEnumerable<UserModel> Get()
        {
            var data = repo.GetAll();
            return data;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]
        public UserModel Get(int id)
        {
            var data = repo.GetById(id);
            return data;
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
