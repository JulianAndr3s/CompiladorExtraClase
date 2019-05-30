using LecturaDeTextos.AnalizadorLexico;
using LecturaDeTextos.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace LecturaDeTextos.AnalizadorSintactico
{
    class AnalisisSintactico
    {
        private bool depurar = false;
        private AnalisisLexico analisisLexico = new AnalisisLexico();
        private ComponenteLexico componenteLexico;
        private String cadenaCategorias = "";
        private String cadenaLemexas = "";

        public void analizar() {
            try {
                depurar = true;
                depurarGramatica("Iniciando analisis sintactico");
                cadenaCategorias = "";
                cadenaLemexas = "";
            

                componenteLexico = analisisLexico.analizar();
                Gramatica();
            
            

            if (Transversal.ManejadorErrores.obtenerManejadorErrores().hayErrores())
            {
                MessageBox.Show("El analisis ha terminado. El programa está mal escrito. Verifique el detalle");
            }
            else {
                if ("FIN DE ARCHIVO".Equals(componenteLexico.Categoria))
                {
                    MessageBox.Show("El programa está bien escrito.");
                }
                else {
                    MessageBox.Show("Aunque está bien escrita, faltaron componentes por evaluar.");
                }
            }
            }
            catch (Exception excepcion){
                MessageBox.Show(excepcion.Message);
            }

            depurarGramatica("Finalizando analisis sintactico");
        }

        // <Gramatica> := SELECT <Campos> FROM <Tablas> | SELECT <Campos> FROM <Tablas> <Opcionales>

        private void Gramatica() {
            depurarGramatica("Iniciando evaluación regla <Gramatica>");

            pedirComponente("SELECT");
            Campos();
            pedirComponente("FROM");
            Tablas();

            if ("WHERE".Equals(componenteLexico.Categoria) || "ORDER".Equals(componenteLexico.Categoria))
            {
               Opcionales();
            }

            depurarGramatica("Finalizando evaluación regla <Gramatica>");
        }

        // <Opcionales> := WHERE <Condiciones> | ORDER BY <Ordenadores> | WHERE <Condiciones> ORDER BY <Ordenadores>
        
        private void Opcionales()
        {
            depurarGramatica("Iniciando evaluación regla <Opcionales>");

            if ("WHERE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("WHERE");
                Condiciones();
                if ("ORDER".Equals(componenteLexico.Categoria))
                {
                    pedirComponente("ORDER");
                    pedirComponente("BY");
                    Ordenadores();
                }
            }
            else if ("ORDER".Equals(componenteLexico.Categoria))
            {
                pedirComponente("ORDER");
                pedirComponente("BY");
                Ordenadores();
            }

            depurarGramatica("Finalizando evaluación regla <Opcionales>");
        }

        // <Campos> := CAMPO | CAMPO SEPARADOR <Campos>

        private void Campos()
        {
            depurarGramatica("Iniciando evaluación regla <Campos>");

            pedirComponente("CAMPO");
            if ("SEPARADOR".Equals(componenteLexico.Categoria))
            {
                pedirComponente("SEPARADOR");
                Campos();
            }

            depurarGramatica("Finalizando evaluación regla <Campos>");
        }

        // <Tablas> := TABLA | TABLA SEPARADOR <Tablas>

        private void Tablas()
        {
            depurarGramatica("Iniciando evaluación regla <Tablas>");

            pedirComponente("TABLA");
            if ("SEPARADOR".Equals(componenteLexico.Categoria))
            {
                pedirComponente("SEPARADOR");
                Tablas();
            }

            depurarGramatica("Finalizando evaluación regla <Tablas>");
        }

        // <Condiciones> := <Operando> <Operador> <Operando> | <Operando> <Operador> <Operando> <Conector> <Condiciones>

        private void Condiciones()
        {
            depurarGramatica("Iniciando evaluación regla <Condiciones>");

            Operando();
            Operador();
            Operando();

            if ("CONECTOR Y".Equals(componenteLexico.Categoria) || "CONECTOR O".Equals(componenteLexico.Categoria))
            {
                Conector();
                Condiciones();
            }

            depurarGramatica("Finalizando evaluación regla <Condiciones>");
        }

        // <Operando> := CAMPO | LITERAL | <Numero>

        private void Operando()
        {
            depurarGramatica("Iniciando evaluación regla <Operando>");
            if ("CAMPO".Equals(componenteLexico.Categoria))
            {
                pedirComponente("CAMPO");
            }
            else if ("LITERAL".Equals(componenteLexico.Categoria))
            {
                pedirComponente("LITERAL");
            }
            else if ("NUMERO ENTERO".Equals(componenteLexico.Categoria) || "NUMERO DECIMAL".Equals(componenteLexico.Categoria))
            {
                Numero();
            }
            else {
                String causa = "Se esperaba un CAMPO, LITERAL o NUMERO y recibi " + componenteLexico.Categoria;
                String falla = "Problemas en la validación de la gramatica que no la hace valida.";
                String solucion = "Asegure que se tenga un CAMPO, LITERAL o NUMERO en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componenteLexico.Lexema, causa, falla, solucion));
                throw new Exception("No es posible continuar con el análisis sintáctico. Verifique y solucione los errores presentados.");

            }

            depurarGramatica("Finalizando evaluación regla <Operando>");
        }

        // <Numero> := NUMERO ENTERO | NUMERO DECIMAL

        private void Numero()
        {
            depurarGramatica("Iniciando evaluación regla <Numero>");
            if ("NUMERO ENTERO".Equals(componenteLexico.Categoria))
            {
                pedirComponente("NUMERO ENTERO");
            }
            else if ("NUMERO DECIMAL".Equals(componenteLexico.Categoria))
            {
                pedirComponente("NUMERO DECIMAL");
            }

            depurarGramatica("Finalizando evaluación regla <Numero>");
        }

        // <Operador> := MAYOR QUE | MENOR QUE | IGUAL QUE | MAYOR O IGUAL QUE | MENOR O IGUAL QUE | DIFERENTE QUE

        private void Operador()
        {
            depurarGramatica("Iniciando evaluación regla <Operador>");

            if ("MAYOR QUE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("MAYOR QUE");
            }
            else if ("MENOR QUE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("MENOR QUE");
            }
            else if ("IGUAL QUE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("IGUAL QUE");
            }
            else if ("MAYOR O IGUAL QUE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("MAYOR O IGUAL QUE");
            }
            else if ("MENOR O IGUAL QUE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("MENOR O IGUAL QUE");
            }
            else if ("DIFERENTE QUE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("DIFERENTE QUE");
            }
            else
            {
                // Gestionar Error
                String causa = "Se esperaba un operador y recibi " + componenteLexico.Categoria;
                String falla = "Problemas en la validación de la gramatica que no la hace valida.";
                String solucion = "Asegure que se tenga un operador en el lugar donde se ha presentado el error";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componenteLexico.Lexema, causa, falla, solucion));
                throw new Exception("No es posible continuar con el análisis sintáctico. Verifique y solucione los errores presentados.");
            }

            depurarGramatica("Finalizando evaluación regla <Operador>");
        }

        // <Conector> := CONECTOR Y | CONECTOR O

        private void Conector()
        {
            depurarGramatica("Iniciando evaluación regla <Conector>");

            if ("CONECTOR Y".Equals(componenteLexico.Categoria))
            {
                pedirComponente("CONECTOR Y");
            }
            else if ("CONECTOR O".Equals(componenteLexico.Categoria))
            {
                pedirComponente("CONECTOR O");
            }

            depurarGramatica("Finalizando evaluación regla <Conector>");
        }

        // <Ordenadores> := <Campos> | <Campos> <Criterio> | <Indices> | <Indices> <Criterio>

        private void Ordenadores()
        {
            depurarGramatica("Iniciando evaluación regla <Ordenadores>");

            if ("CAMPO".Equals(componenteLexico.Categoria))
            {
                pedirComponente("CAMPO");
                if ("ASCENDENTE".Equals(componenteLexico.Categoria) || "DESCENDENTE".Equals(componenteLexico.Categoria)) {
                    Criterio();
                }
            }
            

            else if ("NUMERO ENTERO".Equals(componenteLexico.Categoria))
            {
                Indices();
                if ("ASCENDENTE".Equals(componenteLexico.Categoria) || "DESCENDENTE".Equals(componenteLexico.Categoria))
                {
                    Criterio();
                }
            }

            depurarGramatica("Finalizando evaluación regla <Ordenadores>");        
        }

        // <Indices> := NUMERO ENTERO | NUMERO ENTERO SEPARADOR <Indices>

        private void Indices()
        {
            depurarGramatica("Iniciando evaluación regla <Indices>");

            pedirComponente("NUMERO ENTERO");

            if ("SEPARADOR".Equals(componenteLexico.Categoria))
            {
                pedirComponente("SEPARADOR");
                Indices();
            }

            depurarGramatica("Finalizando evaluación regla <Indices>");
        }

        // <Criterio> := ASCENDENTE | DESCENDENTE | ASCENDENTE SEPARADOR <Ordenadores> | DESCENDENTE SEPARADOR <Ordenadores>

        private void Criterio()
        {
            depurarGramatica("Iniciando evaluación regla <Criterio>");

            if ("ASCENDENTE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("ASCENDENTE");
                if ("SEPARADOR".Equals(componenteLexico.Categoria))
                {
                    pedirComponente("SEPARADOR");
                    Ordenadores();
                }
            }
            else if ("DESCENDENTE".Equals(componenteLexico.Categoria))
            {
                pedirComponente("DESCENDENTE");
                if ("SEPARADOR".Equals(componenteLexico.Categoria))
                {
                    pedirComponente("SEPARADOR");
                    Ordenadores();
                }
            }

            depurarGramatica("Finalizando evaluación regla <Criterio>");
        }

        private void depurarGramatica(String mensaje) {
            if (depurar) {
                MessageBox.Show(mensaje);
            }
        }

        private void imprimirDerivacion() {
            cadenaCategorias = cadenaCategorias + "->" + componenteLexico.Categoria;
            cadenaLemexas = cadenaLemexas + "->" + componenteLexico.Lexema;
            depurarGramatica(cadenaCategorias + "\n" + cadenaLemexas);

        }

        private void pedirComponente(String categoriaValida) {
            if (componenteLexico.Categoria.Equals(categoriaValida))
            {
                imprimirDerivacion();
                componenteLexico = analisisLexico.analizar();
            }
            else {
                //Errores SQL

                String causa = "Se esperaba " + categoriaValida +" y recibí " + componenteLexico.Categoria;
                String falla = "Problemas en la validacion de la gramatica que no la hace valida";
                String solucion = "Asegure que se tenga " + categoriaValida + " en el lugar donde se ha presentado el problema";
                ManejadorErrores.obtenerManejadorErrores().agregarError(formarError(componenteLexico.Lexema,causa,falla,solucion));
                
            }
        }

        private Error formarError(String Lexema, String Causa, String Falla, String Solucion)
        {
            return Error.Crear(Lexema, "Error", componenteLexico.numeroLinea, componenteLexico.posicionInicial, 
                componenteLexico.posicionFinal, Causa, Falla, Solucion, TipoError.SINTACTICO);
        }
    }
}
