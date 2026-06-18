namespace pryTesisVentas
{
    partial class FrmFiltroClientes
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
            this.btnResetearTodo = new System.Windows.Forms.Button();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblResetearNombre = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtIngresarNumero = new System.Windows.Forms.TextBox();
            this.lblResetearNumero = new System.Windows.Forms.Label();
            this.lblNdeAfiliado = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblResetearAp = new System.Windows.Forms.Label();
            this.lblAp = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblECuenta = new System.Windows.Forms.Label();
            this.CmbOS = new System.Windows.Forms.ComboBox();
            this.CmbECuenta = new System.Windows.Forms.ComboBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResetearTodo
            // 
            this.btnResetearTodo.BackColor = System.Drawing.Color.LightCyan;
            this.btnResetearTodo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetearTodo.ForeColor = System.Drawing.Color.Black;
            this.btnResetearTodo.Location = new System.Drawing.Point(246, 219);
            this.btnResetearTodo.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(209, 27);
            this.btnResetearTodo.TabIndex = 44;
            this.btnResetearTodo.Text = "Resetear todo";
            this.btnResetearTodo.UseVisualStyleBackColor = false;
            this.btnResetearTodo.Click += new System.EventHandler(this.btnResetearTodo_Click);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.Teal;
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(246, 171);
            this.btnAplicarFiltros.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(209, 46);
            this.btnAplicarFiltros.TabIndex = 43;
            this.btnAplicarFiltros.Text = "Aplicar Filtros";
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(22, 136);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(209, 23);
            this.txtNombre.TabIndex = 41;
            this.txtNombre.Text = "Escribir el nombre...";
            // 
            // lblResetearNombre
            // 
            this.lblResetearNombre.AutoSize = true;
            this.lblResetearNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNombre.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearNombre.Location = new System.Drawing.Point(164, 105);
            this.lblResetearNombre.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblResetearNombre.Name = "lblResetearNombre";
            this.lblResetearNombre.Size = new System.Drawing.Size(67, 19);
            this.lblResetearNombre.TabIndex = 40;
            this.lblResetearNombre.Text = "Resetear";
            this.lblResetearNombre.Click += new System.EventHandler(this.lblResetearNombre_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(18, 105);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 19);
            this.lblNombre.TabIndex = 39;
            this.lblNombre.Text = "Nombre";
            // 
            // txtIngresarNumero
            // 
            this.txtIngresarNumero.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresarNumero.Location = new System.Drawing.Point(22, 72);
            this.txtIngresarNumero.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtIngresarNumero.Multiline = true;
            this.txtIngresarNumero.Name = "txtIngresarNumero";
            this.txtIngresarNumero.Size = new System.Drawing.Size(209, 23);
            this.txtIngresarNumero.TabIndex = 37;
            this.txtIngresarNumero.Text = "Ingresa el N° de Afiliado...";
            // 
            // lblResetearNumero
            // 
            this.lblResetearNumero.AutoSize = true;
            this.lblResetearNumero.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearNumero.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearNumero.Location = new System.Drawing.Point(164, 41);
            this.lblResetearNumero.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblResetearNumero.Name = "lblResetearNumero";
            this.lblResetearNumero.Size = new System.Drawing.Size(67, 19);
            this.lblResetearNumero.TabIndex = 36;
            this.lblResetearNumero.Text = "Resetear";
            this.lblResetearNumero.Click += new System.EventHandler(this.lblResetearNumero_Click);
            // 
            // lblNdeAfiliado
            // 
            this.lblNdeAfiliado.AutoSize = true;
            this.lblNdeAfiliado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNdeAfiliado.Location = new System.Drawing.Point(18, 41);
            this.lblNdeAfiliado.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNdeAfiliado.Name = "lblNdeAfiliado";
            this.lblNdeAfiliado.Size = new System.Drawing.Size(103, 19);
            this.lblNdeAfiliado.TabIndex = 35;
            this.lblNdeAfiliado.Text = "N° de Afiliado";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(22, 210);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(209, 23);
            this.txtApellido.TabIndex = 47;
            this.txtApellido.Text = "Escribir el apellido...";
            // 
            // lblResetearAp
            // 
            this.lblResetearAp.AutoSize = true;
            this.lblResetearAp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetearAp.ForeColor = System.Drawing.Color.Teal;
            this.lblResetearAp.Location = new System.Drawing.Point(164, 179);
            this.lblResetearAp.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblResetearAp.Name = "lblResetearAp";
            this.lblResetearAp.Size = new System.Drawing.Size(67, 19);
            this.lblResetearAp.TabIndex = 46;
            this.lblResetearAp.Text = "Resetear";
            this.lblResetearAp.Click += new System.EventHandler(this.lblResetearAp_Click);
            // 
            // lblAp
            // 
            this.lblAp.AutoSize = true;
            this.lblAp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAp.Location = new System.Drawing.Point(18, 179);
            this.lblAp.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblAp.Name = "lblAp";
            this.lblAp.Size = new System.Drawing.Size(66, 19);
            this.lblAp.TabIndex = 45;
            this.lblAp.Text = "Apellido";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOS.Location = new System.Drawing.Point(242, 39);
            this.lblOS.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(87, 19);
            this.lblOS.TabIndex = 49;
            this.lblOS.Text = "Obra Social";
            // 
            // lblECuenta
            // 
            this.lblECuenta.AutoSize = true;
            this.lblECuenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblECuenta.Location = new System.Drawing.Point(242, 114);
            this.lblECuenta.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblECuenta.Name = "lblECuenta";
            this.lblECuenta.Size = new System.Drawing.Size(124, 19);
            this.lblECuenta.TabIndex = 50;
            this.lblECuenta.Text = "Estado de Cuenta";
            // 
            // CmbOS
            // 
            this.CmbOS.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOS.FormattingEnabled = true;
            this.CmbOS.Location = new System.Drawing.Point(246, 70);
            this.CmbOS.Name = "CmbOS";
            this.CmbOS.Size = new System.Drawing.Size(209, 21);
            this.CmbOS.TabIndex = 51;
            this.CmbOS.Text = "Seleccionar Obra Social";
            // 
            // CmbECuenta
            // 
            this.CmbECuenta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbECuenta.FormattingEnabled = true;
            this.CmbECuenta.Location = new System.Drawing.Point(246, 136);
            this.CmbECuenta.Name = "CmbECuenta";
            this.CmbECuenta.Size = new System.Drawing.Size(209, 21);
            this.CmbECuenta.TabIndex = 52;
            this.CmbECuenta.Text = "Seleccionar Estado de Cuenta";
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrar.Location = new System.Drawing.Point(19, 12);
            this.lblFiltrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(72, 17);
            this.lblFiltrar.TabIndex = 53;
            this.lblFiltrar.Text = "Filtrar por:";
            // 
            // pctCerrar
            // 
            this.pctCerrar.Image = global::pryTesisVentas.Properties.Resources.cerrar;
            this.pctCerrar.Location = new System.Drawing.Point(434, 10);
            this.pctCerrar.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(21, 18);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCerrar.TabIndex = 54;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // FrmFiltroClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 266);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.CmbECuenta);
            this.Controls.Add(this.CmbOS);
            this.Controls.Add(this.lblECuenta);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblResetearAp);
            this.Controls.Add(this.lblAp);
            this.Controls.Add(this.btnResetearTodo);
            this.Controls.Add(this.btnAplicarFiltros);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblResetearNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtIngresarNumero);
            this.Controls.Add(this.lblResetearNumero);
            this.Controls.Add(this.lblNdeAfiliado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFiltroClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFiltroClientes";
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResetearTodo;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblResetearNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtIngresarNumero;
        private System.Windows.Forms.Label lblResetearNumero;
        private System.Windows.Forms.Label lblNdeAfiliado;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblResetearAp;
        private System.Windows.Forms.Label lblAp;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblECuenta;
        private System.Windows.Forms.ComboBox CmbOS;
        private System.Windows.Forms.ComboBox CmbECuenta;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.PictureBox pctCerrar;
    }
}