using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using System.Web;

namespace ConsultarNotasRecoleccion.Permisos
{
    public class ValidarSessionAtribute:ActionFilterAttribute
    {

        private readonly IHttpContextAccessor _httpContext;

        public ValidarSessionAtribute(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext context = HttpContext.Current;
            if (_httpContext.HttpContext.User.Identity.Name == null)
            {
                filterContext.Result = new LocalRedirectResult("~/Acces/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
