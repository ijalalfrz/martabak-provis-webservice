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
    [Route("api/Menu"),Authorize]

    public class MenuController : Controller
    {
        MenuRepo repo = new MenuRepo();

        // GET: api/Menu
        [HttpGet(Name = "GetAllMenu")]
        public IActionResult GetAll()
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

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "GetMenuById")]
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

        // GET : api/Menu/category/Manis
        [HttpGet("category/{kategori}", Name = "GeMenutByCategory")]
        public IActionResult GetByCategory(string kategori)
        {
            var data = repo.GetByCategory(kategori);
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

        // GET: api/Menu/harga/asc
        [HttpGet("harga/{sort}", Name = "GetAllHarga")]
        public IActionResult GetAllHarga(string sort)
        {
            
            var data = repo.GetAllHarga(sort);
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

        // GET: api/Menu/nama/asc
        [HttpGet("nama/{sort}", Name = "GetAllNama")]
        public IActionResult GetAllNama(string sort)
        {
            var data = repo.GetAllNama(sort);
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

        // GET : api/Menu/size/Medium
        [HttpGet("size/{uk}", Name = "GetBySize")]
        public IActionResult GetBySize(string uk)
        {
            var data = repo.GetBySize(uk);
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
        [HttpPost(Name = "Insert")]
        public void Insert([FromBody]MenuModel value)
        {
            repo.Insert(value);
        }

        // PUT: api/Menu/5
        [HttpPut("{id}", Name = "Update")]
        public void Update(int id, [FromBody]MenuModel value)
        {
            var data = repo.GetById(id);
            var id_part = data.id_menu;
            data = value;
            data.id_menu = id_part;
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
