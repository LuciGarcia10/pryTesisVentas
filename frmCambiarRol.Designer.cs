namespace pryTesisVentas
{
    partial class frmCambiarRol
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
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Items.AddRange(new object[] {
            "Farmaceutico",
            "Empleado"});
            this.cmbRoles.Location = new System.Drawing.Point(75, 26);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(121, 28);
            this.cmbRoles.TabIndex = 0;
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.BackColor = System.Drawing.Color.Teal;
            this.btnGuardarPermisos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPermisos.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPermisos.Location = new System.Drawing.Point(19, 153);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(177, 34);
            this.btnGuardarPermisos.TabIndex = 2;
            this.btnGuardarPermisos.Text = "Guardar Permisos";
            this.btnGuardarPermisos.UseVisualStyleBackColor = false;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoles.Location = new System.Drawing.Point(12, 25);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(57, 25);
            this.lblRoles.TabIndex = 3;
            this.lblRoles.Text = "Roles";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(75, 92);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 28);
            this.cmbEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(10, 92);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(67, 25);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado";
            // 
            // frmCambiarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 213);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.btnGuardarPermisos);
            this.Controls.Add(this.cmbRoles);
            this.Name = "frmCambiarRol";
            this.Text = "frmCambiarRol";
            this.Load += new System.EventHandler(this.frmCambiarRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnGuardarPermisos;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}