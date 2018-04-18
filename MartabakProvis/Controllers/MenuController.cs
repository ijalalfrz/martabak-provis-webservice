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
    [Route("api/Menu")]
    public class MenuController : Controller
    {
        MenuRepo repo = new MenuRepo();

        // GET: api/Menu
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Afina Hadaina Yudianita", "value2" };
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "Get")]
        public MenuModel Get(int id)
        {
            var data = repo.GetByid(id);

            return data;
        }
        
        // POST: api/Menu
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // POST: api/Menu
        [HttpPost(Name = "Insert")]
        public void Insert([FromBody]MenuModel value)
        {
            repo.Insert(value);
        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = repo.GetByid(id);

            repo.Delete(data);
        }
    }
}
