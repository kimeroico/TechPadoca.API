using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPadoca.API.DTO;
using TechPadoca.Dados.Repositorio;
using TechPadoca.Dominio;

namespace TechPadoca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteRepositorio _repo;

        public IngredienteController()
        {
            _repo = new IngredienteRepositorio();
        }

        // GET: api/<IngredienteController>
        [HttpGet("lista")]
        public IEnumerable<Ingrediente> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public Ingrediente Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<IngredienteController>
        [HttpPost("cadastrar")]
        public void Post([FromBody] IngredienteDTO dto)
        {
            var ingrediente = new Ingrediente();
            ingrediente.Cadastrar(dto.Nome);
            _repo.Incluir(ingrediente);
        }
    }
}
