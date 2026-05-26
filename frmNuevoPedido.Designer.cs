namespace pryTesisVentas
{
    partial class frmNuevoPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoPedido));
            this.lblHacerPedido = new System.Windows.Forms.Label();
            this.lblNombredelProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblProveedores = new System.Windows.Forms.Label();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.btnVerCarrito = new System.Windows.Forms.Button();
            this.btnAgregaralCarrito = new System.Windows.Forms.Button();
            this.lblHacerPedido1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHacerPedido
            // 
            this.lblHacerPedido.AutoSize = true;
            this.lblHacerPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHacerPedido.Location = new System.Drawing.Point(-559, 8);
            this.lblHacerPedido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHacerPedido.Name = "lblHacerPedido";
            this.lblHacerPedido.Size = new System.Drawing.Size(81, 15);
            this.lblHacerPedido.TabIndex = 1;
            this.lblHacerPedido.Text = "Hacer Pedido";
            // 
            // lblNombredelProducto
            // 
            this.lblNombredelProducto.AutoSize = true;
            this.lblNombredelProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombredelProducto.Location = new System.Drawing.Point(34, 63);
            this.lblNombredelProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombredelProducto.Name = "lblNombredelProducto";
            this.lblNombredelProducto.Size = new System.Drawing.Size(140, 17);
            this.lblNombredelProducto.TabIndex = 2;
            this.lblNombredelProducto.Text = "Nombre del Producto";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(34, 89);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombreProducto.Multiline = true;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(237, 35);
            this.txtNombreProducto.TabIndex = 3;
            this.txtNombreProducto.TextChanged += new System.EventHandler(this.txtNombreProducto_TextChanged);
            this.txtNombreProducto.Enter += new System.EventHandler(this.txtNombreProducto_Enter);
            this.txtNombreProducto.Leave += new System.EventHandler(this.txtNombreProducto_Leave);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.BackColor = System.Drawing.Color.White;
            this.lblNombreProducto.Location = new System.Drawing.Point(38, 100);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(203, 17);
            this.lblNombreProducto.TabIndex = 4;
            this.lblNombreProducto.Text = "Escribir el nombre del Producto...";
            this.lblNombreProducto.Click += new System.EventHandler(this.lblNombreProducto_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(34, 136);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 17);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad";
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(34, 163);
            this.numCantidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(237, 25);
            this.numCantidad.TabIndex = 24;
            // 
            // lblProveedores
            // 
            this.lblProveedores.AutoSize = true;
            this.lblProveedores.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedores.Location = new System.Drawing.Point(34, 202);
            this.lblProveedores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedores.Name = "lblProveedores";
            this.lblProveedores.Size = new System.Drawing.Size(84, 17);
            this.lblProveedores.TabIndex = 25;
            this.lblProveedores.Text = "Proveedores";
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Items.AddRange(new object[] {
            "Drogueria Monroe",
            "Drogueria Suiza",
            "Drogueria del Sud",
            "Belleza"});
            this.cmbProveedores.Location = new System.Drawing.Point(34, 231);
            this.cmbProveedores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(237, 25);
            this.cmbProveedores.TabIndex = 26;
            this.cmbProveedores.Text = "Elegir Proveedor...";
            // 
            // btnVerCarrito
            // 
            this.btnVerCarrito.BackColor = System.Drawing.Color.CadetBlue;
            this.btnVerCarrito.ForeColor = System.Drawing.Color.White;
            this.btnVerCarrito.Location = new System.Drawing.Point(197, 18);
            this.btnVerCarrito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVerCarrito.Name = "btnVerCarrito";
            this.btnVerCarrito.Size = new System.Drawing.Size(94, 34);
            this.btnVerCarrito.TabIndex = 27;
            this.btnVerCarrito.Text = "Ver Carrito";
            this.btnVerCarrito.UseVisualStyleBackColor = false;
            this.btnVerCarrito.Click += new System.EventHandler(this.btnVerCarrito_Click);
            // 
            // btnAgregaralCarrito
            // 
            this.btnAgregaralCarrito.BackColor = System.Drawing.Color.Teal;
            this.btnAgregaralCarrito.ForeColor = System.Drawing.Color.White;
            this.btnAgregaralCarrito.Location = new System.Drawing.Point(135, 270);
            this.btnAgregaralCarrito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregaralCarrito.Name = "btnAgregaralCarrito";
            this.btnAgregaralCarrito.Size = new System.Drawing.Size(144, 34);
            this.btnAgregaralCarrito.TabIndex = 28;
            this.btnAgregaralCarrito.Text = "Agregar al Carrito";
            this.btnAgregaralCarrito.UseVisualStyleBackColor = false;
            this.btnAgregaralCarrito.Click += new System.EventHandler(this.btnAgregaralCarrito_Click);
            // 
            // lblHacerPedido1
            // 
            this.lblHacerPedido1.AutoSize = true;
            this.lblHacerPedido1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHacerPedido1.Location = new System.Drawing.Point(49, 25);
            this.lblHacerPedido1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHacerPedido1.Name = "lblHacerPedido1";
            this.lblHacerPedido1.Size = new System.Drawing.Size(101, 20);
            this.lblHacerPedido1.TabIndex = 29;
            this.lblHacerPedido1.Text = "Hacer Pedido";
            this.lblHacerPedido1.Click += new System.EventHandler(this.lblHacerPedido1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Azure;
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(28, 270);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 34);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(20, 23);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 22);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 39;
            this.pictureBox5.TabStop = false;
            // 
            // frmNuevoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 333);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblHacerPedido1);
            this.Controls.Add(this.btnAgregaralCarrito);
            this.Controls.Add(this.btnVerCarrito);
            this.Controls.Add(this.cmbProveedores);
            this.Controls.Add(this.lblProveedores);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.lblNombredelProducto);
            this.Controls.Add(this.lblHacerPedido);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmNuevoPedido";
            this.Text = "frmNuevoPedido";
            this.Load += new System.EventHandler(this.frmNuevoPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHacerPedido;
        private System.Windows.Forms.Label lblNombredelProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblProveedores;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Button btnVerCarrito;
        private System.Windows.Forms.Button btnAgregaralCarrito;
        private System.Windows.Forms.Label lblHacerPedido1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}