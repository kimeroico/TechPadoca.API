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
    public class IngredienteEstoqueController : ControllerBase
    {
        private readonly IngredienteEstoqueRepositorio _repo;

        public IngredienteEstoqueController()
        {
            _repo = new IngredienteEstoqueRepositorio();
        }

        // GET: api/<IngredienteEstoqueController>
        [HttpGet("lista")]
        public IEnumerable<IngredienteEstoque> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<IngredienteEstoqueController>/5
        [HttpGet("{id}")]
        public IngredienteEstoque Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<IngredienteEstoqueController>
        [HttpPost("cadastrar")]
        public void Post([FromBody] IngredienteEstoqueDTO dto)
        {
            var inEstoque = new IngredienteEstoque();
            inEstoque.Cadastrar(dto.QuantidadeTotal, dto.QuantidadeMinima, dto.Local, dto.IdIngrediente);
            _repo.Incluir(inEstoque);
        }
    }
}
