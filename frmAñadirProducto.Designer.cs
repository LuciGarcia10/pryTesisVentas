namespace pryTesisVentas
{
    partial class frmAñadirProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAñadirProducto));
            this.lblAñadirproducto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblFechavencimiento = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAñadirproducto = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAñadirproducto
            // 
            this.lblAñadirproducto.AutoSize = true;
            this.lblAñadirproducto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAñadirproducto.Location = new System.Drawing.Point(35, 9);
            this.lblAñadirproducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAñadirproducto.Name = "lblAñadirproducto";
            this.lblAñadirproducto.Size = new System.Drawing.Size(177, 20);
            this.lblAñadirproducto.TabIndex = 0;
            this.lblAñadirproducto.Text = "Añadir producto a stock";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(27, 39);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(27, 91);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(66, 17);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(27, 144);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 17);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblFechavencimiento
            // 
            this.lblFechavencimiento.AutoSize = true;
            this.lblFechavencimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechavencimiento.Location = new System.Drawing.Point(24, 202);
            this.lblFechavencimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechavencimiento.Name = "lblFechavencimiento";
            this.lblFechavencimiento.Size = new System.Drawing.Size(140, 17);
            this.lblFechavencimiento.TabIndex = 4;
            this.lblFechavencimiento.Text = "Fecha de vencimiento";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(27, 221);
            this.dtpVencimiento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(218, 23);
            this.dtpVencimiento.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCyan;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(27, 265);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 40);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAñadirproducto
            // 
            this.btnAñadirproducto.BackColor = System.Drawing.Color.Teal;
            this.btnAñadirproducto.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirproducto.ForeColor = System.Drawing.Color.White;
            this.btnAñadirproducto.Location = new System.Drawing.Point(134, 265);
            this.btnAñadirproducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAñadirproducto.Name = "btnAñadirproducto";
            this.btnAñadirproducto.Size = new System.Drawing.Size(111, 40);
            this.btnAñadirproducto.TabIndex = 20;
            this.btnAñadirproducto.Text = "Añadir producto";
            this.btnAñadirproducto.UseVisualStyleBackColor = false;
            this.btnAñadirproducto.Click += new System.EventHandler(this.btnAñadirproducto_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(27, 58);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(215, 23);
            this.txtNombre.TabIndex = 21;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Salud",
            "Belleza",
            "Ciudad Personal",
            "Medicamento Venta Libre",
            "Medicamento con Receta"});
            this.cmbCategoria.Location = new System.Drawing.Point(27, 110);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(218, 21);
            this.cmbCategoria.TabIndex = 22;
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCantidad.Location = new System.Drawing.Point(27, 163);
            this.numCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(218, 23);
            this.numCantidad.TabIndex = 23;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(8, 6);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 22);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 39;
            this.pictureBox6.TabStop = false;
            // 
            // frmAñadirProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 337);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnAñadirproducto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.lblFechavencimiento);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblAñadirproducto);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAñadirProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAñadirProducto";
            this.Load += new System.EventHandler(this.frmAñadirProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAñadirproducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblFechavencimiento;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAñadirproducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}