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
            this.lblHacerPedido = new System.Windows.Forms.Label();
            this.lblNombredelProducto = new System.Windows.Forms.Label();
            this.lblProveedores = new System.Windows.Forms.Label();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.btnCanalProveedor = new System.Windows.Forms.Button();
            this.lblHacerPedido1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
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
            this.lblNombredelProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombredelProducto.Location = new System.Drawing.Point(20, 69);
            this.lblNombredelProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombredelProducto.Name = "lblNombredelProducto";
            this.lblNombredelProducto.Size = new System.Drawing.Size(127, 15);
            this.lblNombredelProducto.TabIndex = 2;
            this.lblNombredelProducto.Text = "Nombre del Producto";
            // 
            // lblProveedores
            // 
            this.lblProveedores.AutoSize = true;
            this.lblProveedores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedores.Location = new System.Drawing.Point(21, 132);
            this.lblProveedores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedores.Name = "lblProveedores";
            this.lblProveedores.Size = new System.Drawing.Size(78, 15);
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
            this.cmbProveedores.Location = new System.Drawing.Point(23, 159);
            this.cmbProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(291, 21);
            this.cmbProveedores.TabIndex = 26;
            this.cmbProveedores.Text = "Elegir Proveedor...";
            // 
            // btnCanalProveedor
            // 
            this.btnCanalProveedor.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCanalProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanalProveedor.ForeColor = System.Drawing.Color.White;
            this.btnCanalProveedor.Location = new System.Drawing.Point(122, 205);
            this.btnCanalProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.btnCanalProveedor.Name = "btnCanalProveedor";
            this.btnCanalProveedor.Size = new System.Drawing.Size(192, 47);
            this.btnCanalProveedor.TabIndex = 28;
            this.btnCanalProveedor.Text = "Ir al canal del proveedor";
            this.btnCanalProveedor.UseVisualStyleBackColor = false;
            this.btnCanalProveedor.Click += new System.EventHandler(this.btnCanalProveedor_Click);
            // 
            // lblHacerPedido1
            // 
            this.lblHacerPedido1.AutoSize = true;
            this.lblHacerPedido1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHacerPedido1.Location = new System.Drawing.Point(49, 25);
            this.lblHacerPedido1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHacerPedido1.Name = "lblHacerPedido1";
            this.lblHacerPedido1.Size = new System.Drawing.Size(156, 20);
            this.lblHacerPedido1.TabIndex = 29;
            this.lblHacerPedido1.Text = "Selecionar proveedor";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(23, 205);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 47);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(23, 93);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(291, 21);
            this.cmbProductos.TabIndex = 40;
            // 
            // pctCerrar
            // 
            this.pctCerrar.Image = global::pryTesisVentas.Properties.Resources.cerrar;
            this.pctCerrar.Location = new System.Drawing.Point(305, 7);
            this.pctCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(32, 28);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCerrar.TabIndex = 56;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::pryTesisVentas.Properties.Resources.Hacer_Pedidos;
            this.pictureBox5.Location = new System.Drawing.Point(11, 20);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 33);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 39;
            this.pictureBox5.TabStop = false;
            // 
            // frmNuevoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 272);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblHacerPedido1);
            this.Controls.Add(this.btnCanalProveedor);
            this.Controls.Add(this.cmbProveedores);
            this.Controls.Add(this.lblProveedores);
            this.Controls.Add(this.lblNombredelProducto);
            this.Controls.Add(this.lblHacerPedido);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNuevoPedido";
            this.Text = "frmNuevoPedido";
            this.Load += new System.EventHandler(this.frmNuevoPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHacerPedido;
        private System.Windows.Forms.Label lblNombredelProducto;
        private System.Windows.Forms.Label lblProveedores;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Button btnCanalProveedor;
        private System.Windows.Forms.Label lblHacerPedido1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.PictureBox pctCerrar;
    }
}