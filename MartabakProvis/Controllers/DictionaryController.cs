using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartabakProvis.Repositories;

namespace MartabakProvis.Controllers
{
    [Produces("application/json")]
    [Route("api/Dictionary")]
    public class DictionaryController : Controller
    {
        DictionaryRepo repo = new DictionaryRepo();
        
        // GET: api/Dictionary/tabel
        [HttpGet("tabel", Name = "GetAllTableName")]
        public IActionResult GetAllTableName()
        {
            try
            {
                var data = repo.GetAllTableName();
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

        // GET: api/Dictionary/t_transaksi
        [HttpGet("{table}", Name = "GetDictionary")]
        public IActionResult GetDictionary(string table)
        {
            try
            {
                var data = repo.GetDictionary(table);
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

        
    }
}
