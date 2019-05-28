using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class TablaSimbolos
    {
        private Dictionary<String,List<ComponenteLexico>> tablaSimbolos = new Dictionary<String,List<ComponenteLexico>>();

        private static TablaSimbolos Instancia = new TablaSimbolos();
        private TablaSimbolos() {

        }
        public static TablaSimbolos obtenerTablaSimbolos() {
            return Instancia;
        }

        public void agregarSimbolo(ComponenteLexico componenteLexico) {
            if (componenteLexico != null && componenteLexico.tipo.Equals(TipoComponenteLexico.SIMBOLO)) {
                obtenerSimbolo(componenteLexico.Lexema).Add(componenteLexico);
            }
        }

        private Boolean existeSimbolo(String lexema) {
            return tablaSimbolos.ContainsKey(lexema);
        }

        private List<ComponenteLexico> obtenerSimbolo(String lexema) {
            if (!existeSimbolo(lexema)) {
                tablaSimbolos.Add(lexema, new List<ComponenteLexico>());
            }
            return tablaSimbolos[lexema];
        }

        public Dictionary<String, List<ComponenteLexico>> obtenerSimbolos() {
            return tablaSimbolos;
        }

        public void limpiar()
        {
            tablaSimbolos.Clear();
        }

        public List<ComponenteLexico> ObtenerTodo()
        {
            return tablaSimbolos.Values.SelectMany(simbolo => simbolo).ToList();
        }


    }
}
