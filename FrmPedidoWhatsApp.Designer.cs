namespace pryTesisVentas
{
    partial class FrmPedidoWhatsApp
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
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblProveedorWpp = new System.Windows.Forms.Label();
            this.btnEnviarWpp = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // pctCerrar
            // 
            this.pctCerrar.Image = global::pryTesisVentas.Properties.Resources.cerrar;
            this.pctCerrar.Location = new System.Drawing.Point(243, 7);
            this.pctCerrar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(25, 20);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCerrar.TabIndex = 65;
            this.pctCerrar.TabStop = false;
            // 
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(24, 69);
            this.cmbProductos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(184, 23);
            this.cmbProductos.TabIndex = 64;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::pryTesisVentas.Properties.Resources.Hacer_Pedidos;
            this.pictureBox5.Location = new System.Drawing.Point(15, 16);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 63;
            this.pictureBox5.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(25, 352);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 34);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "Volver";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblProveedorWpp
            // 
            this.lblProveedorWpp.AutoSize = true;
            this.lblProveedorWpp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedorWpp.Location = new System.Drawing.Point(44, 20);
            this.lblProveedorWpp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedorWpp.Name = "lblProveedorWpp";
            this.lblProveedorWpp.Size = new System.Drawing.Size(81, 20);
            this.lblProveedorWpp.TabIndex = 61;
            this.lblProveedorWpp.Text = "Proveedor";
            // 
            // btnEnviarWpp
            // 
            this.btnEnviarWpp.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEnviarWpp.ForeColor = System.Drawing.Color.White;
            this.btnEnviarWpp.Location = new System.Drawing.Point(102, 352);
            this.btnEnviarWpp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnEnviarWpp.Name = "btnEnviarWpp";
            this.btnEnviarWpp.Size = new System.Drawing.Size(149, 34);
            this.btnEnviarWpp.TabIndex = 60;
            this.btnEnviarWpp.Text = "Enviar WhatsApp";
            this.btnEnviarWpp.UseVisualStyleBackColor = false;
            this.btnEnviarWpp.Click += new System.EventHandler(this.btnEnviarWpp_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(23, 104);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 15);
            this.lblCantidad.TabIndex = 58;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.Location = new System.Drawing.Point(22, 51);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(127, 15);
            this.lblNombreProducto.TabIndex = 57;
            this.lblNombreProducto.Text = "Nombre del Producto";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Teal;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregar.Location = new System.Drawing.Point(216, 64);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(35, 32);
            this.btnAgregar.TabIndex = 66;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(26, 126);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(225, 23);
            this.numCantidad.TabIndex = 67;
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Location = new System.Drawing.Point(18, 173);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.RowTemplate.Height = 24;
            this.dgvDetallePedido.Size = new System.Drawing.Size(240, 163);
            this.dgvDetallePedido.TabIndex = 68;
            this.dgvDetallePedido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePedido_CellDoubleClick);
            // 
            // FrmPedidoWhatsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 405);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDetallePedido);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblProveedorWpp);
            this.Controls.Add(this.btnEnviarWpp);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblNombreProducto);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPedidoWhatsApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPedidoWhatsApp";
            this.Load += new System.EventHandler(this.FrmPedidoWhatsApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctCerrar;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblProveedorWpp;
        private System.Windows.Forms.Button btnEnviarWpp;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
    }
}