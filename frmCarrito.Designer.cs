namespace pryTesisVentas
{
    partial class frmCarrito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarrito));
            this.lblCerrar = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCarrito = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCantidadProductos = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.lblDirecciondeentrega = new System.Windows.Forms.Label();
            this.lblFechaestimadadeentrega = new System.Windows.Forms.Label();
            this.txtCantProd = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.txtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.btnPedir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCerrar
            // 
            this.lblCerrar.AutoSize = true;
            this.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCerrar.Location = new System.Drawing.Point(536, 6);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(14, 13);
            this.lblCerrar.TabIndex = 8;
            this.lblCerrar.Text = "X";
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Producto,
            this.Precio});
            this.dgvCarrito.Location = new System.Drawing.Point(15, 57);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.RowHeadersWidth = 62;
            this.dgvCarrito.RowTemplate.Height = 28;
            this.dgvCarrito.Size = new System.Drawing.Size(514, 194);
            this.dgvCarrito.TabIndex = 9;
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
            // lblCarrito
            // 
            this.lblCarrito.AutoSize = true;
            this.lblCarrito.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrito.Location = new System.Drawing.Point(42, 17);
            this.lblCarrito.Name = "lblCarrito";
            this.lblCarrito.Size = new System.Drawing.Size(153, 20);
            this.lblCarrito.TabIndex = 10;
            this.lblCarrito.Text = "Carrito de productos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblCantidadProductos
            // 
            this.lblCantidadProductos.AutoSize = true;
            this.lblCantidadProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadProductos.Location = new System.Drawing.Point(12, 274);
            this.lblCantidadProductos.Name = "lblCantidadProductos";
            this.lblCantidadProductos.Size = new System.Drawing.Size(107, 13);
            this.lblCantidadProductos.TabIndex = 12;
            this.lblCantidadProductos.Text = "Cantidad Productos";
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(332, 274);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(66, 13);
            this.lblPrecioTotal.TabIndex = 13;
            this.lblPrecioTotal.Text = "Precio Total";
            // 
            // lblDirecciondeentrega
            // 
            this.lblDirecciondeentrega.AutoSize = true;
            this.lblDirecciondeentrega.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirecciondeentrega.Location = new System.Drawing.Point(12, 318);
            this.lblDirecciondeentrega.Name = "lblDirecciondeentrega";
            this.lblDirecciondeentrega.Size = new System.Drawing.Size(112, 13);
            this.lblDirecciondeentrega.TabIndex = 14;
            this.lblDirecciondeentrega.Text = "Direccion de entrega";
            // 
            // lblFechaestimadadeentrega
            // 
            this.lblFechaestimadadeentrega.AutoSize = true;
            this.lblFechaestimadadeentrega.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaestimadadeentrega.Location = new System.Drawing.Point(12, 367);
            this.lblFechaestimadadeentrega.Name = "lblFechaestimadadeentrega";
            this.lblFechaestimadadeentrega.Size = new System.Drawing.Size(144, 13);
            this.lblFechaestimadadeentrega.TabIndex = 15;
            this.lblFechaestimadadeentrega.Text = "Fecha estimada de entrega";
            // 
            // txtCantProd
            // 
            this.txtCantProd.BackColor = System.Drawing.Color.White;
            this.txtCantProd.Location = new System.Drawing.Point(162, 271);
            this.txtCantProd.Name = "txtCantProd";
            this.txtCantProd.ReadOnly = true;
            this.txtCantProd.Size = new System.Drawing.Size(109, 22);
            this.txtCantProd.TabIndex = 16;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(162, 315);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(137, 22);
            this.txtDireccion.TabIndex = 18;
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.BackColor = System.Drawing.Color.White;
            this.txtPrecioTotal.Location = new System.Drawing.Point(404, 271);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(125, 22);
            this.txtPrecioTotal.TabIndex = 19;
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaEntrega.Location = new System.Drawing.Point(162, 358);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Size = new System.Drawing.Size(137, 22);
            this.txtFechaEntrega.TabIndex = 20;
            // 
            // btnPedir
            // 
            this.btnPedir.BackColor = System.Drawing.Color.Teal;
            this.btnPedir.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedir.ForeColor = System.Drawing.Color.White;
            this.btnPedir.Location = new System.Drawing.Point(321, 303);
            this.btnPedir.Name = "btnPedir";
            this.btnPedir.Size = new System.Drawing.Size(208, 37);
            this.btnPedir.TabIndex = 21;
            this.btnPedir.Text = "Pedir";
            this.btnPedir.UseVisualStyleBackColor = false;
            this.btnPedir.Click += new System.EventHandler(this.btnPedir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(321, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(208, 34);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(545, 405);
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
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCarrito);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblCerrar);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCarrito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCarrito";
            this.Load += new System.EventHandler(this.frmCarrito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCerrar;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lblCarrito;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCantidadProductos;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label lblDirecciondeentrega;
        private System.Windows.Forms.Label lblFechaestimadadeentrega;
        private System.Windows.Forms.TextBox txtCantProd;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DateTimePicker txtFechaEntrega;
        private System.Windows.Forms.Button btnPedir;
        private System.Windows.Forms.Button btnCancelar;
    }
}