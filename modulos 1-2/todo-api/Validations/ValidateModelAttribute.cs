using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
//using System.Web.Http.ModelBinding;


namespace todo_api.Validations
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    if (actionContext.ModelState.IsValid == false)
        //    {
        //        actionContext.Response = actionContext.Request.CreateErrorResponse(
        //            HttpStatusCode.BadRequest, actionContext.ModelState);
        //    }
        //}
    }
}

