using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class ComponenteLexico
    {
        public String Lexema { get; set; }
        public String Categoria { get; set; }
        public int numeroLinea { get; set; }
        public int posicionInicial { get; set; }
        public int posicionFinal { get; set; }
        public TipoComponenteLexico tipo {get; set; }

        private ComponenteLexico(String Lexema, String Categoria, int numeroLinea, int posicionInicial, int posicionFinal) {
            this.Lexema = Lexema;
            this.Categoria = Categoria;
            this.numeroLinea = numeroLinea;
            this.posicionInicial = posicionInicial;
            this.posicionFinal = posicionFinal;
            this.tipo = TipoComponenteLexico.SIMBOLO;
        }

        public static ComponenteLexico Crear (String Lexema, String Categoria, int numeroLinea, int posicionInicial, int posicionFinal)
        {
            return new ComponenteLexico(Lexema, Categoria, numeroLinea, posicionInicial, posicionFinal);
        }

        public static ComponenteLexico Crear(String Lexema, String Categoria)
        {
            return new ComponenteLexico(Lexema, Categoria, 0, 0, 0);
        }
        
    }
}
