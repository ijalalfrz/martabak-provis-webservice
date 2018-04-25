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
        [HttpGet(Name = "GetAll")]
        public IEnumerable<MenuModel> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        // GET : api/Menu/category/Manis
        [HttpGet("category/{kategori}", Name = "GetByCategory")]
        public IEnumerable<MenuModel> GetByCategory(string kategori)
        {
            var data = repo.GetByCategory(kategori);
            return data;
        }

        // GET: api/Menu/hargaAsc
        [HttpGet("hargaAsc/", Name="GetAllHargaAscending")]
        public IEnumerable<MenuModel> GetAllHargaAscending()
        {
            var data = repo.GetAllHargaAscending();
            return data;
        }

        // GET: api/Menu/hargaDesc
        [HttpGet("hargaDesc/", Name = "GetAllHargaDescending")]
        public IEnumerable<MenuModel> GetAllHargaDescending()
        {
            var data = repo.GetAllHargaDescending();
            return data;
        }

        // GET: api/Menu/namaAsc
        [HttpGet("namaAsc/", Name = "GetAllNamaAscending")]
        public IEnumerable<MenuModel> GetAllNamaAscending()
        {
            var data = repo.GetAllNamaAscending();
            return data;
        }

        // GET: api/Menu/namaDesc
        [HttpGet("namaDesc/", Name = "GetAllNamaDescending")]
        public IEnumerable<MenuModel> GetAllNamaDescending()
        {
            var data = repo.GetAllNamaDescending();
            return data;
        }

        // GET : api/Menu/size/Medium
        [HttpGet("size/{uk}", Name = "GetBySize")]
        public IEnumerable<MenuModel> GetBySize(string uk)
        {
            var data = repo.GetBySize(uk);
            return data;
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "Get")]
        public MenuModel Get(int id)
        {
            var data = repo.GetById(id);
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
        public void Put(int id, [FromBody]MenuModel value)
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
