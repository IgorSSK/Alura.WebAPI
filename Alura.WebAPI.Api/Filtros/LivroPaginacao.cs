using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Filtros
{
    public static class LivroPaginacaoExtensions
    {
        public static LivroPaginado ToLivroPaginado(this IQueryable<LivroApi> query, LivroPaginacao livroPaginacao)
        {
            int totalItens = query.Count();
            int totalPaginas =  (int) Math.Ceiling(totalItens / (double) livroPaginacao.Tamanho);

            return new LivroPaginado
            {
                Total = totalItens,
                TotalPaginas = totalPaginas,
                NumeroPagina = livroPaginacao.Pagina,
                TamanhoPagina = livroPaginacao.Tamanho,
                Resultado = query.Skip(livroPaginacao.Tamanho * (livroPaginacao.Pagina -1)).Take(livroPaginacao.Tamanho).ToList(),
                Anterior = (livroPaginacao.Pagina > 1) ? $"livros?tamanho={livroPaginacao.Pagina - 1}&pagina={livroPaginacao.Tamanho}" : "",
                Proximo = (livroPaginacao.Pagina < 1) ? $"livros?tamanho={livroPaginacao.Pagina + 1}&pagina={livroPaginacao.Tamanho}" : "",

            };
                
        }
    }

    public class LivroPaginado
    {
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPagina { get; set; }
        public IList<LivroApi> Resultado { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }

    public class LivroPaginacao
    {
        public int Pagina { get; set; }
        public int Tamanho { get; set; }
    }
}
