﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;
using MartabakProvis.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;

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

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "GetMenuById")]
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

        // GET: api/Menu/topping/
        [HttpGet("topping", Name = "GetAllByTopping")]
        public IActionResult GetMenuByTopping()
        {
            try
            {
                var data = repo.GetAllByTopping();
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

        // GET: api/Menu/Coklat kacang keju/Medium
        [HttpGet("{topping}/{size}", Name = "GetByToppingAndSize")]
        public IActionResult GetByToppingAndSize(string topping, string size)
        {
            try
            {
                var data = repo.GetByToppingAndSize(topping, size);
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
            catch(Exception e)
            {
                return BadRequest(new {
                    message = e.Message
                });
            }

        }



        // GET : api/Menu/category/Manis
        [HttpGet("category/{kategori}", Name = "GetMenuByCategory")]
        public IActionResult GetByCategory(string kategori)
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
            catch
            {
                return BadRequest();
            }
            
        }

        // GET: api/Menu/harga/asc
        [HttpGet("harga/{sort}", Name = "GetAllHarga")]
        public IActionResult GetAllHarga(string sort)
        {
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // GET: api/Menu/nama/asc
        [HttpGet("nama/{sort}", Name = "GetAllNama")]
        public IActionResult GetAllNama(string sort)
        {
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // GET : api/Menu/size/Medium
        [HttpGet("size/{uk}", Name = "GetBySize")]
        public IActionResult GetBySize(string uk)
        {
            try
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
            catch
            {
                return BadRequest();
            }
            
        }

        // POST: api/Menu
        [HttpPost(Name = "Insert")]
        public async Task<IActionResult> Insert([FromBody]MenuModel value, IFormFile file)
        {
            try
            {
                

                if (repo.Insert(value))
                {
                    await UploadFile(file);
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
        [HttpPut("{id}", Name = "Update")]
        public IActionResult Update(int id, [FromBody]MenuModel value)
        {
            try
            {
                var data = repo.GetById(id);
                var id_part = data.id_menu;
                data = value;
                data.id_menu = id_part;

                if (repo.Update(value))
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
        
        public async Task<bool> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
