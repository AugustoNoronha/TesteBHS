using Microsoft.AspNetCore.Mvc;
using TesteTecnicoBHS.Domain.Interfaces;
using TesteTecnicoBHS.Domain.Models;

namespace TesteTecnicoBHs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositoy _repository;
        public ProdutoController(IProdutoRepositoy repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult> GetAllCooperados()
        {
            try
            {
                List<Produto> produtos = await _repository.GetAllProdutos();
                int tam = produtos.Count();

                return Ok(new
                {
                    data = produtos,
                    success = true,
                    message = tam + " itens retornados"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }
        }


    }
}
