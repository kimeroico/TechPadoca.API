using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechPadoca.API.DTO;
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
        public void Post([FromBody] ProdutoDTO dto)
        {
            var produto = new Produto();
            produto.Cadastrar(dto.Nome, dto.Marca, dto.ValorUnitario, dto.Descricao);

            _repo.Incluir(produto);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProdutoDTO dto)
        {
            var produto = new Produto();
            _repo.Alterar(id, dto.Nome, dto.Marca, dto.ValorUnitario, dto.Descricao);
        }

        [HttpPut("{id}/ativar")]
        public void Ativar(int id)
        {
            var produto = new Produto();
            _repo.AlterarOn(id);
        }

        [HttpPut("{id}/desativar")]
        public void desativar(int id)
        {
            var produto = new Produto();
            _repo.AlterarOff(id);
        }

        //// DELETE api/<ProdutoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
