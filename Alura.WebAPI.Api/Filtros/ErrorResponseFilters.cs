using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Filtros
{
    public class ErrorResponseFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ErrorResponse.From(context.Exception)) { StatusCode = 500 };
        }
    }
}
