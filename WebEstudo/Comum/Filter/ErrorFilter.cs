using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebEstudo.Models;

namespace WebEstudo.Comum.Filter
{
    public class ErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            var jsonResult = new JsonResult(new { Data = "", Mensagem = context.Exception.Message, Erro = true });
            context.Result = jsonResult;
            context.ExceptionHandled = true;

        }
    }
}
