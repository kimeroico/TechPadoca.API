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
    public class LojaController : ControllerBase
    {
        public readonly LojaRepositorio _lojaRepo;

        public LojaController()
        {
            _lojaRepo = new LojaRepositorio();
        }

        [HttpGet("{id}")]
        public Loja Get(int id)
        {
            return _lojaRepo.SelecionePorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Loja loja)
        {
            _lojaRepo.Incluir();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Loja loja)
        {
            _lojaRepo.Alterar();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
