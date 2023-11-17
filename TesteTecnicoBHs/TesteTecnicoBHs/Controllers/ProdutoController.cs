using Microsoft.AspNetCore.Mvc;
using TesteTecnicoBHS.Domain.DataTransfer;
using TesteTecnicoBHS.Domain.Interfaces.Repositories;
using TesteTecnicoBHS.Domain.Interfaces.Validacoes;
using TesteTecnicoBHS.Domain.Models;

namespace TesteTecnicoBHs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositoy _repository;
        private readonly IProdutoValidations _validations;
        public ProdutoController(IProdutoRepositoy repository, IProdutoValidations validations)
        {
            _repository = repository;
            _validations = validations;

        }

        [HttpGet]
        public async Task<ActionResult> GetAllProdutos()
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
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet("ativos")]
        public async Task<ActionResult> GetAllProdutosAtivos()
        {
            try
            {
                List<Produto> produtos = await _repository.GetAllActiviteProdutos();
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
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetProdutoById([FromRoute]long id)
        {
          
                Produto produto = _repository.GetProdutoById(id);

            if(produto != null)
            {
                return Ok(new
                {
                    data = produto,
                    success = true,
                    message = " itens retornados"
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Item não encontrado"
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduto(ProdutoDataTransfer produto)
        {
            Boolean validation = _validations.RequestBodyValidation(produto);
            if (validation)
            {

            try
            {
                await _repository.CreateProduto(produto);

                return Ok(new
                {
                    data = new ProdutoDataTransfer { Name = produto.Name, Status = produto.Status},
                    success = true,
                    message = " Item criado"
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
            else
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Os campos devem ser preenchidos de maneira correta"
                });
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduto([FromRoute] long id, ProdutoDataTransfer produto)
        {
            Boolean validation = _validations.RequestBodyValidation(produto);
            if (validation)
            {
                try
            {
                await _repository.UpdateProduto(produto, id);

                return Ok(new
                {
                    data = new ProdutoDataTransfer { Name = produto.Name, Status = produto.Status },
                    success = true,
                    message = " Item Atualizado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Os campos devem ser preenchidos de maneira correta"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto([FromRoute] long id)
        {

            try
            {
                await _repository.DeletProduto(id);

                return Ok(new
                {
                    success = true,
                    message = " item Excluido"
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }

        }



    }
}
