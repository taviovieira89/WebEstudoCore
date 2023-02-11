using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebEstudo.Comum.Filter
{
    public class AuthorizeFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.StatusCode = 401;
                var jsonResult = new JsonResult(new { Data = "", Mensagem = "O token está invalido ou não foi passado!", Erro = true });
                context.Result = jsonResult;
            }
        }
    }
}
