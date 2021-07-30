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
    public class ReceitaController : ControllerBase
    {
        public readonly ProdutoRepositorio _produtoRepo;

        public ReceitaController()
        {
            _produtoRepo = new ProdutoRepositorio();
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _produtoRepo.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _produtoRepo.SelecionarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Produto produto)
        {
            _produtoRepo.Cadastrar(produto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produto produto)
        {
            _produtoRepo.Alterar(produto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
