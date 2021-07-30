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
    public class ItemVendaController : ControllerBase
    {
        public readonly ItemVendaRepositorio _itemVendaRepo;

        public ItemVendaController()
        {
            _itemVendaRepo = new ItemVendaRepositorio();
        }

        [HttpGet("{id}")]
        public IEnumerable<ItemVenda> Get()
        {
            return _itemVendaRepo.SelecionarTudo();
        }

        [HttpPost]
        public void Post([FromBody] ItemVenda itemVenda)
        {
            _itemVendaRepo.Cadastrar(itemVenda);
        }

    }
}
