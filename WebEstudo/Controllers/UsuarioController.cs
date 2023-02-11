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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioDTO;
        private readonly ILogger<UsuarioController> _logger;
        private Result JsonRetorno = null;
        private IConfiguration _configuration;
        public UsuarioController(IUsuarioServices usuarioDTO, ILogger<UsuarioController> logger, IConfiguration configuration)
        {
            this._usuarioDTO = usuarioDTO;
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet, AuthorizeFilter]
        public ActionResult<Result> Get()
        {
            try
            {
                var users = _usuarioDTO.GetAll();
                JsonRetorno = new Result() { Data = users, Mensagem = "", Erro = false };
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
                var users = _usuarioDTO.GetId(Id);
                JsonRetorno = new Result() { Data = users, Mensagem = "", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint GET.");
            }
            return JsonRetorno;
        }

        [HttpGet, AuthorizeFilter]
        [Route("GetName/{Name}")]
        public ActionResult<Result> Get(string Name)
        {
            try
            {
                var users = _usuarioDTO.GetNomeUsuario(Name);
                JsonRetorno = new Result() { Data = users, Mensagem = "", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint GET.");
            }
            return JsonRetorno;
        }

        [HttpPost, AuthorizeFilter]
        public ActionResult<Result> Post([FromBody] UsuarioDTO users)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = _usuarioDTO.Salvar(users);
                JsonRetorno = new Result() { Data = user, Mensagem = "Usuário salvo com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint POST.");
            }
            return JsonRetorno;
        }

        [HttpPost]
        [Route("Acesso")]
        public ActionResult<Result> UsuarioAcesso([FromBody] UsuarioDTO users)
        {
            try
            {
                var user = _usuarioDTO.Salvar(users);
                JsonRetorno = new Result() { Data = user, Mensagem = "Usuário salvo com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint POST.");
            }
            return JsonRetorno;
        }

        [HttpPut, AuthorizeFilter]
        public ActionResult<Result> Put([FromBody] UsuarioDTO users)
        {
            try
            {
                var user = _usuarioDTO.Salvar(users);
                JsonRetorno = new Result() { Data = user, Mensagem = "Usuário salvo com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint PUT.");
            }
            return JsonRetorno;
        }

        [HttpDelete, AuthorizeFilter]
        [Route("Exclusao/{IdUsuario}")]
        public ActionResult<Result> Delete(int IdUsuario)
        {
            try
            {
                var userDelete = _usuarioDTO.GetId(IdUsuario);
                if (userDelete.Count > 0)
                    _usuarioDTO.Excluir(userDelete[0]);
                JsonRetorno = new Result() { Data = "", Mensagem = "Exclusão realizada com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint DELETE.");
            }
            return JsonRetorno;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<Result> Login([FromBody] LoginModel logins)
        {
            try
            {
                var token = _usuarioDTO.Login(_configuration, logins.login, logins.senha, true);
                JsonRetorno = new Result() { Data = token, Mensagem = "Obteve Token com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro no EndPoint POST.");
            }
            return JsonRetorno;
        }
    }
}
