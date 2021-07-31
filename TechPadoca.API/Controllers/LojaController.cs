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
    public class LojaController : ControllerBase
    {
        private readonly LojaRepositorio _repo;

        public LojaController()
        {
            _repo = new LojaRepositorio();
        }

        // GET: api/<LojaController>
        [HttpGet("lista")]
        public IEnumerable<Loja> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<LojaController>/5
        [HttpGet("{id}")]
        public Loja Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<LojaController>
        [HttpPost("cadastrar")]
        public void Post([FromBody] LojaDTO dto)
        {
            var lojaProduto = new Loja();
            lojaProduto.Cadastrar(dto.ProdutoId, dto.Quantidade, dto.QuantidadeMinima);
            _repo.Incluir(lojaProduto);
        }

        // PUT api/<LojaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LojaDTO dto)
        {
            var produto = new Produto();
            _repo.Alterar(id, dto.Quantidade, dto.QuantidadeMinima);
        }

        // DELETE api/<LojaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
