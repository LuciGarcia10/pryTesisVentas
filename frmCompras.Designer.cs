namespace pryTesisVentas
{
    partial class frmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompras));
            this.lblCompras = new System.Windows.Forms.Label();
            this.ptbCompras = new System.Windows.Forms.PictureBox();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPedir = new System.Windows.Forms.Button();
            this.txtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCantProd = new System.Windows.Forms.TextBox();
            this.lblFechaestimadadeentrega = new System.Windows.Forms.Label();
            this.lblDirecciondeentrega = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.lblCantidadProductos = new System.Windows.Forms.Label();
            this.lblCerrar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompras.Location = new System.Drawing.Point(46, 12);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(245, 31);
            this.lblCompras.TabIndex = 13;
            this.lblCompras.Text = "Compra de productos";
            // 
            // ptbCompras
            // 
            this.ptbCompras.Image = ((System.Drawing.Image)(resources.GetObject("ptbCompras.Image")));
            this.ptbCompras.Location = new System.Drawing.Point(12, 12);
            this.ptbCompras.Name = "ptbCompras";
            this.ptbCompras.Size = new System.Drawing.Size(28, 28);
            this.ptbCompras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbCompras.TabIndex = 12;
            this.ptbCompras.TabStop = false;
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Producto,
            this.Precio});
            this.dgvCompras.Location = new System.Drawing.Point(12, 56);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.RowHeadersWidth = 62;
            this.dgvCompras.RowTemplate.Height = 28;
            this.dgvCompras.Size = new System.Drawing.Size(589, 194);
            this.dgvCompras.TabIndex = 14;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 8;
            this.Cantidad.Name = "Cantidad";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 8;
            this.Producto.Name = "Producto";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 8;
            this.Precio.Name = "Precio";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCyan;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(393, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(208, 34);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPedir
            // 
            this.btnPedir.BackColor = System.Drawing.Color.Teal;
            this.btnPedir.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedir.ForeColor = System.Drawing.Color.White;
            this.btnPedir.Location = new System.Drawing.Point(393, 301);
            this.btnPedir.Name = "btnPedir";
            this.btnPedir.Size = new System.Drawing.Size(208, 37);
            this.btnPedir.TabIndex = 31;
            this.btnPedir.Text = "Pedir";
            this.btnPedir.UseVisualStyleBackColor = false;
            this.btnPedir.Click += new System.EventHandler(this.btnPedir_Click);
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaEntrega.Location = new System.Drawing.Point(233, 366);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Size = new System.Drawing.Size(137, 26);
            this.txtFechaEntrega.TabIndex = 30;
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.BackColor = System.Drawing.Color.White;
            this.txtPrecioTotal.Location = new System.Drawing.Point(476, 271);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(125, 26);
            this.txtPrecioTotal.TabIndex = 29;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(185, 314);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(137, 26);
            this.txtDireccion.TabIndex = 28;
            // 
            // txtCantProd
            // 
            this.txtCantProd.BackColor = System.Drawing.Color.White;
            this.txtCantProd.Location = new System.Drawing.Point(181, 271);
            this.txtCantProd.Name = "txtCantProd";
            this.txtCantProd.ReadOnly = true;
            this.txtCantProd.Size = new System.Drawing.Size(109, 26);
            this.txtCantProd.TabIndex = 27;
            // 
            // lblFechaestimadadeentrega
            // 
            this.lblFechaestimadadeentrega.AutoSize = true;
            this.lblFechaestimadadeentrega.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaestimadadeentrega.Location = new System.Drawing.Point(21, 366);
            this.lblFechaestimadadeentrega.Name = "lblFechaestimadadeentrega";
            this.lblFechaestimadadeentrega.Size = new System.Drawing.Size(206, 21);
            this.lblFechaestimadadeentrega.TabIndex = 26;
            this.lblFechaestimadadeentrega.Text = "Fecha estimada de entrega";
            // 
            // lblDirecciondeentrega
            // 
            this.lblDirecciondeentrega.AutoSize = true;
            this.lblDirecciondeentrega.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirecciondeentrega.Location = new System.Drawing.Point(21, 317);
            this.lblDirecciondeentrega.Name = "lblDirecciondeentrega";
            this.lblDirecciondeentrega.Size = new System.Drawing.Size(163, 21);
            this.lblDirecciondeentrega.TabIndex = 25;
            this.lblDirecciondeentrega.Text = "Direccion de entrega";
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(378, 273);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(95, 21);
            this.lblPrecioTotal.TabIndex = 24;
            this.lblPrecioTotal.Text = "Precio Total";
            // 
            // lblCantidadProductos
            // 
            this.lblCantidadProductos.AutoSize = true;
            this.lblCantidadProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadProductos.Location = new System.Drawing.Point(21, 273);
            this.lblCantidadProductos.Name = "lblCantidadProductos";
            this.lblCantidadProductos.Size = new System.Drawing.Size(154, 21);
            this.lblCantidadProductos.TabIndex = 23;
            this.lblCantidadProductos.Text = "Cantidad Productos";
            // 
            // lblCerrar
            // 
            this.lblCerrar.AutoSize = true;
            this.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCerrar.Location = new System.Drawing.Point(582, 9);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(20, 21);
            this.lblCerrar.TabIndex = 33;
            this.lblCerrar.Text = "X";
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 414);
            this.Controls.Add(this.lblCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPedir);
            this.Controls.Add(this.txtFechaEntrega);
            this.Controls.Add(this.txtPrecioTotal);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCantProd);
            this.Controls.Add(this.lblFechaestimadadeentrega);
            this.Controls.Add(this.lblDirecciondeentrega);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.lblCantidadProductos);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.lblCompras);
            this.Controls.Add(this.ptbCompras);
            this.Name = "frmCompras";
            this.Text = "frmCompras";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbCompras;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPedir;
        private System.Windows.Forms.DateTimePicker txtFechaEntrega;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCantProd;
        private System.Windows.Forms.Label lblFechaestimadadeentrega;
        private System.Windows.Forms.Label lblDirecciondeentrega;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label lblCantidadProductos;
        private System.Windows.Forms.Label lblCerrar;
    }
}