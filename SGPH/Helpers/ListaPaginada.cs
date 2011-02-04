using System;
using System.Collections.Generic;
using System.Linq;

namespace SGPH.Helpers
{
    public class ListaPaginada<T> : List<T>
    {
        public int IndiceDaPagina { get; private set; }
        public int TamanhoDaPagina { get; private set; }
        public int TotalRegistros { get; private set; }
        public int TotalDePaginas { get; private set; }

        public ListaPaginada(IQueryable<T> fonte, int indiceDaPagina, int tamanhoDaPagina)
        {
            IndiceDaPagina = indiceDaPagina;
            TamanhoDaPagina = tamanhoDaPagina;
            TotalRegistros = fonte.Count();
            TotalDePaginas = (int) Math.Ceiling(TotalRegistros/(double) TamanhoDaPagina);

            AddRange(fonte.Skip(IndiceDaPagina*TamanhoDaPagina).Take(TamanhoDaPagina));    
        }

        public bool TemPaginaAnterior
        {
            get
            {
                return (IndiceDaPagina > 0);
            }
        }

        public bool TemPaginaPosterior
        {
            get
            {
                return (IndiceDaPagina + 1 < TotalDePaginas);
            }
        }
    }
}