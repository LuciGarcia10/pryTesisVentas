namespace pryTesisVentas
{
    partial class frmDetallePedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetallePedido));
            this.lblDetallePedido = new System.Windows.Forms.Label();
            this.lblNPedido = new System.Windows.Forms.Label();
            this.txtNumeroPedido = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.PctIconoDetalle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctIconoDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetallePedido
            // 
            this.lblDetallePedido.AutoSize = true;

            this.lblDetallePedido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallePedido.Location = new System.Drawing.Point(44, 20);
            this.lblDetallePedido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblDetallePedido.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallePedido.Location = new System.Drawing.Point(12, 15);

            this.lblDetallePedido.Name = "lblDetallePedido";
            this.lblDetallePedido.Size = new System.Drawing.Size(110, 20);
            this.lblDetallePedido.TabIndex = 0;
            this.lblDetallePedido.Text = "Detalle Pedido";
            // 
            // lblNPedido
            // 
            this.lblNPedido.AutoSize = true;

            this.lblNPedido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPedido.Location = new System.Drawing.Point(28, 54);
            this.lblNPedido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblNPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPedido.Location = new System.Drawing.Point(20, 66);

            this.lblNPedido.Name = "lblNPedido";
            this.lblNPedido.Size = new System.Drawing.Size(64, 17);
            this.lblNPedido.TabIndex = 1;
            this.lblNPedido.Text = "N°Pedido";
            // 
            // txtNumeroPedido
            // 

            this.txtNumeroPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroPedido.Location = new System.Drawing.Point(97, 52);
            this.txtNumeroPedido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumeroPedido.Multiline = true;
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Size = new System.Drawing.Size(195, 23);

            this.txtNumeroPedido.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroPedido.Location = new System.Drawing.Point(123, 63);
            this.txtNumeroPedido.Multiline = true;
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Size = new System.Drawing.Size(290, 34);

            this.txtNumeroPedido.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;

            this.btnBuscar.Location = new System.Drawing.Point(296, 47);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(71, 31);

            this.btnBuscar.Location = new System.Drawing.Point(419, 63);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 36);

            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Producto,
            this.Precio});

            this.dgvDetalles.Location = new System.Drawing.Point(26, 87);
            this.dgvDetalles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowHeadersWidth = 62;
            this.dgvDetalles.RowTemplate.Height = 28;
            this.dgvDetalles.Size = new System.Drawing.Size(339, 148);

            this.dgvDetalles.Location = new System.Drawing.Point(17, 120);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowHeadersWidth = 62;
            this.dgvDetalles.RowTemplate.Height = 28;
            this.dgvDetalles.Size = new System.Drawing.Size(509, 238);

            this.dgvDetalles.TabIndex = 4;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 8;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 150;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 8;
            this.Producto.Name = "Producto";
            this.Producto.Width = 150;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 8;
            this.Precio.Name = "Precio";
            this.Precio.Width = 150;
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;

            this.lblPrecioTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(200, 250);
            this.lblPrecioTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.lblPrecioTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblPrecioTotal.Location = new System.Drawing.Point(299, 378);

            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(78, 17);
            this.lblPrecioTotal.TabIndex = 5;
            this.lblPrecioTotal.Text = "Precio Total";
            this.lblPrecioTotal.Click += new System.EventHandler(this.lblPrecioTotal_Click);
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.BackColor = System.Drawing.Color.White;
            this.txtPrecioTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtPrecioTotal.Location = new System.Drawing.Point(282, 247);
            this.txtPrecioTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(85, 20);

            this.txtPrecioTotal.Location = new System.Drawing.Point(400, 378);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(126, 29);

            this.txtPrecioTotal.TabIndex = 6;
            this.txtPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCerrar
            // 
            this.lblCerrar.AutoSize = true;
            this.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCerrar.Location = new System.Drawing.Point(351, 10);
            this.lblCerrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(14, 13);
            this.lblCerrar.TabIndex = 7;
            this.lblCerrar.Text = "X";
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            this.lblCerrar.MouseEnter += new System.EventHandler(this.lblCerrar_MouseEnter);
            this.lblCerrar.MouseLeave += new System.EventHandler(this.lblCerrar_MouseLeave);
            // 
            // PctIconoDetalle
            // 
            this.PctIconoDetalle.Image = ((System.Drawing.Image)(resources.GetObject("PctIconoDetalle.Image")));
            this.PctIconoDetalle.Location = new System.Drawing.Point(26, 22);
            this.PctIconoDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.PctIconoDetalle.Name = "PctIconoDetalle";
            this.PctIconoDetalle.Size = new System.Drawing.Size(21, 18);
            this.PctIconoDetalle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctIconoDetalle.TabIndex = 12;
            this.PctIconoDetalle.TabStop = false;
            // 
            // frmDetallePedido
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(376, 292);
            this.Controls.Add(this.PctIconoDetalle);

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(538, 433);

            this.Controls.Add(this.lblCerrar);
            this.Controls.Add(this.txtPrecioTotal);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.lblNPedido);
            this.Controls.Add(this.lblDetallePedido);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDetallePedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetallePedido";
            this.Load += new System.EventHandler(this.frmDetallePedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctIconoDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetallePedido;
        private System.Windows.Forms.Label lblNPedido;
        private System.Windows.Forms.TextBox txtNumeroPedido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label lblCerrar;
        private System.Windows.Forms.PictureBox PctIconoDetalle;
    }
}