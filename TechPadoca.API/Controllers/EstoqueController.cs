using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPadoca.Dominio.Enum;
using TechPadoca.Dominio;
using TechPadoca.Dados.Repositorio;

namespace TechPadoca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        public readonly EstoqueRepositorio _estoqueRepo;

        public EstoqueController()
        {
            _estoqueRepo = new EstoqueRepositorio();
        }

        [HttpGet("{id}")]
        public Estoque Get(int id)
        {
            return _estoqueRepo.SelecionarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Estoque estoque)
        {
            _estoqueRepo.Cadastrar(estoque);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Estoque estoque)
        {
            _estoqueRepo.Alterar(estoque);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
