//using LecturaDeTextos.Util;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LecturaDeTextos.Transversal;
using LecturaDeTextos.AnalizadorLexico;
using LecturaDeTextos.AnalizadorSintactico;

namespace LecturaDeTextos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void buttonPorConsola_Click(object sender, EventArgs e)
        {
            if (buttonPorConsola.Focused)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                textBoxPorArchivo.Hide();
                buttonCargarArchivo.Hide();
                textBoxPorConsola.Show();
                buttonCargarConsola.Show();

            }
        }


        private void buttonPorArchivo_Click(object sender, EventArgs e)
        {
            if (buttonPorArchivo.Focused)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                textBoxPorConsola.Hide();
                buttonCargarConsola.Hide();
                textBoxPorArchivo.Show();
                buttonCargarArchivo.Show();
            }
        }

        private void buttonCargarConsola_Click(object sender, EventArgs e)
        {
            textBoxCarga.Clear();
            

            if (textBoxPorConsola.Text == "")
            {
                MessageBox.Show("Por favor ingresa texto para poder cargar");
            }
            else
            {
                groupBox3.Visible = true;
                Cache cache = Cache.obtenerCache();
                cache.limpiar();
                string[] lineas32 = textBoxPorConsola.Text.Split('\r');

                

                string texto2 = "";
                foreach (string linea23 in lineas32)
                {
                    texto2 += linea23;
                }

                string[] lineas = texto2.Split('\n');
                for(int ins = 0; ins < lineas.Length; ins++)
                {
                    cache.agregarLinea(new Linea(ins+1, lineas.ElementAt(ins)));
                } 
                Linea linea;
                string texto = "";
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                int i = 1;

                using (StreamWriter outputFile = new StreamWriter(ruta + @"\TextoJulian.txt"))
                {
                    foreach (string linea2 in lineas)
                    {
                        linea = new Linea();
                        linea.Contenido = linea2;
                        linea.Numero = i;
                        texto += i + " --> " + linea.Contenido + "\r\n";
                        i++;
                        //cache.agregarLinea(linea);
                        outputFile.WriteLine(linea.Contenido);
                    }
                }
                textBoxCarga.Text = texto;
            }
        }

        private void buttonCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirBuscador = new OpenFileDialog();
            abrirBuscador.DefaultExt = "*.txt";
            abrirBuscador.Filter = "Archivo de texto |*.txt";
            abrirBuscador.Title = "Seleccione el archivo de texto";
            groupBox3.Visible = true;
            if (abrirBuscador.ShowDialog() == DialogResult.OK)
            {

                Cache cache = Cache.obtenerCache();

                string ruta = abrirBuscador.FileName;
                textBoxPorArchivo.Text = ruta;

                StreamReader sr = new StreamReader(ruta);
                string lineaActual = "";
                string leerLineaConcatenado = "";

                int n = 1;
                Linea line;

                string[] arreglo = sr.ReadToEnd().Split('\n'); // salto de linea \n

                foreach (string linea in arreglo)
                {
                    leerLineaConcatenado += linea;
                }
                arreglo = leerLineaConcatenado.Split('\r'); // retocedes carro \r

                foreach (string linea in arreglo)
                {
                    line = new Linea();
                    line.Contenido = linea;
                    line.Numero = n;
                    cache.agregarLinea(line);
                    lineaActual = lineaActual + n + "-->" + line.Contenido + Environment.NewLine;
                    n++;
                }

                textBoxCarga.Text = lineaActual;

                sr.Close();
            }
        }

        private void buttonBorrarCache_Click(object sender, EventArgs e)
        {
            
            ManejadorErrores.obtenerManejadorErrores().limpiar();

            DataTable dt = new DataTable();
            dt.Rows.Add(dt.NewRow());
            dataGridView1.DataSource = dt;
            dt.Clear();

            dataGridView2.DataSource = null;

            textBoxCarga.Clear();
            textBoxPorConsola.Clear();
            textBoxPorArchivo.Clear();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            AnalisisLexico analex = new AnalisisLexico();
            AnalisisSintactico analix = new AnalisisSintactico();
            ManejadorErrores errores = new ManejadorErrores();
            Dictionary<String, List<ComponenteLexico>> dic = new Dictionary<String, List<ComponenteLexico>>();
            try
            {
                //ComponenteLexico tmp = analex.analizar();
                analix.analizar();
                /**while (!"@EOF@".Equals(tmp.Lexema))
                {
                    dataGridView1.Rows.Add();
                    int fila = dataGridView1.Rows.Count - 1;
                    dataGridView1[0, fila].Value = fila + 1;
                    dataGridView1[1, fila].Value = tmp.Lexema;
                    dataGridView1[2, fila].Value = tmp.Categoria;
                    dataGridView1[3, fila].Value = tmp.numeroLinea;
                    dataGridView1[4, fila].Value = tmp.posicionInicial;
                    dataGridView1[5, fila].Value = tmp.posicionFinal;
                    dataGridView1[6, fila].Value = tmp.tipo;

                    //dataGridView1.DataSource = TablaSimbolos.obtenerTablaSimbolos().ObtenerTodo();
                    dataGridView2.DataSource = ManejadorErrores.obtenerManejadorErrores().ObtenerTodo();

                    tmp = analex.analizar();
                }**/
                
            }
            catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }

            

        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
