using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebEstudo.Comum.Filter
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = 400;
                var jsonResult = new JsonResult(new { Data = "", Mensagem = "Existem Campos Obrigatórios que não foram informados.", Erro = true });
                context.Result = jsonResult;
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Nada a fazer
            //  return;
        }
    }
}
