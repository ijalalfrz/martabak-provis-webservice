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
        public IEnumerable<MenuModel> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "GetMenuById")]
        public MenuModel Get(int id)
        {
            var data = repo.GetById(id);
            return data;
        }

        // GET : api/Menu/category/Manis
        [HttpGet("category/{kategori}", Name = "GeMenutByCategory")]
        public IEnumerable<MenuModel> GetByCategory(string kategori)
        {
            var data = repo.GetByCategory(kategori);
            return data;
        }

        // GET: api/Menu/harga/asc
        [HttpGet("harga/{sort}", Name = "GetAllHarga")]
        public IEnumerable<MenuModel> GetAllHarga(string sort)
        {

            var data = repo.GetAllHarga(sort);
            return data;
        }

        // GET: api/Menu/nama/asc
        [HttpGet("nama/{sort}", Name = "GetAllNama")]
        public IEnumerable<MenuModel> GetAllNama(string sort)
        {
            var data = repo.GetAllNama(sort);
            return data;
        }

        // GET : api/Menu/size/Medium
        [HttpGet("size/{uk}", Name = "GetBySize")]
        public IEnumerable<MenuModel> GetBySize(string uk)
        {
            var data = repo.GetBySize(uk);
            return data;
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
