namespace pryTesisVentas
{
    partial class frmFiltroPedidos
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
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.lblRangoFecha = new System.Windows.Forms.Label();
            this.lblResetearFecha = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnEstemes = new System.Windows.Forms.Button();
            this.btnEstasemana = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.lblNdePedido = new System.Windows.Forms.Label();
            this.lblResetearNumero = new System.Windows.Forms.Label();
            this.txtIngresarNumero = new System.Windows.Forms.TextBox();
            this.lblIngresarNumero = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblResetearNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEscribirNombre = new System.Windows.Forms.Label();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.btnResetearTodo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Location = new System.Drawing.Point(2, 9);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(80, 20);
            this.lblFiltrarPor.TabIndex = 5;
            this.lblFiltrarPor.Text = "Filtrar por:";
            // 
            // lblRangoFecha
            // 
            this.lblRangoFecha.AutoSize = true;
            this.lblRangoFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangoFecha.Location = new System.Drawing.Point(1, 44);
            this.lblRangoFecha.Name = "lblRangoFecha";
            this.lblRangoFecha.Size = new System.Drawing.Size(161, 28);
            this.lblRangoFecha.TabIndex = 6;
            this.lblRangoFecha.Text = "Rango de Fecha";
            // 
            // lblResetearFecha
            // 
            this.lblResetearFecha.AutoSize = true;
            this.lblResetearFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearFecha.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearFecha.Location = new System.Drawing.Point(269, 44);
            this.lblResetearFecha.Name = "lblResetearFecha";
            this.lblResetearFecha.Size = new System.Drawing.Size(94, 28);
            this.lblResetearFecha.TabIndex = 7;
            this.lblResetearFecha.Text = "Resetear";
            this.lblResetearFecha.Click += new System.EventHandler(this.lblResetearFecha_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(208, 81);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 20);
            this.lblHasta.TabIndex = 12;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(2, 82);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 20);
            this.lblDesde.TabIndex = 11;
            this.lblDesde.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(192, 105);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(175, 26);
            this.dtpHasta.TabIndex = 10;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(6, 105);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(175, 26);
            this.dtpDesde.TabIndex = 9;
            // 
            // btnEstemes
            // 
            this.btnEstemes.Location = new System.Drawing.Point(255, 150);
            this.btnEstemes.Name = "btnEstemes";
            this.btnEstemes.Size = new System.Drawing.Size(108, 51);
            this.btnEstemes.TabIndex = 15;
            this.btnEstemes.Text = "Este mes";
            this.btnEstemes.UseVisualStyleBackColor = true;
            // 
            // btnEstasemana
            // 
            this.btnEstasemana.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstasemana.Location = new System.Drawing.Point(129, 150);
            this.btnEstasemana.Name = "btnEstasemana";
            this.btnEstasemana.Size = new System.Drawing.Size(120, 51);
            this.btnEstasemana.TabIndex = 14;
            this.btnEstasemana.Text = "Esta semana";
            this.btnEstasemana.UseVisualStyleBackColor = true;
            // 
            // btnHoy
            // 
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.Location = new System.Drawing.Point(6, 150);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(108, 51);
            this.btnHoy.TabIndex = 13;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            // 
            // lblNdePedido
            // 
            this.lblNdePedido.AutoSize = true;
            this.lblNdePedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNdePedido.Location = new System.Drawing.Point(6, 226);
            this.lblNdePedido.Name = "lblNdePedido";
            this.lblNdePedido.Size = new System.Drawing.Size(135, 28);
            this.lblNdePedido.TabIndex = 16;
            this.lblNdePedido.Text = "N° de Pedido";
            // 
            // lblResetearNumero
            // 
            this.lblResetearNumero.AutoSize = true;
            this.lblResetearNumero.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNumero.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearNumero.Location = new System.Drawing.Point(269, 226);
            this.lblResetearNumero.Name = "lblResetearNumero";
            this.lblResetearNumero.Size = new System.Drawing.Size(94, 28);
            this.lblResetearNumero.TabIndex = 17;
            this.lblResetearNumero.Text = "Resetear";
            // 
            // txtIngresarNumero
            // 
            this.txtIngresarNumero.Location = new System.Drawing.Point(6, 257);
            this.txtIngresarNumero.Multiline = true;
            this.txtIngresarNumero.Name = "txtIngresarNumero";
            this.txtIngresarNumero.Size = new System.Drawing.Size(361, 33);
            this.txtIngresarNumero.TabIndex = 18;
            this.txtIngresarNumero.TextChanged += new System.EventHandler(this.txtIngresarNumero_TextChanged);
            this.txtIngresarNumero.Enter += new System.EventHandler(this.txtIngresarNumero_Enter);
            this.txtIngresarNumero.Leave += new System.EventHandler(this.txtIngresarNumero_Leave);
            // 
            // lblIngresarNumero
            // 
            this.lblIngresarNumero.AutoSize = true;
            this.lblIngresarNumero.Location = new System.Drawing.Point(8, 263);
            this.lblIngresarNumero.Name = "lblIngresarNumero";
            this.lblIngresarNumero.Size = new System.Drawing.Size(212, 20);
            this.lblIngresarNumero.TabIndex = 19;
            this.lblIngresarNumero.Text = "Ingresar numero de pedido...";
            this.lblIngresarNumero.Click += new System.EventHandler(this.lblIngresarNumero_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(6, 312);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(89, 28);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Nombre";
            // 
            // lblResetearNombre
            // 
            this.lblResetearNombre.AutoSize = true;
            this.lblResetearNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNombre.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearNombre.Location = new System.Drawing.Point(269, 312);
            this.lblResetearNombre.Name = "lblResetearNombre";
            this.lblResetearNombre.Size = new System.Drawing.Size(94, 28);
            this.lblResetearNombre.TabIndex = 21;
            this.lblResetearNombre.Text = "Resetear";
            this.lblResetearNombre.Click += new System.EventHandler(this.lblResetearNombre_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 343);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(361, 33);
            this.txtNombre.TabIndex = 22;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblEscribirNombre
            // 
            this.lblEscribirNombre.AutoSize = true;
            this.lblEscribirNombre.Location = new System.Drawing.Point(9, 350);
            this.lblEscribirNombre.Name = "lblEscribirNombre";
            this.lblEscribirNombre.Size = new System.Drawing.Size(147, 20);
            this.lblEscribirNombre.TabIndex = 23;
            this.lblEscribirNombre.Text = "Escribir el nombre...";
            this.lblEscribirNombre.Click += new System.EventHandler(this.lblEscribirNombre_Click);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.Teal;
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(13, 392);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(156, 55);
            this.btnAplicarFiltros.TabIndex = 24;
            this.btnAplicarFiltros.Text = "Aplicar Filtros";
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // btnResetearTodo
            // 
            this.btnResetearTodo.BackColor = System.Drawing.Color.LightCyan;
            this.btnResetearTodo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetearTodo.ForeColor = System.Drawing.Color.Black;
            this.btnResetearTodo.Location = new System.Drawing.Point(192, 392);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(157, 55);
            this.btnResetearTodo.TabIndex = 25;
            this.btnResetearTodo.Text = "Resetear todo";
            this.btnResetearTodo.UseVisualStyleBackColor = false;
            this.btnResetearTodo.Click += new System.EventHandler(this.btnResetearTodo_Click);
            // 
            // frmFiltroPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 482);
            this.Controls.Add(this.btnResetearTodo);
            this.Controls.Add(this.btnAplicarFiltros);
            this.Controls.Add(this.lblEscribirNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblResetearNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblIngresarNumero);
            this.Controls.Add(this.txtIngresarNumero);
            this.Controls.Add(this.lblResetearNumero);
            this.Controls.Add(this.lblNdePedido);
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
            this.Name = "frmFiltroPedidos";
            this.Text = "frmFiltroPedidos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.Label lblRangoFecha;
        private System.Windows.Forms.Label lblResetearFecha;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnEstemes;
        private System.Windows.Forms.Button btnEstasemana;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Label lblNdePedido;
        private System.Windows.Forms.Label lblResetearNumero;
        private System.Windows.Forms.TextBox txtIngresarNumero;
        private System.Windows.Forms.Label lblIngresarNumero;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblResetearNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEscribirNombre;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.Button btnResetearTodo;
    }
}