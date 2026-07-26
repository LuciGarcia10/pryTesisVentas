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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblProveedores = new System.Windows.Forms.Label();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.btnVerCompras = new System.Windows.Forms.Button();
            this.btnAgregararCompras = new System.Windows.Forms.Button();
            this.lblHacerPedido1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
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
            this.lblHacerPedido.Size = new System.Drawing.Size(125, 25);
            this.lblHacerPedido.TabIndex = 1;
            this.lblHacerPedido.Text = "Hacer Pedido";
            // 
            // lblNombredelProducto
            // 
            this.lblNombredelProducto.AutoSize = true;
            this.lblNombredelProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombredelProducto.Location = new System.Drawing.Point(12, 69);
            this.lblNombredelProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombredelProducto.Name = "lblNombredelProducto";
            this.lblNombredelProducto.Size = new System.Drawing.Size(195, 25);
            this.lblNombredelProducto.TabIndex = 2;
            this.lblNombredelProducto.Text = "Nombre del Producto";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(12, 129);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(88, 25);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad";
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(15, 146);
            this.numCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(304, 29);
            this.numCantidad.TabIndex = 24;
            // 
            // lblProveedores
            // 
            this.lblProveedores.AutoSize = true;
            this.lblProveedores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedores.Location = new System.Drawing.Point(12, 185);
            this.lblProveedores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedores.Name = "lblProveedores";
            this.lblProveedores.Size = new System.Drawing.Size(118, 25);
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
            this.cmbProveedores.Location = new System.Drawing.Point(11, 202);
            this.cmbProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(304, 29);
            this.cmbProveedores.TabIndex = 26;
            this.cmbProveedores.Text = "Elegir Proveedor...";
            // 
            // btnVerCompras
            // 
            this.btnVerCompras.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnVerCompras.ForeColor = System.Drawing.Color.White;
            this.btnVerCompras.Location = new System.Drawing.Point(11, 240);
            this.btnVerCompras.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerCompras.Name = "btnVerCompras";
            this.btnVerCompras.Size = new System.Drawing.Size(119, 47);
            this.btnVerCompras.TabIndex = 27;
            this.btnVerCompras.Text = "Ver Compras";
            this.btnVerCompras.UseVisualStyleBackColor = false;
            // 
            // btnAgregararCompras
            // 
            this.btnAgregararCompras.BackColor = System.Drawing.Color.Teal;
            this.btnAgregararCompras.ForeColor = System.Drawing.Color.White;
            this.btnAgregararCompras.Location = new System.Drawing.Point(134, 240);
            this.btnAgregararCompras.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregararCompras.Name = "btnAgregararCompras";
            this.btnAgregararCompras.Size = new System.Drawing.Size(178, 47);
            this.btnAgregararCompras.TabIndex = 28;
            this.btnAgregararCompras.Text = "Agregar a Compras";
            this.btnAgregararCompras.UseVisualStyleBackColor = false;
            // 
            // lblHacerPedido1
            // 
            this.lblHacerPedido1.AutoSize = true;
            this.lblHacerPedido1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHacerPedido1.Location = new System.Drawing.Point(49, 25);
            this.lblHacerPedido1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHacerPedido1.Name = "lblHacerPedido1";
            this.lblHacerPedido1.Size = new System.Drawing.Size(156, 31);
            this.lblHacerPedido1.TabIndex = 29;
            this.lblHacerPedido1.Text = "Hacer Pedido";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(28)))), ((int)(((byte)(3)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(53, 294);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(224, 42);
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
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(15, 87);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(291, 29);
            this.cmbProductos.TabIndex = 40;
            // 
            // frmNuevoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 348);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblHacerPedido1);
            this.Controls.Add(this.btnAgregararCompras);
            this.Controls.Add(this.btnVerCompras);
            this.Controls.Add(this.cmbProveedores);
            this.Controls.Add(this.lblProveedores);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblNombredelProducto);
            this.Controls.Add(this.lblHacerPedido);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblProveedores;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Button btnVerCompras;
        private System.Windows.Forms.Button btnAgregararCompras;
        private System.Windows.Forms.Label lblHacerPedido1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ComboBox cmbProductos;
    }
}