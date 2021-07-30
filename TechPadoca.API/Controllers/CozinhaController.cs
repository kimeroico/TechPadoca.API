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
    public class CozinhaController : ControllerBase
    {
        public readonly CozinhaRepositorio _cozinhaRepo;

        public CozinhaController()
        {
            _cozinhaRepo = new CozinhaRepositorio();
        }

        [HttpGet("{id}")]
        public Cozinha Get(int id)
        {
            return _cozinhaRepo.SelecionarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Cozinha cozinha)
        {
          _cozinhaRepo.NovaSolicitacaoDaLoja(cozinha);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cozinha cozinha)
        {
            _cozinhaRepo.AlterarSolicitacao(cozinha);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
