using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPadoca.Dados.Repositorio;
using TechPadoca.Dominio;

namespace TechPadoca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepositorio _repo;

        public ProdutoController()
        {
            _repo = new ProdutoRepositorio();
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
