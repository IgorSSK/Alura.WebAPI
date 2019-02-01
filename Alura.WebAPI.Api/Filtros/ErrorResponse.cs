using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Filtros
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string[] Detalhes { get; set; }
        public ErrorResponse InnerError { get; set; }

        public static ErrorResponse From(Exception e)
        {
            if (e == null)
            {
                return null;
            }
            return new ErrorResponse
            {
                Codigo = e.HResult,
                Mensagem = e.Message,
                InnerError = ErrorResponse.From(e.InnerException)
            };
        }

        public static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors);
            return new ErrorResponse
            {
                Codigo = 100,
                Mensagem = "Houve erro(s) na validação da requisição",
                Detalhes = errors.Select(e => e.ErrorMessage).ToArray(),
            };
        }
    }
}
