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
    public class CozinhaController : ControllerBase
    {
        private readonly CozinhaRepositorio _repo;

        public CozinhaController()
        {
            _repo = new CozinhaRepositorio();
        }

        // GET: api/<CozinhaController>
        [HttpGet("lista")]
        public IEnumerable<Cozinha> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<CozinhaController>/5
        [HttpGet("{id}")]
        public Cozinha Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpGet("RetirarIngredientesDoEstoque/{id}")]
        public bool Processo(int id)
        {
            return _repo.ExecutandoProcesso(id);
        }

        [HttpGet("EntragarParaLoja/{id}")]
        public bool EntragarParaLoja(int id)
        {
            return _repo.EntregarParaLoja(id);
        }      
    }
}
