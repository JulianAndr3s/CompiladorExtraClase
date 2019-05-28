using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class Linea
    {
        public int Numero { get; set; }
        public String Contenido { get; set; }

        public Linea() { }

        public Linea(int numero, String contenido) {
            this.Numero = numero;
            this.Contenido = contenido;
        }
    }
}
