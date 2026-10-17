namespace pryTesisVentas
{
    partial class frmIngresar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresar));
            this.pnlIngresar = new System.Windows.Forms.Panel();
            this.chkRecordar = new System.Windows.Forms.CheckBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.lblNoTienesCuenta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCrearCuenta = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.lnkOlvidasteContraseña = new System.Windows.Forms.LinkLabel();
            this.pnlIngresa = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.pnlIngresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlIngresar
            // 
            this.pnlIngresar.BackColor = System.Drawing.Color.Teal;
            this.pnlIngresar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlIngresar.Location = new System.Drawing.Point(895, 0);
            this.pnlIngresar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlIngresar.Name = "pnlIngresar";
            this.pnlIngresar.Size = new System.Drawing.Size(600, 824);
            this.pnlIngresar.TabIndex = 45;
            // 
            // chkRecordar
            // 
            this.chkRecordar.AutoSize = true;
            this.chkRecordar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRecordar.Location = new System.Drawing.Point(71, 220);
            this.chkRecordar.Name = "chkRecordar";
            this.chkRecordar.Size = new System.Drawing.Size(208, 29);
            this.chkRecordar.TabIndex = 43;
            this.chkRecordar.Text = "Recordar credenciales";
            this.chkRecordar.UseVisualStyleBackColor = true;
            // 
            // pctLogo
            // 
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(3, 12);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(62, 68);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLogo.TabIndex = 42;
            this.pctLogo.TabStop = false;
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearCuenta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCuenta.Location = new System.Drawing.Point(700, 23);
            this.btnCrearCuenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(187, 40);
            this.btnCrearCuenta.TabIndex = 41;
            this.btnCrearCuenta.Text = "Crear cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // lblNoTienesCuenta
            // 
            this.lblNoTienesCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoTienesCuenta.AutoSize = true;
            this.lblNoTienesCuenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTienesCuenta.Location = new System.Drawing.Point(406, 31);
            this.lblNoTienesCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoTienesCuenta.Name = "lblNoTienesCuenta";
            this.lblNoTienesCuenta.Size = new System.Drawing.Size(281, 28);
            this.lblNoTienesCuenta.TabIndex = 40;
            this.lblNoTienesCuenta.Text = "¿Todavía no tienes una cuenta?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 43);
            this.label2.TabIndex = 39;
            this.label2.Text = "DigitalFarma";
            // 
            // lblCrearCuenta
            // 
            this.lblCrearCuenta.AutoSize = true;
            this.lblCrearCuenta.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCuenta.Location = new System.Drawing.Point(113, 29);
            this.lblCrearCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCrearCuenta.Name = "lblCrearCuenta";
            this.lblCrearCuenta.Size = new System.Drawing.Size(493, 70);
            this.lblCrearCuenta.TabIndex = 38;
            this.lblCrearCuenta.Text = "Ingresa a tu cuenta";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.Teal;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIngresar.Location = new System.Drawing.Point(71, 259);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(573, 45);
            this.btnIngresar.TabIndex = 37;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMail.Location = new System.Drawing.Point(71, 114);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(573, 42);
            this.txtMail.TabIndex = 36;
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtContra.Location = new System.Drawing.Point(71, 163);
            this.txtContra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContra.Multiline = true;
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(573, 42);
            this.txtContra.TabIndex = 35;
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // lnkOlvidasteContraseña
            // 
            this.lnkOlvidasteContraseña.AutoSize = true;
            this.lnkOlvidasteContraseña.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOlvidasteContraseña.Location = new System.Drawing.Point(429, 222);
            this.lnkOlvidasteContraseña.Name = "lnkOlvidasteContraseña";
            this.lnkOlvidasteContraseña.Size = new System.Drawing.Size(214, 25);
            this.lnkOlvidasteContraseña.TabIndex = 46;
            this.lnkOlvidasteContraseña.TabStop = true;
            this.lnkOlvidasteContraseña.Text = "¿Olvidaste tu contraseña?";
            this.lnkOlvidasteContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOlvidasteContraseña_LinkClicked);
            // 
            // pnlIngresa
            // 
            this.pnlIngresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlIngresa.Controls.Add(this.lblCrearCuenta);
            this.pnlIngresa.Controls.Add(this.lnkOlvidasteContraseña);
            this.pnlIngresa.Controls.Add(this.txtContra);
            this.pnlIngresa.Controls.Add(this.txtMail);
            this.pnlIngresa.Controls.Add(this.chkRecordar);
            this.pnlIngresa.Controls.Add(this.btnIngresar);
            this.pnlIngresa.Location = new System.Drawing.Point(161, 170);
            this.pnlIngresa.Name = "pnlIngresa";
            this.pnlIngresa.Size = new System.Drawing.Size(669, 318);
            this.pnlIngresa.TabIndex = 47;
            // 
            // frmIngresar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 824);
            this.Controls.Add(this.pnlIngresa);
            this.Controls.Add(this.pnlIngresar);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.lblNoTienesCuenta);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIngresar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIngresar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIngresar_Load);
            this.Resize += new System.EventHandler(this.frmIngresar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.pnlIngresa.ResumeLayout(false);
            this.pnlIngresa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlIngresar;
        private System.Windows.Forms.CheckBox chkRecordar;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Label lblNoTienesCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCrearCuenta;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.LinkLabel lnkOlvidasteContraseña;
        private System.Windows.Forms.Panel pnlIngresa;
    }
}