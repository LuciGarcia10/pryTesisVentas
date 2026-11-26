namespace pryTesisVentas
{
    partial class FrmNavProveedor
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
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAtras = new System.Windows.Forms.Button();
            this.BtnAdelante = new System.Windows.Forms.Button();
            this.BtnRecargar = new System.Windows.Forms.Button();
            this.LblUrlActual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(800, 562);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblUrlActual);
            this.panel1.Controls.Add(this.BtnRecargar);
            this.panel1.Controls.Add(this.BtnAdelante);
            this.panel1.Controls.Add(this.BtnAtras);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 40);
            this.panel1.TabIndex = 1;
            // 
            // BtnAtras
            // 
            this.BtnAtras.Location = new System.Drawing.Point(12, 3);
            this.BtnAtras.Name = "BtnAtras";
            this.BtnAtras.Size = new System.Drawing.Size(80, 34);
            this.BtnAtras.TabIndex = 0;
            this.BtnAtras.Text = "Atrás";
            this.BtnAtras.UseVisualStyleBackColor = true;
            this.BtnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // BtnAdelante
            // 
            this.BtnAdelante.Location = new System.Drawing.Point(98, 3);
            this.BtnAdelante.Name = "BtnAdelante";
            this.BtnAdelante.Size = new System.Drawing.Size(80, 34);
            this.BtnAdelante.TabIndex = 1;
            this.BtnAdelante.Text = "Adelante";
            this.BtnAdelante.UseVisualStyleBackColor = true;
            this.BtnAdelante.Click += new System.EventHandler(this.BtnAdelante_Click);
            // 
            // BtnRecargar
            // 
            this.BtnRecargar.Location = new System.Drawing.Point(184, 3);
            this.BtnRecargar.Name = "BtnRecargar";
            this.BtnRecargar.Size = new System.Drawing.Size(80, 34);
            this.BtnRecargar.TabIndex = 2;
            this.BtnRecargar.Text = "Recargar";
            this.BtnRecargar.UseVisualStyleBackColor = true;
            this.BtnRecargar.Click += new System.EventHandler(this.BtnRecargar_Click);
            // 
            // LblUrlActual
            // 
            this.LblUrlActual.BackColor = System.Drawing.Color.White;
            this.LblUrlActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblUrlActual.Location = new System.Drawing.Point(270, 7);
            this.LblUrlActual.Name = "LblUrlActual";
            this.LblUrlActual.Size = new System.Drawing.Size(518, 27);
            this.LblUrlActual.TabIndex = 3;
            // 
            // FrmNavProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webView21);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmNavProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navegador del proveedor";
            this.Load += new System.EventHandler(this.FrmNavProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnRecargar;
        private System.Windows.Forms.Button BtnAdelante;
        private System.Windows.Forms.Button BtnAtras;
        private System.Windows.Forms.Label LblUrlActual;
    }
}