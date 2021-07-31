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
    public class VendaController : ControllerBase
    {
        private readonly VendaRepositorio _repo;
        public VendaController()
        {
            _repo = new VendaRepositorio();
        }

        [HttpGet("lista")]
        public IEnumerable<Venda> Get()
        {
            return _repo.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Venda Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost("cadastrar")]
        public void Post([FromBody] VendaDTO dto)
        {
            var venda = new Venda();
            venda.Cadastrar(dto.Desconto);
            _repo.Incluir(venda);
        }
    }
}
