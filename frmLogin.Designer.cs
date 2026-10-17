namespace pryTesisVentas
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pcbContra = new System.Windows.Forms.PictureBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblYaTienesCuenta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCrearCuenta = new System.Windows.Forms.Label();
            this.btnSig = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.pnlCrearCuenta = new System.Windows.Forms.Panel();
            this.pnlBranding = new System.Windows.Forms.Panel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlCreaCuenta = new System.Windows.Forms.Panel();
            this.pnlAccesoLogin = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pcbContra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.pnlCrearCuenta.SuspendLayout();
            this.pnlBranding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlCreaCuenta.SuspendLayout();
            this.pnlAccesoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbContra
            // 
            this.pcbContra.Location = new System.Drawing.Point(570, 169);
            this.pcbContra.Name = "pcbContra";
            this.pcbContra.Size = new System.Drawing.Size(28, 32);
            this.pcbContra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbContra.TabIndex = 34;
            this.pcbContra.TabStop = false;
            this.pcbContra.Click += new System.EventHandler(this.pcbContra_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNombre.Location = new System.Drawing.Point(32, 69);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(294, 41);
            this.txtNombre.TabIndex = 21;
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // pctLogo
            // 
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(2, 2);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(62, 66);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLogo.TabIndex = 33;
            this.pctLogo.TabStop = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(250, 21);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(98, 52);
            this.btnIngresar.TabIndex = 30;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblYaTienesCuenta
            // 
            this.lblYaTienesCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYaTienesCuenta.AutoSize = true;
            this.lblYaTienesCuenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYaTienesCuenta.Location = new System.Drawing.Point(19, 27);
            this.lblYaTienesCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYaTienesCuenta.Name = "lblYaTienesCuenta";
            this.lblYaTienesCuenta.Size = new System.Drawing.Size(205, 28);
            this.lblYaTienesCuenta.TabIndex = 29;
            this.lblYaTienesCuenta.Text = "¿Ya tienes una cuenta?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 43);
            this.label2.TabIndex = 28;
            this.label2.Text = "DigitalFarma";
            // 
            // lblCrearCuenta
            // 
            this.lblCrearCuenta.AutoSize = true;
            this.lblCrearCuenta.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCuenta.Location = new System.Drawing.Point(110, 0);
            this.lblCrearCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCrearCuenta.Name = "lblCrearCuenta";
            this.lblCrearCuenta.Size = new System.Drawing.Size(441, 70);
            this.lblCrearCuenta.TabIndex = 27;
            this.lblCrearCuenta.Text = "Crear una cuenta";
            // 
            // btnSig
            // 
            this.btnSig.BackColor = System.Drawing.Color.Teal;
            this.btnSig.FlatAppearance.BorderSize = 0;
            this.btnSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSig.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSig.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSig.Location = new System.Drawing.Point(34, 235);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(573, 42);
            this.btnSig.TabIndex = 25;
            this.btnSig.Text = "SIGUIENTE";
            this.btnSig.UseVisualStyleBackColor = false;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMail.Location = new System.Drawing.Point(32, 116);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(575, 41);
            this.txtMail.TabIndex = 24;
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtContra.Location = new System.Drawing.Point(30, 169);
            this.txtContra.Multiline = true;
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(577, 36);
            this.txtContra.TabIndex = 23;
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtApellido.Location = new System.Drawing.Point(332, 69);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(275, 41);
            this.txtApellido.TabIndex = 22;
            this.txtApellido.Enter += new System.EventHandler(this.txtApellido_Enter);
            this.txtApellido.Leave += new System.EventHandler(this.txtApellido_Leave);
            // 
            // pnlCrearCuenta
            // 
            this.pnlCrearCuenta.BackColor = System.Drawing.Color.Teal;
            this.pnlCrearCuenta.Controls.Add(this.pnlBranding);
            this.pnlCrearCuenta.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCrearCuenta.Location = new System.Drawing.Point(964, 0);
            this.pnlCrearCuenta.MaximumSize = new System.Drawing.Size(700, 0);
            this.pnlCrearCuenta.Name = "pnlCrearCuenta";
            this.pnlCrearCuenta.Size = new System.Drawing.Size(600, 921);
            this.pnlCrearCuenta.TabIndex = 20;
            // 
            // pnlBranding
            // 
            this.pnlBranding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBranding.Controls.Add(this.lblBienvenido);
            this.pnlBranding.Controls.Add(this.pictureBox1);
            this.pnlBranding.Location = new System.Drawing.Point(165, 290);
            this.pnlBranding.Name = "pnlBranding";
            this.pnlBranding.Size = new System.Drawing.Size(247, 279);
            this.pnlBranding.TabIndex = 19;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBienvenido.Location = new System.Drawing.Point(29, 192);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(201, 68);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenido a \r\nDigitalFarma";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pnlCreaCuenta
            // 
            this.pnlCreaCuenta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCreaCuenta.Controls.Add(this.pcbContra);
            this.pnlCreaCuenta.Controls.Add(this.lblCrearCuenta);
            this.pnlCreaCuenta.Controls.Add(this.txtApellido);
            this.pnlCreaCuenta.Controls.Add(this.txtNombre);
            this.pnlCreaCuenta.Controls.Add(this.txtContra);
            this.pnlCreaCuenta.Controls.Add(this.txtMail);
            this.pnlCreaCuenta.Controls.Add(this.btnSig);
            this.pnlCreaCuenta.Location = new System.Drawing.Point(325, 290);
            this.pnlCreaCuenta.Name = "pnlCreaCuenta";
            this.pnlCreaCuenta.Size = new System.Drawing.Size(638, 304);
            this.pnlCreaCuenta.TabIndex = 35;
            // 
            // pnlAccesoLogin
            // 
            this.pnlAccesoLogin.Controls.Add(this.btnIngresar);
            this.pnlAccesoLogin.Controls.Add(this.lblYaTienesCuenta);
            this.pnlAccesoLogin.Location = new System.Drawing.Point(607, 0);
            this.pnlAccesoLogin.Name = "pnlAccesoLogin";
            this.pnlAccesoLogin.Size = new System.Drawing.Size(351, 81);
            this.pnlAccesoLogin.TabIndex = 36;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnSig;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 921);
            this.Controls.Add(this.pnlCrearCuenta);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.pnlAccesoLogin);
            this.Controls.Add(this.pnlCreaCuenta);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Resize += new System.EventHandler(this.frmLogin_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pcbContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.pnlCrearCuenta.ResumeLayout(false);
            this.pnlBranding.ResumeLayout(false);
            this.pnlBranding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlCreaCuenta.ResumeLayout(false);
            this.pnlCreaCuenta.PerformLayout();
            this.pnlAccesoLogin.ResumeLayout(false);
            this.pnlAccesoLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pcbContra;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblYaTienesCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCrearCuenta;
        private System.Windows.Forms.Button btnSig;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Panel pnlCrearCuenta;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlCreaCuenta;
        private System.Windows.Forms.Panel pnlBranding;
        private System.Windows.Forms.Panel pnlAccesoLogin;
    }
}