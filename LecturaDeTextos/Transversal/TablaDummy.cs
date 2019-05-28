using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    class TablaDummy
    {
        private Dictionary<String, List<ComponenteLexico>> tablaDummy = new Dictionary<String, List<ComponenteLexico>>();

        private static TablaDummy Instancia = new TablaDummy();
        private TablaDummy()
        {

        }
        public static TablaDummy obtenerTablaDummy()
        {
            return Instancia;
        }

        public void agregarDummy(ComponenteLexico componenteLexico)
        {
            if (componenteLexico != null && componenteLexico.tipo.Equals(TipoComponenteLexico.DUMMY))
            {
                obtenerDummy(componenteLexico.Lexema).Add(componenteLexico);
            }
        }

        private Boolean existeDummy(String lexema)
        {
            return tablaDummy.ContainsKey(lexema);
        }

        private List<ComponenteLexico> obtenerDummy(String lexema)
        {
            if (!existeDummy(lexema))
            {
                tablaDummy.Add(lexema, new List<ComponenteLexico>());
            }
            return tablaDummy[lexema];
        }

        public Dictionary<String, List<ComponenteLexico>> obtenerDummy()
        {
            return tablaDummy;
        }
    }
}
