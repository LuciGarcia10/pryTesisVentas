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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNAf = new System.Windows.Forms.TextBox();
            this.lblNdeAfiliado = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblAp = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblECuenta = new System.Windows.Forms.Label();
            this.CmbOS = new System.Windows.Forms.ComboBox();
            this.CmbECuenta = new System.Windows.Forms.ComboBox();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            this.grFiltrar = new System.Windows.Forms.GroupBox();
            this.btnLimpiarAp = new System.Windows.Forms.Button();
            this.btnLimpiarN = new System.Windows.Forms.Button();
            this.btnLimpiarAf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            this.grFiltrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResetearTodo
            // 
            this.btnResetearTodo.BackColor = System.Drawing.Color.LightCyan;
            this.btnResetearTodo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetearTodo.ForeColor = System.Drawing.Color.Black;
            this.btnResetearTodo.Location = new System.Drawing.Point(217, 189);
            this.btnResetearTodo.Margin = new System.Windows.Forms.Padding(1);
            this.btnResetearTodo.Name = "btnResetearTodo";
            this.btnResetearTodo.Size = new System.Drawing.Size(147, 27);
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
            this.btnAplicarFiltros.Location = new System.Drawing.Point(217, 147);
            this.btnAplicarFiltros.Margin = new System.Windows.Forms.Padding(1);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(147, 39);
            this.btnAplicarFiltros.TabIndex = 43;
            this.btnAplicarFiltros.Text = "Aplicar Filtro(s)";
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(22, 119);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(1);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(147, 25);
            this.txtNombre.TabIndex = 41;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(19, 101);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 15);
            this.lblNombre.TabIndex = 39;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNAf
            // 
            this.txtNAf.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNAf.Location = new System.Drawing.Point(22, 55);
            this.txtNAf.Margin = new System.Windows.Forms.Padding(1);
            this.txtNAf.Multiline = true;
            this.txtNAf.Name = "txtNAf";
            this.txtNAf.Size = new System.Drawing.Size(147, 25);
            this.txtNAf.TabIndex = 37;
            // 
            // lblNdeAfiliado
            // 
            this.lblNdeAfiliado.AutoSize = true;
            this.lblNdeAfiliado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNdeAfiliado.Location = new System.Drawing.Point(19, 37);
            this.lblNdeAfiliado.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNdeAfiliado.Name = "lblNdeAfiliado";
            this.lblNdeAfiliado.Size = new System.Drawing.Size(83, 15);
            this.lblNdeAfiliado.TabIndex = 35;
            this.lblNdeAfiliado.Text = "N° de Afiliado";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(22, 185);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(1);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(147, 25);
            this.txtApellido.TabIndex = 47;
            // 
            // lblAp
            // 
            this.lblAp.AutoSize = true;
            this.lblAp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAp.Location = new System.Drawing.Point(19, 167);
            this.lblAp.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblAp.Name = "lblAp";
            this.lblAp.Size = new System.Drawing.Size(52, 15);
            this.lblAp.TabIndex = 45;
            this.lblAp.Text = "Apellido";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOS.Location = new System.Drawing.Point(213, 37);
            this.lblOS.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(69, 15);
            this.lblOS.TabIndex = 49;
            this.lblOS.Text = "Obra Social";
            // 
            // lblECuenta
            // 
            this.lblECuenta.AutoSize = true;
            this.lblECuenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblECuenta.Location = new System.Drawing.Point(214, 101);
            this.lblECuenta.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblECuenta.Name = "lblECuenta";
            this.lblECuenta.Size = new System.Drawing.Size(102, 15);
            this.lblECuenta.TabIndex = 50;
            this.lblECuenta.Text = "Estado de Cuenta";
            // 
            // CmbOS
            // 
            this.CmbOS.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOS.FormattingEnabled = true;
            this.CmbOS.Location = new System.Drawing.Point(217, 59);
            this.CmbOS.Name = "CmbOS";
            this.CmbOS.Size = new System.Drawing.Size(147, 21);
            this.CmbOS.TabIndex = 51;
            this.CmbOS.Text = "Seleccionar Obra Social";
            // 
            // CmbECuenta
            // 
            this.CmbECuenta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbECuenta.FormattingEnabled = true;
            this.CmbECuenta.Location = new System.Drawing.Point(216, 121);
            this.CmbECuenta.Name = "CmbECuenta";
            this.CmbECuenta.Size = new System.Drawing.Size(147, 21);
            this.CmbECuenta.TabIndex = 52;
            // 
            // pctCerrar
            // 
            this.pctCerrar.Image = global::pryTesisVentas.Properties.Resources.cerrar;
            this.pctCerrar.Location = new System.Drawing.Point(373, 2);
            this.pctCerrar.Margin = new System.Windows.Forms.Padding(1);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(21, 18);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCerrar.TabIndex = 54;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // grFiltrar
            // 
            this.grFiltrar.Controls.Add(this.btnLimpiarAp);
            this.grFiltrar.Controls.Add(this.btnLimpiarN);
            this.grFiltrar.Controls.Add(this.btnLimpiarAf);
            this.grFiltrar.Controls.Add(this.btnResetearTodo);
            this.grFiltrar.Controls.Add(this.lblNdeAfiliado);
            this.grFiltrar.Controls.Add(this.CmbECuenta);
            this.grFiltrar.Controls.Add(this.txtNAf);
            this.grFiltrar.Controls.Add(this.CmbOS);
            this.grFiltrar.Controls.Add(this.lblNombre);
            this.grFiltrar.Controls.Add(this.lblECuenta);
            this.grFiltrar.Controls.Add(this.lblOS);
            this.grFiltrar.Controls.Add(this.txtNombre);
            this.grFiltrar.Controls.Add(this.txtApellido);
            this.grFiltrar.Controls.Add(this.btnAplicarFiltros);
            this.grFiltrar.Controls.Add(this.lblAp);
            this.grFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grFiltrar.Location = new System.Drawing.Point(12, 24);
            this.grFiltrar.Name = "grFiltrar";
            this.grFiltrar.Size = new System.Drawing.Size(382, 233);
            this.grFiltrar.TabIndex = 55;
            this.grFiltrar.TabStop = false;
            this.grFiltrar.Text = "Filtrar por:";
            // 
            // btnLimpiarAp
            // 
            this.btnLimpiarAp.BackColor = System.Drawing.Color.White;
            this.btnLimpiarAp.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiarAp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarAp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarAp.Location = new System.Drawing.Point(172, 185);
            this.btnLimpiarAp.Name = "btnLimpiarAp";
            this.btnLimpiarAp.Size = new System.Drawing.Size(25, 25);
            this.btnLimpiarAp.TabIndex = 55;
            this.btnLimpiarAp.Text = "X";
            this.btnLimpiarAp.UseVisualStyleBackColor = false;
            this.btnLimpiarAp.Click += new System.EventHandler(this.btnLimpiarAp_Click);
            // 
            // btnLimpiarN
            // 
            this.btnLimpiarN.BackColor = System.Drawing.Color.White;
            this.btnLimpiarN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiarN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarN.Location = new System.Drawing.Point(172, 120);
            this.btnLimpiarN.Name = "btnLimpiarN";
            this.btnLimpiarN.Size = new System.Drawing.Size(25, 25);
            this.btnLimpiarN.TabIndex = 54;
            this.btnLimpiarN.Text = "X";
            this.btnLimpiarN.UseVisualStyleBackColor = false;
            this.btnLimpiarN.Click += new System.EventHandler(this.btnLimpiarN_Click);
            // 
            // btnLimpiarAf
            // 
            this.btnLimpiarAf.BackColor = System.Drawing.Color.White;
            this.btnLimpiarAf.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLimpiarAf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarAf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarAf.Location = new System.Drawing.Point(172, 55);
            this.btnLimpiarAf.Name = "btnLimpiarAf";
            this.btnLimpiarAf.Size = new System.Drawing.Size(25, 25);
            this.btnLimpiarAf.TabIndex = 53;
            this.btnLimpiarAf.Text = "X";
            this.btnLimpiarAf.UseVisualStyleBackColor = false;
            this.btnLimpiarAf.Click += new System.EventHandler(this.btnLimpiarAf_Click);
            // 
            // FrmFiltroClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 273);
            this.Controls.Add(this.grFiltrar);
            this.Controls.Add(this.pctCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFiltroClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFiltroClientes";
            this.Load += new System.EventHandler(this.FrmFiltroClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            this.grFiltrar.ResumeLayout(false);
            this.grFiltrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResetearTodo;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNAf;
        private System.Windows.Forms.Label lblNdeAfiliado;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblAp;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblECuenta;
        private System.Windows.Forms.ComboBox CmbOS;
        private System.Windows.Forms.ComboBox CmbECuenta;
        private System.Windows.Forms.PictureBox pctCerrar;
        private System.Windows.Forms.GroupBox grFiltrar;
        private System.Windows.Forms.Button btnLimpiarAf;
        private System.Windows.Forms.Button btnLimpiarAp;
        private System.Windows.Forms.Button btnLimpiarN;
    }
}