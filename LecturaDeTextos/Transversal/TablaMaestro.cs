using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.Transversal
{
    public class TablaMaestro
    {
        private static TablaMaestro Instancia = new TablaMaestro();
        
        public static TablaMaestro obtenerTablaMaestro()
        {
            return Instancia;
        }

        public void agregarElemento(ComponenteLexico componenteLexico) {
            TablaPalabrasReservadas.obtenerTablaPalabrasReservadas().comprobarPalabraReservada(componenteLexico);

            switch (componenteLexico.tipo) {
                case TipoComponenteLexico.DUMMY:
                    TablaDummy.obtenerTablaDummy().agregarDummy(componenteLexico);
                    break;
                case TipoComponenteLexico.LITERAL:
                    TablaLiterales.obtenerTablaLiterales().agregarLiteral(componenteLexico);
                    break;
                case TipoComponenteLexico.PALABRA_RESERVADA:
                    TablaPalabrasReservadas.obtenerTablaPalabrasReservadas().agregarPalabrasReservadas(componenteLexico);
                    break;
                case TipoComponenteLexico.SIMBOLO:
                    TablaSimbolos.obtenerTablaSimbolos().agregarSimbolo(componenteLexico);
                    break;
            }
        }

        public Dictionary<String, List<ComponenteLexico>> obtenerTabla(TipoComponenteLexico tipo) {
            //Dictionary<String, ComponenteLexico> retorno = null;
            Dictionary<String, List<ComponenteLexico>> retorno = null;
            switch (tipo)
            {
                case TipoComponenteLexico.DUMMY:
                    retorno = TablaDummy.obtenerTablaDummy().obtenerDummy();
                    break;
                case TipoComponenteLexico.LITERAL:
                    retorno = TablaLiterales.obtenerTablaLiterales().obtenerLiterales();
                    break;
                case TipoComponenteLexico.PALABRA_RESERVADA:
                    retorno = TablaPalabrasReservadas.obtenerTablaPalabrasReservadas().obtenerPalabrasReservadas();
                    break;
                case TipoComponenteLexico.SIMBOLO:
                    retorno = TablaSimbolos.obtenerTablaSimbolos().obtenerSimbolos();
                    break;
            }
            return retorno;
        }
    }

    

}
