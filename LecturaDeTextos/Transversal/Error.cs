using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class Error
    {
        public String Lexema { get;  }
        public String Categoria { get;  }
        public int numeroLinea { get;  }
        public int posicionInicial { get; }
        public int posicionFinal { get; }
        public String Causa { get; }
        public String Falla { get; }
        public String Solucion { get; }
        public TipoError Tipo { get; }

        private Error(String Lexema, String Categoria, int numeroLinea, int posicionInicial, int posicionFinal, String Causa,
            String Falla, String Solucion, TipoError Tipo)
        {
            this.Lexema = Lexema;
            this.Categoria = Categoria;
            this.numeroLinea = numeroLinea;
            this.posicionInicial = posicionInicial;
            this.posicionFinal = posicionFinal;
            this.Causa = Causa;
            this.Falla = Falla;
            this.Solucion = Solucion;
            this.Tipo = Tipo;
        }

        public static Error Crear(String Lexema, String Categoria, int numeroLinea, int posicionInicial, int posicionFinal, String Causa,
            String Falla, String Solucion, TipoError Tipo)
        {
            return new Error(Lexema, Categoria, numeroLinea, posicionInicial, posicionFinal, Causa, Falla, Solucion, Tipo);
        }



    }
}
