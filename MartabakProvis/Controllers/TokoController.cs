﻿using System;
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
    [Route("api/Toko")]
    public class TokoController : Controller
    {
        TokoRepo repo = new TokoRepo();

        // GET: api/Toko
        [HttpGet(Name = "GetAllToko")]
        public IActionResult GetAllToko()
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

        // GET: api/Toko/5
        [HttpGet("{id}", Name = "GetToko")]
        public IActionResult GetToko(int id)
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

        // POST: api/Toko
        [HttpPost(Name = "InsertToko")]
        public void Insert([FromBody]TokoModel value)
        {
            repo.Insert(value);
        }

        // PUT: api/Toko/5
        [HttpPut("{id}", Name = "UpdateToko")]
        public void Put(int id, [FromBody]TokoModel value)
        {
            var data = repo.GetById(id);
            var id_part = data.id_toko;
            data = value;
            data.id_toko = id_part;
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
