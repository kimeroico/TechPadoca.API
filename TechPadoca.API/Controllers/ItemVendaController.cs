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
    public class ItemVendaController : ControllerBase
    {
        private readonly ItemVendaRepositorio _repo;
        public ItemVendaController()
        {
            _repo = new ItemVendaRepositorio();
        }

        // GET: api/<ItemVendaController>
        [HttpGet("lista")]
        public IEnumerable<ItemVenda> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<ItemVendaController>/5
        [HttpGet("{id}")]
        public ItemVenda Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<ItemVendaController>
        [HttpPost("cadastrar")]
        public void Post([FromBody] ItemVendaDTO dto)
        {
            var produto = new ProdutoRepositorio();
            var x = produto.SelecionarPorId(dto.IdProduto);
            var itemVenda = new ItemVenda();
            itemVenda.Cadastrar(dto.IdProduto, dto.IdVenda, dto.Quantidade, x.ValorUnitario);
            _repo.Incluir(itemVenda);
            AtualizarVenda(itemVenda.Id);
        }

        // PUT api/<ItemVendaController>/5
        [HttpPut("{id}/atualizarVenda")]
        public void AtualizarVenda(int id)
        {
            _repo.AtualizarVenda(id);
            _repo.AtualizarLoja(id);
        }        

        // PUT api/<ItemVendaController>/5
        [HttpPut("alterar/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
