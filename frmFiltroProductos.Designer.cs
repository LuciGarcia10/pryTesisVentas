namespace pryTesisVentas
{
    partial class frmFiltroProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.lblRangoFecha = new System.Windows.Forms.Label();
            this.lblResetearFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnEstasemana = new System.Windows.Forms.Button();
            this.btnEstemes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResetearCategoria = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResetearNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnResetearTodo = new System.Windows.Forms.Button();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(13, 89);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(163, 29);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(186, 89);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(172, 29);
            this.dtpHasta.TabIndex = 1;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Salud",
            "Belleza",
            "Cuidado Personal",
            "Medicamento Venta Libre",
            "Medicamento con Receta"});
            this.cmbCategoria.Location = new System.Drawing.Point(16, 211);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(338, 29);
            this.cmbCategoria.TabIndex = 2;
            this.cmbCategoria.Text = "Elegir categoria...";
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrarPor.Location = new System.Drawing.Point(8, 9);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(82, 21);
            this.lblFiltrarPor.TabIndex = 4;
            this.lblFiltrarPor.Text = "Filtrar por:";
            // 
            // lblRangoFecha
            // 
            this.lblRangoFecha.AutoSize = true;
            this.lblRangoFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangoFecha.Location = new System.Drawing.Point(6, 37);
            this.lblRangoFecha.Name = "lblRangoFecha";
            this.lblRangoFecha.Size = new System.Drawing.Size(161, 28);
            this.lblRangoFecha.TabIndex = 5;
            this.lblRangoFecha.Text = "Rango de Fecha";
            // 
            // lblResetearFecha
            // 
            this.lblResetearFecha.AutoSize = true;
            this.lblResetearFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearFecha.Location = new System.Drawing.Point(289, 37);
            this.lblResetearFecha.Name = "lblResetearFecha";
            this.lblResetearFecha.Size = new System.Drawing.Size(94, 28);
            this.lblResetearFecha.TabIndex = 6;
            this.lblResetearFecha.Text = "Resetear";
            this.lblResetearFecha.Click += new System.EventHandler(this.lblResetearFecha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta";
            // 
            // btnHoy
            // 
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.Location = new System.Drawing.Point(11, 117);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(108, 54);
            this.btnHoy.TabIndex = 9;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnEstasemana
            // 
            this.btnEstasemana.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstasemana.Location = new System.Drawing.Point(123, 117);
            this.btnEstasemana.Name = "btnEstasemana";
            this.btnEstasemana.Size = new System.Drawing.Size(120, 54);
            this.btnEstasemana.TabIndex = 10;
            this.btnEstasemana.Text = "Esta semana";
            this.btnEstasemana.UseVisualStyleBackColor = true;
            this.btnEstasemana.Click += new System.EventHandler(this.btnEstasemana_Click);
            // 
            // btnEstemes
            // 
            this.btnEstemes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstemes.Location = new System.Drawing.Point(248, 117);
            this.btnEstemes.Name = "btnEstemes";
            this.btnEstemes.Size = new System.Drawing.Size(108, 54);
            this.btnEstemes.TabIndex = 11;
            this.btnEstemes.Text = "Este mes";
            this.btnEstemes.UseVisualStyleBackColor = true;
            this.btnEstemes.Click += new System.EventHandler(this.btnEstemes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Categoria";
            // 
            // lblResetearCategoria
            // 
            this.lblResetearCategoria.AutoSize = true;
            this.lblResetearCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearCategoria.Location = new System.Drawing.Point(285, 180);
            this.lblResetearCategoria.Name = "lblResetearCategoria";
            this.lblResetearCategoria.Size = new System.Drawing.Size(94, 28);
            this.lblResetearCategoria.TabIndex = 13;
            this.lblResetearCategoria.Text = "Resetear";
            this.lblResetearCategoria.Click += new System.EventHandler(this.lblResetearCategoria_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nombre";
            // 
            // lblResetearNombre
            // 
            this.lblResetearNombre.AutoSize = true;
            this.lblResetearNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNombre.Location = new System.Drawing.Point(285, 248);
            this.lblResetearNombre.Name = "lblResetearNombre";
            this.lblResetearNombre.Size = new System.Drawing.Size(94, 28);
            this.lblResetearNombre.TabIndex = 15;
            this.lblResetearNombre.Text = "Resetear";
            this.lblResetearNombre.Click += new System.EventHandler(this.lblResetearNombre_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(16, 270);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(343, 31);
            this.txtNombre.TabIndex = 16;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(28, 279);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(133, 21);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Elegir el nombre...";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // btnResetearTodo
            // 
            this.btnResetearTodo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnResetearTodo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetearTodo.Location = new System.Drawing.Point(17, 322);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(163, 41);
            this.btnResetearTodo.TabIndex = 18;
            this.btnResetearTodo.Text = "Resetear todo";
            this.btnResetearTodo.UseVisualStyleBackColor = false;
            this.btnResetearTodo.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.Teal;
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(186, 322);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(173, 41);
            this.btnAplicarFiltros.TabIndex = 19;
            this.btnAplicarFiltros.Text = "Aplicar Filtros";
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // pctCerrar
            // 
            this.pctCerrar.Image = global::pryTesisVentas.Properties.Resources.cerrar;
            this.pctCerrar.Location = new System.Drawing.Point(332, 7);
            this.pctCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(32, 28);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCerrar.TabIndex = 55;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // frmFiltroProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 384);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.btnAplicarFiltros);
            this.Controls.Add(this.btnResetearTodo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblResetearNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResetearCategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEstemes);
            this.Controls.Add(this.btnEstasemana);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResetearFecha);
            this.Controls.Add(this.lblRangoFecha);
            this.Controls.Add(this.lblFiltrarPor);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFiltroProductos";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFiltro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.Label lblRangoFecha;
        private System.Windows.Forms.Label lblResetearFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnEstasemana;
        private System.Windows.Forms.Button btnEstemes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResetearCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResetearNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnResetearTodo;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.PictureBox pctCerrar;
    }
}