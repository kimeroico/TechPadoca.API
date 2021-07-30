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
    public class VendaController : ControllerBase
    {
        public readonly VendaRepositorio _vendaRepo;
        public VendaController()
        {
            _vendaRepo = new VendaRepositorio();
        }

        [HttpGet("{id}")]
        public Venda Get(int id)
        {
            return _vendaRepo.SelecionarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Venda venda)
        {
            _vendaRepo.Cadastrar(venda);
        }
    }
}
