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
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaRepositorio _repo;

        public ReceitaController()
        {
            _repo = new ReceitaRepositorio();
        }

        // GET: api/<ReceitaController>
        [HttpGet("lista")]
        public IEnumerable<Receita> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<ReceitaController>/5
        [HttpGet("{id}")]
        public Receita Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<ReceitaController>
        [HttpPost("cadastrar")]
        public void Post([FromBody] ReceitaDTO dto)
        {
            var receita = new Receita();
            receita.Cadastrar(dto.IdProduto, dto.IdIngrediente, dto.QtdIngrediente);
            _repo.Incluir(receita);
        }
    }
}
