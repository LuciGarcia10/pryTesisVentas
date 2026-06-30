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
            this.lblOlvidasteContra = new System.Windows.Forms.LinkLabel();
            this.chkRecordar = new System.Windows.Forms.CheckBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.lblNoTienesCuenta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCrearCuenta = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIngresar
            // 
            this.pnlIngresar.BackColor = System.Drawing.Color.Teal;
            this.pnlIngresar.Location = new System.Drawing.Point(593, -1);
            this.pnlIngresar.Name = "pnlIngresar";
            this.pnlIngresar.Size = new System.Drawing.Size(191, 416);
            this.pnlIngresar.TabIndex = 45;
            // 
            // lblOlvidasteContra
            // 
            this.lblOlvidasteContra.AutoSize = true;
            this.lblOlvidasteContra.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOlvidasteContra.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOlvidasteContra.Location = new System.Drawing.Point(332, 238);
            this.lblOlvidasteContra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOlvidasteContra.Name = "lblOlvidasteContra";
            this.lblOlvidasteContra.Size = new System.Drawing.Size(153, 16);
            this.lblOlvidasteContra.TabIndex = 44;
            this.lblOlvidasteContra.TabStop = true;
            this.lblOlvidasteContra.Text = "¿Olvidaste tu contraseña?";
            // 
            // chkRecordar
            // 
            this.chkRecordar.AutoSize = true;
            this.chkRecordar.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRecordar.Location = new System.Drawing.Point(147, 238);
            this.chkRecordar.Margin = new System.Windows.Forms.Padding(2);
            this.chkRecordar.Name = "chkRecordar";
            this.chkRecordar.Size = new System.Drawing.Size(148, 20);
            this.chkRecordar.TabIndex = 43;
            this.chkRecordar.Text = "Recordar credenciales";
            this.chkRecordar.UseVisualStyleBackColor = true;
            // 
            // pctLogo
            // 
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(2, 8);
            this.pctLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(41, 44);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLogo.TabIndex = 42;
            this.pctLogo.TabStop = false;
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCuenta.Location = new System.Drawing.Point(490, 15);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(97, 26);
            this.btnCrearCuenta.TabIndex = 41;
            this.btnCrearCuenta.Text = "Crear cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // lblNoTienesCuenta
            // 
            this.lblNoTienesCuenta.AutoSize = true;
            this.lblNoTienesCuenta.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTienesCuenta.Location = new System.Drawing.Point(302, 20);
            this.lblNoTienesCuenta.Name = "lblNoTienesCuenta";
            this.lblNoTienesCuenta.Size = new System.Drawing.Size(186, 16);
            this.lblNoTienesCuenta.TabIndex = 40;
            this.lblNoTienesCuenta.Text = "¿Todavía no tienes una cuenta?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 28);
            this.label2.TabIndex = 39;
            this.label2.Text = "DigitalFarma";
            // 
            // lblCrearCuenta
            // 
            this.lblCrearCuenta.AutoSize = true;
            this.lblCrearCuenta.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCuenta.Location = new System.Drawing.Point(175, 114);
            this.lblCrearCuenta.Name = "lblCrearCuenta";
            this.lblCrearCuenta.Size = new System.Drawing.Size(270, 32);
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
            this.btnIngresar.Location = new System.Drawing.Point(147, 263);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(331, 29);
            this.btnIngresar.TabIndex = 37;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMail.Location = new System.Drawing.Point(147, 169);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(332, 29);
            this.txtMail.TabIndex = 36;
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtContra.Location = new System.Drawing.Point(147, 201);
            this.txtContra.Multiline = true;
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(332, 29);
            this.txtContra.TabIndex = 35;
            this.txtContra.Enter += new System.EventHandler(this.txtContra_Enter);
            this.txtContra.Leave += new System.EventHandler(this.txtContra_Leave);
            // 
            // frmIngresar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 410);
            this.Controls.Add(this.pnlIngresar);
            this.Controls.Add(this.lblOlvidasteContra);
            this.Controls.Add(this.chkRecordar);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.lblNoTienesCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCrearCuenta);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtContra);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmIngresar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIngresar";
            this.Load += new System.EventHandler(this.frmIngresar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlIngresar;
        private System.Windows.Forms.LinkLabel lblOlvidasteContra;
        private System.Windows.Forms.CheckBox chkRecordar;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Label lblNoTienesCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCrearCuenta;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtContra;
    }
}