using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPadoca.Dominio.Enum;
using TechPadoca.Dominio;
using TechPadoca.Dados.Repositorio;

namespace TechPadoca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        public readonly ReceitaRepositorio _receitaRepositorio;

        public ReceitaController()
        {
            _receitaRepositorio = new ReceitaRepositorio();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReceitaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReceitaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceitaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
