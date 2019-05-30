using LecturaDeTextos.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeTextos.AnalizadorLexico
{
    public class AnalisisLexico
    {
        private int puntero;
        private int numeroLineaActual = 0;
        private String contenidoLineaActual;
        private String caracterActual;
        private String Causa;
        private String Falla;
        private String Solucion;

        public AnalisisLexico() {
            cargarNuevaLinea();
        }

        private void cargarNuevaLinea() {
            if (!"@EOF@".Equals(contenidoLineaActual))
            {
                numeroLineaActual++;
                puntero = 1;
                contenidoLineaActual = Cache.obtenerCache().obtenerLinea(numeroLineaActual).Contenido;
            }
            
        }

        private void leerSiguienteCaracter() {
            if ("@EOF@".Equals(contenidoLineaActual))
            {
                caracterActual = "@EOF@";
            }
            else if (puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@FL@";
                puntero++;
            }
            else {
                caracterActual = contenidoLineaActual.Substring(puntero - 1, 1);
                puntero++;
            }
        }

        private void devolverPuntero(){
            puntero--;
        }

        public ComponenteLexico analizar() {
            int estadoActual = 0;
            bool continuarAnalisis = true;
            String lexema = "";
            ComponenteLexico componenteLexico = null;
            
            while (continuarAnalisis) {
                switch (estadoActual){
                    case 0:
                        leerSiguienteCaracter();

                        while ("".Equals(caracterActual.Trim()))
                        {
                            leerSiguienteCaracter();
                        }

                        if (",".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 1;
                        }
                        else if ("C".Equals(caracterActual) || "c".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        }
                        else if ("T".Equals(caracterActual) || "t".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 11;
                        }
                        else if ("A".Equals(caracterActual) || "a".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 38;
                        }
                        else if ("O".Equals(caracterActual) || "o".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 47;
                        }
                        else if ("D".Equals(caracterActual) || "d".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 53;
                        }
                        else if (Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else if ("'".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 18;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 21;
                        }
                        else if (">".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 27;
                        }
                        else if ("<".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 30;
                        }
                        else if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 34;
                        }
                        else if ("!".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 35;
                        }
                        else if ("".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 18;
                        }
                        else if ("@EOF@".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 61;
                        }
                        else if ("@FL@".Equals(caracterActual))
                        {
                            estadoActual = 63;
                        }
                        else {
                            estadoActual = 62;
                        }
                        break;

                    case 1:                    
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "SEPARADOR", 
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;

                    case 2:
                        leerSiguienteCaracter();
                        
                        if ("A".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 3;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else {
                            estadoActual = 8;
                        }
                        
                        break;
                    case 3:
                        leerSiguienteCaracter();
                        if ("M".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 4;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 8;
                        }

                        break;
                    case 4:
                        leerSiguienteCaracter();
                        if ("_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 5;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]))                          
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 8;
                        }

                        break;
                    case 5:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else {
                            estadoActual = 8;
                        }

                        break;
                    case 6:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else {
                            estadoActual = 7;
                        }
                        break;
                    case 7:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "CAMPO",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 8:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "IDENTIFICADOR",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 9:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 11:
                        leerSiguienteCaracter();
                        if ("A".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                        }
                        
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 8;
                        }

                        break;
                    case 12:
                        leerSiguienteCaracter();
                        if ("B".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 13;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 13:
                        leerSiguienteCaracter();
                        if ("_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || (Char.IsLetter(caracterActual.ToCharArray()[0])))
                        {
                            lexema += caracterActual;
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 14:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || (Char.IsLetter(caracterActual.ToCharArray()[0]))
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 15;
                        }
                        else {
                            estadoActual = 8;
                        }
                        break;
                    case 15:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || (Char.IsLetter(caracterActual.ToCharArray()[0]))
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 15;
                        }
                        else
                        {
                            estadoActual = 16;
                        }
                        break;
                    case 16:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "TABLA",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 18:
                        leerSiguienteCaracter();
                        if ("@EOF@".Equals(caracterActual))
                        {
                            estadoActual = -1;
                        }
                        else if ("'".Equals(caracterActual)) {
                            lexema += caracterActual;
                            estadoActual = 20;
                        }
                        else if ("@FL@".Equals(caracterActual))
                        {
                            cargarNuevaLinea();
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 19; 
                        }                 
                        break;
                    case -1:
                        devolverPuntero();
                        continuarAnalisis = false;
                        Causa = "Se esperaba un LITERAL y recibió: " + lexema + "";
                        Falla = " LITERAL mal formado. ";
                        Solucion = "El LITERAL se forma con ' ' y adentro lleva Letras, Digitos o simbolos";

                        ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(lexema, Causa, Falla, Solucion));

                        componenteLexico = ComponenteLexico.Crear(lexema + "'", "LITERAL", numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        componenteLexico.tipo = TipoComponenteLexico.DUMMY;
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 19:
                        leerSiguienteCaracter();
                        if ("@EOF@".Equals(caracterActual))
                        {
                            estadoActual = -1;
                        }
                        else if ("'".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 20;
                        }
                        else if ("@FL@".Equals(caracterActual))
                        {
                            cargarNuevaLinea();
                        }
                        else 
                        {
                            lexema += caracterActual;
                            estadoActual = 19;
                        }
                        break;
                    case 20:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "LITERAL",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        componenteLexico.tipo = TipoComponenteLexico.LITERAL;
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 21:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 21;
                        }
                        else if (".".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 23;
                        }
                        else {
                            estadoActual = 22;
                        }
                        break;
                    case 22:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "NUMERO ENTERO",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 23:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 24;
                        }
                        else {
                            estadoActual = 26;
                        }
                        break;
                    case 24:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]))
                        {
                            lexema += caracterActual;
                            estadoActual = 24;
                        }
                        else {
                            estadoActual = 25;
                        }
                        break;
                    case 25:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "NUMERO DECIMAL",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 26:
                        //ERROR
                        devolverPuntero();
                        continuarAnalisis = false;
                        Causa = "Se esperaba un digito y recibió " + caracterActual + ".";
                        Falla = "Decimal mal formado.";
                        Solucion = "Asegurese que luego del separador decimal exista un digito para formar un decimal";

                        //Reportando el error
                        ManejadorErrores.obtenerManejadorErrores().agregarError(
                            formarError(lexema, Causa, Falla, Solucion));

                        componenteLexico = ComponenteLexico.Crear(lexema + "0", "ERROR DECIMAL",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        componenteLexico.tipo = TipoComponenteLexico.DUMMY;
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 27:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 28;
                        }
                        else {
                            estadoActual = 29;
                        }
                        break;
                    case 28:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MAYOR O IGUAL QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 29:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MAYOR QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 30:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 31;
                        }
                        else if (">".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 32;
                        }
                        else {
                            estadoActual = 33;
                        }
                        break;
                    case 31:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MENOR O IGUAL QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 32:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "DIFERENTE QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 33:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "MENOR QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 34:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "IGUAL QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 35:
                        leerSiguienteCaracter();
                        if ("=".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 36;
                        }
                        else {
                            estadoActual = 37;
                        }
                        break;
                    case 36:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "DIFERENTE QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 37:
                        //ERROR
                        devolverPuntero();
                        continuarAnalisis = false;
                        Causa = "Se esperaba un igual y recibió " + caracterActual + ".";
                        Falla = "Diferente que mal formado.";
                        Solucion = "Asegurese que luego de ! exista un igual (=) para formar un Diferente que";

                        //Reportando el error
                        ManejadorErrores.obtenerManejadorErrores().agregarError(
                            formarError(lexema,Causa,Falla,Solucion));

                        componenteLexico = ComponenteLexico.Crear(lexema+"=", "DIFERENTE QUE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        componenteLexico.tipo = TipoComponenteLexico.DUMMY;
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        
                        break;
                    case 38:
                        leerSiguienteCaracter();
                        if ("N".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 39;
                        }
                        else if ("S".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 42;
                        }

                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) 
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 43;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 39:
                        leerSiguienteCaracter();
                        if ("D".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 40;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 43;
                        }
                        else {
                            estadoActual = 8;
                        }
                        break;
                    case 40:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                           || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 43;
                        }
                        else {
                            estadoActual = 41;
                        }                   
                        break;
                    case 41:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "CONECTOR Y",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 42:
                        leerSiguienteCaracter();
                        if ("C".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 45;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 43;
                        }
                        else {
                            estadoActual = 8;
                        }
                        break;
                    case 43:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 43;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 45:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 43;
                        }
                        else
                        {
                            estadoActual = 46;
                        }
                        break;
                    case 46:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "ASCENDENTE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 47:
                        leerSiguienteCaracter();
                        if ("R".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 48;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 51;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 48:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                           || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 51;
                        }
                        else
                        {
                            estadoActual = 49;
                        }
                        break;
                    case 49:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "CONECTOR OR",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        TablaMaestro.obtenerTablaMaestro().agregarElemento(componenteLexico);
                        break;
                    case 51:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                           || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 51;
                        }
                        else {
                            estadoActual = 8;
                        }
                        break;
                    case 53:
                        leerSiguienteCaracter();
                        if ("E".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 56;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 54;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 54:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                           || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 54;
                        }
                        else {
                            estadoActual = 8;
                        }
                        break;
                    case 56:
                        leerSiguienteCaracter();
                        if ("S".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 57;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 54;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 57:
                        leerSiguienteCaracter();
                        if ("C".Equals(caracterActual.ToUpper()))
                        {
                            lexema += caracterActual;
                            estadoActual = 58;
                        }
                        else if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0]) || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 54;
                        }
                        else
                        {
                            estadoActual = 8;
                        }
                        break;
                    case 58:
                        leerSiguienteCaracter();
                        if (Char.IsDigit(caracterActual.ToCharArray()[0]) || Char.IsLetter(caracterActual.ToCharArray()[0])
                            || "_".Equals(caracterActual))
                        {
                            lexema += caracterActual;
                            estadoActual = 54;
                        }
                        else {
                            estadoActual = 59;
                        }
                        break;
                    case 59:
                        devolverPuntero();
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "DESCENDENTE",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;
                    case 61:
                        continuarAnalisis = false;
                        componenteLexico = ComponenteLexico.Crear(lexema, "FIN DE ARCHIVO",
                            numeroLineaActual, puntero - lexema.Length, puntero - 1);
                        break;
                    case 63:
                        cargarNuevaLinea();
                        estadoActual = 0;
                        break;
                    case 62:
                        
                        //ERROR STOPPER
                        devolverPuntero();
                        
                        String CausaStopper = "Causa: caracter no soportado por el lenguaje:  " + caracterActual + ".\n";
                        String FallaStopper = "Falla: no se reconoce el simbolo ingresado.\n";
                        String SolucionStopper = "Solución: asegurese de utilizar solo los simbolos permitidos por el lenguaje";

                        //Reportando el error
                        ManejadorErrores.obtenerManejadorErrores().agregarError(
                            formarError(caracterActual, CausaStopper, FallaStopper, SolucionStopper));

                        throw new Exception("Se ha presentado un error léxico tipo stopper, que impide al manejador de errores " +
                            "recuperarse, por favor verifique. \n\n" + CausaStopper+FallaStopper+SolucionStopper);
                }

                
            }
            return componenteLexico;

        }

        private Error formarError(String Lexema, String Causa, String Falla, String Solucion) {
            return Error.Crear(Lexema, "Error", numeroLineaActual, puntero - Lexema.Length, puntero - 1, 
                Causa, Falla, Solucion, TipoError.LEXICO);
        }

    }
}


