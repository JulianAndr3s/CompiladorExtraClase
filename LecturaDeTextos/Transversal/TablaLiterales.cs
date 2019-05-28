using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class TablaLiterales
    {
        private Dictionary<String, List<ComponenteLexico>> tablaLiterales = new Dictionary<String, List<ComponenteLexico>>();

        private static TablaLiterales Instancia = new TablaLiterales();
        private TablaLiterales()
        {

        }
        public static TablaLiterales obtenerTablaLiterales()
        {
            return Instancia;
        }

        public void agregarLiteral(ComponenteLexico componenteLexico)
        {
            if (componenteLexico != null && componenteLexico.tipo.Equals(TipoComponenteLexico.LITERAL))
            {
                obtenerLiteral(componenteLexico.Lexema).Add(componenteLexico);
            }
        }

        private Boolean existeLiteral(String lexema)
        {
            return tablaLiterales.ContainsKey(lexema);
        }

        private List<ComponenteLexico> obtenerLiteral(String lexema)
        {
            if (!existeLiteral(lexema))
            {
                tablaLiterales.Add(lexema, new List<ComponenteLexico>());
            }
            return tablaLiterales[lexema];
        }

        public Dictionary<String, List<ComponenteLexico>> obtenerLiterales()
        {
            return tablaLiterales;
        }
    }
}
