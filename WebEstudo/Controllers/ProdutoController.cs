using Microsoft.AspNetCore.Mvc;
using WebEstudo.Comum.Filter;
using WebEstudo.DTO.Entidades;
using WebEstudo.DTO.Interfaces;
using WebEstudo.DTO.Roles;
using WebEstudo.Models;

namespace WebEstudo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(ErrorFilter))]
    [ServiceFilter(typeof(ActionFilter))]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServices _ProdutoDTO;
        private readonly ILogger<UsuarioController> _logger;
        private Result JsonRetorno = null;
        private IConfiguration _configuration;
        public ProdutoController(IProdutoServices ProdutoDTO, ILogger<UsuarioController> logger, IConfiguration configuration)
        {
            this._ProdutoDTO = ProdutoDTO;
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet, AuthorizeFilter]
        public ActionResult<Result> Get()
        {
            try
            {
                var prods = _ProdutoDTO.GetAll();
                JsonRetorno = new Result() { Data = prods, Mensagem = "", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint GET.");
            }
            return JsonRetorno;
        }

        [HttpGet, AuthorizeFilter]
        [Route("GetId/{Id}")]
        public ActionResult<Result> Get(int Id)
        {
            try
            {
                var prods = _ProdutoDTO.GetId(Id);
                JsonRetorno = new Result() { Data = prods, Mensagem = "", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint GET.");
            }
            return JsonRetorno;
        }

        [HttpGet, AuthorizeFilter]
        [Route("GetNome/{Name}")]
        public ActionResult<Result> Get(string Name)
        {
            try
            {
                var prods = _ProdutoDTO.GetProdutoName(Name);
                JsonRetorno = new Result() { Data = prods, Mensagem = "", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint GET.");
            }
            return JsonRetorno;
        }

        [HttpPost, AuthorizeFilter]
        public ActionResult<Result> Post([FromBody] ProdutoDTO prods)
        {
            try
            {
                var prod = _ProdutoDTO.Salvar(prods);
                JsonRetorno = new Result() { Data = prod, Mensagem = "Produto Salvo com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint POST.");
            }
            return JsonRetorno;
        }

        [HttpPut, AuthorizeFilter]
        public ActionResult<Result> Put([FromBody] ProdutoDTO prods)
        {
            try
            {
                var prod = _ProdutoDTO.Salvar(prods);
                JsonRetorno = new Result() { Data = prod, Mensagem = "Produto Salvo com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint PUT.");
            }
            return JsonRetorno;
        }

        [HttpDelete, AuthorizeFilter]
        [Route("Exclusao/{IdProduto}")]
        public ActionResult<Result> Delete(int IdProduto)
        {
            try
            {
                var userDelete = _ProdutoDTO.GetId(IdProduto);
                if (userDelete.Count > 0)
                    _ProdutoDTO.Excluir(userDelete[0]);
                JsonRetorno = new Result() { Data = "", Mensagem = "Exclusão realizada com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint DELETE.");
            }
            return JsonRetorno;
        }

    }
}
