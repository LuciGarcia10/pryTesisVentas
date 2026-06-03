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

            this.lblFiltrarPor.Location = new System.Drawing.Point(1, 6);
            this.lblFiltrarPor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(53, 13);

            this.lblFiltrarPor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrarPor.Location = new System.Drawing.Point(2, 9);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(82, 21);

            this.lblFiltrarPor.TabIndex = 5;
            this.lblFiltrarPor.Text = "Filtrar por:";
            // 
            // lblRangoFecha
            // 
            this.lblRangoFecha.AutoSize = true;
            this.lblRangoFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.lblRangoFecha.Location = new System.Drawing.Point(1, 29);
            this.lblRangoFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblRangoFecha.Location = new System.Drawing.Point(1, 46);

            this.lblRangoFecha.Name = "lblRangoFecha";
            this.lblRangoFecha.Size = new System.Drawing.Size(115, 19);
            this.lblRangoFecha.TabIndex = 6;
            this.lblRangoFecha.Text = "Rango de Fecha";
            // 
            // lblResetearFecha
            // 
            this.lblResetearFecha.AutoSize = true;
            this.lblResetearFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearFecha.ForeColor = System.Drawing.Color.Teal;

            this.lblResetearFecha.Location = new System.Drawing.Point(179, 29);
            this.lblResetearFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblResetearFecha.Location = new System.Drawing.Point(269, 46);

            this.lblResetearFecha.Name = "lblResetearFecha";
            this.lblResetearFecha.Size = new System.Drawing.Size(67, 19);
            this.lblResetearFecha.TabIndex = 7;
            this.lblResetearFecha.Text = "Resetear";
            this.lblResetearFecha.Click += new System.EventHandler(this.lblResetearFecha_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;

            this.lblHasta.Location = new System.Drawing.Point(139, 53);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);

            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(208, 85);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(49, 21);

            this.lblHasta.TabIndex = 12;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;

            this.lblDesde.Location = new System.Drawing.Point(1, 53);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);

            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(2, 86);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(53, 21);

            this.lblDesde.TabIndex = 11;
            this.lblDesde.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtpHasta.Location = new System.Drawing.Point(128, 68);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(118, 20);

            this.dtpHasta.Location = new System.Drawing.Point(192, 110);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(175, 29);

            this.dtpHasta.TabIndex = 10;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtpDesde.Location = new System.Drawing.Point(4, 68);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(118, 20);

            this.dtpDesde.Location = new System.Drawing.Point(6, 110);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(175, 29);

            this.dtpDesde.TabIndex = 9;
            // 
            // btnEstemes
            // 

            this.btnEstemes.Location = new System.Drawing.Point(174, 98);
            this.btnEstemes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEstemes.Name = "btnEstemes";
            this.btnEstemes.Size = new System.Drawing.Size(72, 33);

            this.btnEstemes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstemes.Location = new System.Drawing.Point(255, 158);
            this.btnEstemes.Name = "btnEstemes";
            this.btnEstemes.Size = new System.Drawing.Size(108, 54);

            this.btnEstemes.TabIndex = 15;
            this.btnEstemes.Text = "Este mes";
            this.btnEstemes.UseVisualStyleBackColor = true;
            // 
            // btnEstasemana
            // 
            this.btnEstasemana.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.btnEstasemana.Location = new System.Drawing.Point(80, 98);
            this.btnEstasemana.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEstasemana.Name = "btnEstasemana";
            this.btnEstasemana.Size = new System.Drawing.Size(90, 33);

            this.btnEstasemana.Location = new System.Drawing.Point(129, 158);
            this.btnEstasemana.Name = "btnEstasemana";
            this.btnEstasemana.Size = new System.Drawing.Size(120, 54);

            this.btnEstasemana.TabIndex = 14;
            this.btnEstasemana.Text = "Esta semana";
            this.btnEstasemana.UseVisualStyleBackColor = true;
            // 
            // btnHoy
            // 
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.btnHoy.Location = new System.Drawing.Point(4, 98);
            this.btnHoy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(72, 33);

            this.btnHoy.Location = new System.Drawing.Point(6, 158);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(108, 54);

            this.btnHoy.TabIndex = 13;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            // 
            // lblNdePedido
            // 
            this.lblNdePedido.AutoSize = true;
            this.lblNdePedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.lblNdePedido.Location = new System.Drawing.Point(4, 147);
            this.lblNdePedido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblNdePedido.Location = new System.Drawing.Point(6, 237);

            this.lblNdePedido.Name = "lblNdePedido";
            this.lblNdePedido.Size = new System.Drawing.Size(98, 19);
            this.lblNdePedido.TabIndex = 16;
            this.lblNdePedido.Text = "N° de Pedido";
            // 
            // lblResetearNumero
            // 
            this.lblResetearNumero.AutoSize = true;
            this.lblResetearNumero.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNumero.ForeColor = System.Drawing.Color.Teal;

            this.lblResetearNumero.Location = new System.Drawing.Point(179, 147);
            this.lblResetearNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblResetearNumero.Location = new System.Drawing.Point(269, 237);

            this.lblResetearNumero.Name = "lblResetearNumero";
            this.lblResetearNumero.Size = new System.Drawing.Size(67, 19);
            this.lblResetearNumero.TabIndex = 17;
            this.lblResetearNumero.Text = "Resetear";
            // 
            // txtIngresarNumero
            // 

            this.txtIngresarNumero.Location = new System.Drawing.Point(4, 167);
            this.txtIngresarNumero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIngresarNumero.Multiline = true;
            this.txtIngresarNumero.Name = "txtIngresarNumero";
            this.txtIngresarNumero.Size = new System.Drawing.Size(242, 23);

            this.txtIngresarNumero.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresarNumero.Location = new System.Drawing.Point(6, 270);
            this.txtIngresarNumero.Multiline = true;
            this.txtIngresarNumero.Name = "txtIngresarNumero";
            this.txtIngresarNumero.Size = new System.Drawing.Size(361, 34);

            this.txtIngresarNumero.TabIndex = 18;
            this.txtIngresarNumero.TextChanged += new System.EventHandler(this.txtIngresarNumero_TextChanged);
            this.txtIngresarNumero.Enter += new System.EventHandler(this.txtIngresarNumero_Enter);
            this.txtIngresarNumero.Leave += new System.EventHandler(this.txtIngresarNumero_Leave);
            // 
            // lblIngresarNumero
            // 
            this.lblIngresarNumero.AutoSize = true;

            this.lblIngresarNumero.Location = new System.Drawing.Point(5, 171);
            this.lblIngresarNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIngresarNumero.Name = "lblIngresarNumero";
            this.lblIngresarNumero.Size = new System.Drawing.Size(142, 13);

            this.lblIngresarNumero.Location = new System.Drawing.Point(8, 276);
            this.lblIngresarNumero.Name = "lblIngresarNumero";
            this.lblIngresarNumero.Size = new System.Drawing.Size(208, 21);

            this.lblIngresarNumero.TabIndex = 19;
            this.lblIngresarNumero.Text = "Ingresar numero de pedido...";
            this.lblIngresarNumero.Click += new System.EventHandler(this.lblIngresarNumero_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.lblNombre.Location = new System.Drawing.Point(4, 203);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblNombre.Location = new System.Drawing.Point(6, 328);

            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 19);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Nombre";
            // 
            // lblResetearNombre
            // 
            this.lblResetearNombre.AutoSize = true;
            this.lblResetearNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNombre.ForeColor = System.Drawing.Color.Teal;

            this.lblResetearNombre.Location = new System.Drawing.Point(179, 203);
            this.lblResetearNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblResetearNombre.Location = new System.Drawing.Point(269, 328);

            this.lblResetearNombre.Name = "lblResetearNombre";
            this.lblResetearNombre.Size = new System.Drawing.Size(67, 19);
            this.lblResetearNombre.TabIndex = 21;
            this.lblResetearNombre.Text = "Resetear";
            this.lblResetearNombre.Click += new System.EventHandler(this.lblResetearNombre_Click);
            // 
            // txtNombre
            // 

            this.txtNombre.Location = new System.Drawing.Point(4, 223);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(242, 23);

            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(6, 360);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(361, 34);

            this.txtNombre.TabIndex = 22;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblEscribirNombre
            // 
            this.lblEscribirNombre.AutoSize = true;

            this.lblEscribirNombre.Location = new System.Drawing.Point(6, 227);
            this.lblEscribirNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEscribirNombre.Name = "lblEscribirNombre";
            this.lblEscribirNombre.Size = new System.Drawing.Size(99, 13);

            this.lblEscribirNombre.Location = new System.Drawing.Point(9, 367);
            this.lblEscribirNombre.Name = "lblEscribirNombre";
            this.lblEscribirNombre.Size = new System.Drawing.Size(145, 21);

            this.lblEscribirNombre.TabIndex = 23;
            this.lblEscribirNombre.Text = "Escribir el nombre...";
            this.lblEscribirNombre.Click += new System.EventHandler(this.lblEscribirNombre_Click);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.Teal;
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;

            this.btnAplicarFiltros.Location = new System.Drawing.Point(9, 255);
            this.btnAplicarFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(128, 36);

            this.btnAplicarFiltros.Location = new System.Drawing.Point(13, 412);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(156, 58);

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

            this.btnResetearTodo.Location = new System.Drawing.Point(141, 255);
            this.btnResetearTodo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(105, 36);

            this.btnResetearTodo.Location = new System.Drawing.Point(192, 412);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(157, 58);

            this.btnResetearTodo.TabIndex = 25;
            this.btnResetearTodo.Text = "Resetear todo";
            this.btnResetearTodo.UseVisualStyleBackColor = false;
            this.btnResetearTodo.Click += new System.EventHandler(this.btnResetearTodo_Click);
            // 
            // frmFiltroPedidos
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 313);

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 506);

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
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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