using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebEstudo.DTO.Entidades;
using WebEstudo.DTO.Interfaces;
using WebEstudo.DTO.Roles;
using WebEstudo.Models;

namespace WebEstudo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDTO _usuarioDTO;
        private readonly ILogger<UsuarioController> _logger;
        private Result JsonRetorno = null;
        private IConfiguration _configuration;
        public UsuarioController(IUsuarioDTO usuarioDTO, ILogger<UsuarioController> logger, IConfiguration configuration)
        {
            this._usuarioDTO = usuarioDTO;
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet, Authorize]
        public ActionResult<Result> Get()
        {
            try
            {
                var users = _usuarioDTO.GetAll();
                JsonRetorno = new Result() { Data = users, Mensagem = "", Erro = false };
            }
            catch (Exception ex)
            {
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpGet, Authorize]
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
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpGet, Authorize]
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
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpPost, Authorize]
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
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpPost]
        [Route("Acesso")]
        public ActionResult<Result> UsuarioAcesso([FromBody] UsuarioDTO users)
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
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpPut, Authorize]
        public ActionResult<Result> Put([FromBody] UsuarioDTO users)
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
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpDelete, Authorize]
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
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<Result> Login([FromBody] LoginModel logins)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var token = _usuarioDTO.Login(_configuration, logins.login, logins.senha, true);
                JsonRetorno = new Result() { Data = token, Mensagem = "Obteve Token com sucesso!!", Erro = false };
            }
            catch (Exception ex)
            {
                JsonRetorno = new Result() { Data = "", Mensagem = ex.Message, Erro = true };
            }
            return JsonRetorno;
        }
    }
}
