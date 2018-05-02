using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;
using MartabakProvis.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Text.RegularExpressions;

namespace MartabakProvis.Controllers
{
    [Produces("application/json")]
    [Route("api/Menu")]

    public class MenuController : Controller
    {
        MenuRepo repo = new MenuRepo();

        // GET: api/Menu
        [HttpGet(Name = "GetAllWithPrice")]
        public IActionResult GetAllWithPrice()
        {
            try
            {
                var data = repo.GetAllWithPrice();
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

        // GET: api/Menu/5
        [HttpGet("price/{id}", Name = "GetPriceById")]
        public IActionResult GetPriceById(int id)
        {
            try
            {
                var data = repo.GetPriceById(id);
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

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "GetMenuById")]
        public IActionResult GetMenuById(int id)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET : api/Menu/category/Manis
        [HttpGet("category/{kategori}", Name = "GetMenuByCategory")]
        public IActionResult GetMenuByCategory(string kategori)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }

        }
        
        // GET: api/Menu/topping/asc
        [HttpGet("topping/{sort}", Name = "GetSortedTopping")]
        public IActionResult GetSortedTopping(string sort)
        {
            try
            {
                var data = repo.GetAllByTopping(sort);
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

        // DELETE: api/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = repo.GetById(id);

                string path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/",
                        data.gambar);
                string output = Regex.Replace(path, "/", "\\");

                FileInfo fi = new FileInfo(output);
                fi.Delete();

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

        // PUT: api/Menu/5
        [HttpPut("{id}", Name = "Update")]
        public async Task<IActionResult> Update(int id, [FromForm]MenuViewModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_menu;

                string path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/",
                        data.gambar);
                string output = Regex.Replace(path, "/", "\\");

                FileInfo fi = new FileInfo(output);
                fi.Delete();

                path = await UploadFile(value.gambar);

                if (path != "err")
                {
                    data.id_menu = id_part;
                    data.gambar = path;
                    data.deskripsi = value.deskripsi;
                    data.kategori_menu = value.kategori_menu;
                    data.topping = value.topping;
                    data.harga_medium = value.harga_medium;
                    data.harga_large = value.harga_large;

                    if (repo.Update(data))
                    {
                        return Created("", data);
                    }
                    else
                    {
                        return BadRequest();
                    }
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

        // POST: api/Menu
        [HttpPost(Name = "Insert")]
        public async Task<IActionResult> Insert([FromForm]MenuViewModel value)
        {
            try
            {

                string pathUpload = await UploadFile(value.gambar);
                if (pathUpload != "err")
                {
                    MenuModel item = new MenuModel();
                    item.gambar = pathUpload;
                    item.deskripsi = value.deskripsi;
                    item.kategori_menu = value.kategori_menu;
                    item.topping = value.topping;
                    item.harga_medium = value.harga_medium;
                    item.harga_large = value.harga_large;
                    if (repo.Insert(item))
                    {
                        return Created("",item);
                    }
                    else
                    {
                        return BadRequest();
                    }
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

        private async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "err";
            string filename = DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "uploads/" + filename;
        }
    }
}
