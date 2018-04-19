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
    [Route("api/Pembeli")]
    public class PembeliController : Controller
    {
        PembeliRepo repo = new PembeliRepo();

        // GET: api/Pembeli
        [HttpGet(Name = "GetAllPembeli")]
        public IEnumerable<PembeliModel> GetAllPembeli()
        {
            var data = repo.GetAll();
            return data;
        }

        // GET: api/Pembeli/5
        [HttpGet("{id}", Name = "GetPembeli")]
        public PembeliModel GetPembeli(int id)
        {
            var data = repo.GetById(id);
            return data;
        }
        
        // POST: api/Pembeli
        [HttpPost(Name = "InsertPembeli")]
        public void Insert([FromBody]PembeliModel value)
        {
            repo.Insert(value);
        }

        // PUT: api/Pembeli/5
        [HttpPut("{id}", Name = "UpdatePembeli")]
        public void Put(int id, [FromBody]PembeliModel value)
        {
            var data = repo.GetById(id);
            var id_part = data.id_pembeli;
            data = value;
            data.id_pembeli = id_part;
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
