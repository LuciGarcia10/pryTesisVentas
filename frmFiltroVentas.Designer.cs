namespace pryTesisVentas
{
    partial class frmFiltroVentas
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblResetearNombre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResetearCategoria = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnResetearTodo = new System.Windows.Forms.Button();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.btnEstemes = new System.Windows.Forms.Button();
            this.btnEstasemana = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblResetearFecha = new System.Windows.Forms.Label();
            this.lblRangoFecha = new System.Windows.Forms.Label();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(13, 354);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(135, 20);
            this.lblNombre.TabIndex = 72;
            this.lblNombre.Text = "Elegir el nombre...";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(9, 345);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(370, 36);
            this.txtNombre.TabIndex = 71;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblResetearNombre
            // 
            this.lblResetearNombre.AutoSize = true;
            this.lblResetearNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNombre.Location = new System.Drawing.Point(285, 304);
            this.lblResetearNombre.Name = "lblResetearNombre";
            this.lblResetearNombre.Size = new System.Drawing.Size(94, 28);
            this.lblResetearNombre.TabIndex = 70;
            this.lblResetearNombre.Text = "Resetear";
            this.lblResetearNombre.Click += new System.EventHandler(this.lblResetearNombre_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 28);
            this.label5.TabIndex = 69;
            this.label5.Text = "Nombre";
            // 
            // lblResetearCategoria
            // 
            this.lblResetearCategoria.AutoSize = true;
            this.lblResetearCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearCategoria.Location = new System.Drawing.Point(285, 214);
            this.lblResetearCategoria.Name = "lblResetearCategoria";
            this.lblResetearCategoria.Size = new System.Drawing.Size(94, 28);
            this.lblResetearCategoria.TabIndex = 68;
            this.lblResetearCategoria.Text = "Resetear";
            this.lblResetearCategoria.Click += new System.EventHandler(this.lblResetearCategoria_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 28);
            this.label3.TabIndex = 67;
            this.label3.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Salud",
            "Belleza",
            "Cuidado Personal",
            "Medicamento Venta Libre",
            "Medicamento con Receta"});
            this.cmbCategoria.Location = new System.Drawing.Point(7, 252);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(372, 28);
            this.cmbCategoria.TabIndex = 66;
            this.cmbCategoria.Text = "Elegir categoria...";
            // 
            // btnResetearTodo
            // 
            this.btnResetearTodo.BackColor = System.Drawing.Color.LightCyan;
            this.btnResetearTodo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetearTodo.ForeColor = System.Drawing.Color.Black;
            this.btnResetearTodo.Location = new System.Drawing.Point(193, 392);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(157, 55);
            this.btnResetearTodo.TabIndex = 65;
            this.btnResetearTodo.Text = "Resetear todo";
            this.btnResetearTodo.UseVisualStyleBackColor = false;
            this.btnResetearTodo.Click += new System.EventHandler(this.btnResetearTodo_Click);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.Teal;
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(14, 392);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(156, 55);
            this.btnAplicarFiltros.TabIndex = 64;
            this.btnAplicarFiltros.Text = "Aplicar Filtros";
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // btnEstemes
            // 
            this.btnEstemes.Location = new System.Drawing.Point(256, 150);
            this.btnEstemes.Name = "btnEstemes";
            this.btnEstemes.Size = new System.Drawing.Size(108, 51);
            this.btnEstemes.TabIndex = 63;
            this.btnEstemes.Text = "Este mes";
            this.btnEstemes.UseVisualStyleBackColor = true;
            this.btnEstemes.Click += new System.EventHandler(this.btnEstemes_Click);
            // 
            // btnEstasemana
            // 
            this.btnEstasemana.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstasemana.Location = new System.Drawing.Point(130, 150);
            this.btnEstasemana.Name = "btnEstasemana";
            this.btnEstasemana.Size = new System.Drawing.Size(120, 51);
            this.btnEstasemana.TabIndex = 62;
            this.btnEstasemana.Text = "Esta semana";
            this.btnEstasemana.UseVisualStyleBackColor = true;
            this.btnEstasemana.Click += new System.EventHandler(this.btnEstasemana_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.Location = new System.Drawing.Point(7, 150);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(108, 51);
            this.btnHoy.TabIndex = 61;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(209, 81);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 20);
            this.lblHasta.TabIndex = 60;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(3, 82);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 20);
            this.lblDesde.TabIndex = 59;
            this.lblDesde.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(193, 105);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(186, 26);
            this.dtpHasta.TabIndex = 58;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(7, 105);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(175, 26);
            this.dtpDesde.TabIndex = 57;
            // 
            // lblResetearFecha
            // 
            this.lblResetearFecha.AutoSize = true;
            this.lblResetearFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearFecha.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearFecha.Location = new System.Drawing.Point(270, 44);
            this.lblResetearFecha.Name = "lblResetearFecha";
            this.lblResetearFecha.Size = new System.Drawing.Size(94, 28);
            this.lblResetearFecha.TabIndex = 56;
            this.lblResetearFecha.Text = "Resetear";
            this.lblResetearFecha.Click += new System.EventHandler(this.lblResetearFecha_Click);
            // 
            // lblRangoFecha
            // 
            this.lblRangoFecha.AutoSize = true;
            this.lblRangoFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangoFecha.Location = new System.Drawing.Point(2, 44);
            this.lblRangoFecha.Name = "lblRangoFecha";
            this.lblRangoFecha.Size = new System.Drawing.Size(161, 28);
            this.lblRangoFecha.TabIndex = 55;
            this.lblRangoFecha.Text = "Rango de Fecha";
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Location = new System.Drawing.Point(3, 9);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(80, 20);
            this.lblFiltrarPor.TabIndex = 54;
            this.lblFiltrarPor.Text = "Filtrar por:";
            // 
            // frmFiltroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 458);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblResetearNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResetearCategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnResetearTodo);
            this.Controls.Add(this.btnAplicarFiltros);
            this.Controls.Add(this.btnEstemes);
            this.Controls.Add(this.btnEstasemana);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblResetearFecha);
            this.Controls.Add(this.lblRangoFecha);
            this.Controls.Add(this.lblFiltrarPor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFiltroVentas";
            this.Text = "frmFiltroVentas";
            this.Load += new System.EventHandler(this.frmFiltroVentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblResetearNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResetearCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnResetearTodo;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.Button btnEstemes;
        private System.Windows.Forms.Button btnEstasemana;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblResetearFecha;
        private System.Windows.Forms.Label lblRangoFecha;
        private System.Windows.Forms.Label lblFiltrarPor;
    }
}