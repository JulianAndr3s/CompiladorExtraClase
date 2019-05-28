namespace LecturaDeTextos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonPorArchivo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPorConsola = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPorConsola = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCargarArchivo = new System.Windows.Forms.Button();
            this.textBoxPorArchivo = new System.Windows.Forms.TextBox();
            this.buttonCargarConsola = new System.Windows.Forms.Button();
            this.textBoxCarga = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonBorrarCache = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablaDummyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDummyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPorArchivo
            // 
            this.buttonPorArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPorArchivo.Location = new System.Drawing.Point(779, 19);
            this.buttonPorArchivo.Name = "buttonPorArchivo";
            this.buttonPorArchivo.Size = new System.Drawing.Size(84, 35);
            this.buttonPorArchivo.TabIndex = 2;
            this.buttonPorArchivo.Text = "Archivo";
            this.buttonPorArchivo.UseVisualStyleBackColor = true;
            this.buttonPorArchivo.Click += new System.EventHandler(this.buttonPorArchivo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.buttonPorConsola);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonPorArchivo);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(57, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elegir Entrada";
            // 
            // buttonPorConsola
            // 
            this.buttonPorConsola.BackColor = System.Drawing.Color.Transparent;
            this.buttonPorConsola.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPorConsola.Location = new System.Drawing.Point(675, 19);
            this.buttonPorConsola.Name = "buttonPorConsola";
            this.buttonPorConsola.Size = new System.Drawing.Size(84, 35);
            this.buttonPorConsola.TabIndex = 4;
            this.buttonPorConsola.Text = "Consola";
            this.buttonPorConsola.UseVisualStyleBackColor = false;
            this.buttonPorConsola.Click += new System.EventHandler(this.buttonPorConsola_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(44, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elige la opción de carga: ";
            // 
            // textBoxPorConsola
            // 
            this.textBoxPorConsola.Location = new System.Drawing.Point(34, 28);
            this.textBoxPorConsola.Multiline = true;
            this.textBoxPorConsola.Name = "textBoxPorConsola";
            this.textBoxPorConsola.Size = new System.Drawing.Size(366, 101);
            this.textBoxPorConsola.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCargarArchivo);
            this.groupBox2.Controls.Add(this.textBoxPorArchivo);
            this.groupBox2.Controls.Add(this.buttonCargarConsola);
            this.groupBox2.Controls.Add(this.textBoxPorConsola);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(57, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 301);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generar Entrada";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(507, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 92);
            this.button1.TabIndex = 8;
            this.button1.Text = "Analisis";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCargarArchivo
            // 
            this.buttonCargarArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCargarArchivo.Location = new System.Drawing.Point(181, 252);
            this.buttonCargarArchivo.Name = "buttonCargarArchivo";
            this.buttonCargarArchivo.Size = new System.Drawing.Size(84, 35);
            this.buttonCargarArchivo.TabIndex = 7;
            this.buttonCargarArchivo.Text = "Cargar Archivo";
            this.buttonCargarArchivo.UseVisualStyleBackColor = true;
            this.buttonCargarArchivo.Click += new System.EventHandler(this.buttonCargarArchivo_Click);
            // 
            // textBoxPorArchivo
            // 
            this.textBoxPorArchivo.Location = new System.Drawing.Point(34, 176);
            this.textBoxPorArchivo.Multiline = true;
            this.textBoxPorArchivo.Name = "textBoxPorArchivo";
            this.textBoxPorArchivo.Size = new System.Drawing.Size(366, 70);
            this.textBoxPorArchivo.TabIndex = 6;
            // 
            // buttonCargarConsola
            // 
            this.buttonCargarConsola.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCargarConsola.Location = new System.Drawing.Point(181, 135);
            this.buttonCargarConsola.Name = "buttonCargarConsola";
            this.buttonCargarConsola.Size = new System.Drawing.Size(84, 35);
            this.buttonCargarConsola.TabIndex = 5;
            this.buttonCargarConsola.Text = "Cargar Consola";
            this.buttonCargarConsola.UseVisualStyleBackColor = true;
            this.buttonCargarConsola.Click += new System.EventHandler(this.buttonCargarConsola_Click);
            // 
            // textBoxCarga
            // 
            this.textBoxCarga.Location = new System.Drawing.Point(49, 21);
            this.textBoxCarga.Multiline = true;
            this.textBoxCarga.Name = "textBoxCarga";
            this.textBoxCarga.Size = new System.Drawing.Size(366, 94);
            this.textBoxCarga.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCarga);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(57, 443);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 129);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entrada Cargada";
            // 
            // buttonBorrarCache
            // 
            this.buttonBorrarCache.Location = new System.Drawing.Point(244, 578);
            this.buttonBorrarCache.Name = "buttonBorrarCache";
            this.buttonBorrarCache.Size = new System.Drawing.Size(84, 35);
            this.buttonBorrarCache.TabIndex = 8;
            this.buttonBorrarCache.Text = "Borrar Cache";
            this.buttonBorrarCache.UseVisualStyleBackColor = true;
            this.buttonBorrarCache.Click += new System.EventHandler(this.buttonBorrarCache_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(321, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Entrada Cargada";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(575, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 460);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TablaAnalisis";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tabla Errores";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(19, 272);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView2.Size = new System.Drawing.Size(335, 172);
            this.dataGridView2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Lexema,
            this.Categoria,
            this.Linea,
            this.PosIni,
            this.PosFin,
            this.Tipo});
            this.dataGridView1.Location = new System.Drawing.Point(19, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.Size = new System.Drawing.Size(335, 192);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            this.Lexema.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // PosIni
            // 
            this.PosIni.HeaderText = "PosIni";
            this.PosIni.Name = "PosIni";
            this.PosIni.ReadOnly = true;
            // 
            // PosFin
            // 
            this.PosFin.HeaderText = "PosFin";
            this.PosFin.Name = "PosFin";
            this.PosFin.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // tablaDummyBindingSource
            // 
            this.tablaDummyBindingSource.DataSource = typeof(LecturaDeTextos.Transversal.TablaDummy);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(957, 621);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBorrarCache);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDummyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
      
        private System.Windows.Forms.Button buttonPorArchivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPorConsola;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPorConsola;
        private System.Windows.Forms.Button buttonCargarArchivo;
        private System.Windows.Forms.TextBox textBoxPorArchivo;
        private System.Windows.Forms.Button buttonCargarConsola;
        private System.Windows.Forms.TextBox textBoxCarga;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonBorrarCache;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tablaDummyBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
    }
}

