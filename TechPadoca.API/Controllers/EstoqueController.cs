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
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueRepositorio _repo;
        public EstoqueController()
        {
            _repo = new EstoqueRepositorio();
        }

        [HttpGet("lista")]
        public IEnumerable<Estoque> Get()
        {
            return _repo.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Estoque Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost("cadastrar")]
        public void Post([FromBody] EstoqueDTO dto)
        {
            var estoque = new Estoque();
            estoque.Cadastrar(dto.QuantidadeTotal, dto.QuantidadeMinima, dto.IdProduto, dto.Local);
            _repo.Incluir(estoque);
        }

        [HttpPut("alterar/{id}")]
        public void Put(int id, [FromBody] EstoqueDTO dto)
        {            
            _repo.Alterar(id, dto.QuantidadeTotal, dto.QuantidadeMinima, dto.Local);
        }
    }
}
