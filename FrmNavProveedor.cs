using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace pryTesisVentas
{
    public partial class FrmNavProveedor : Form
    {
        private readonly string _nombreProveedor;
        private readonly string _urlProveedor;
        public FrmNavProveedor(string nombreProveedor, string urlProveedor)
        {
            InitializeComponent();
            _nombreProveedor = nombreProveedor;
            _urlProveedor = urlProveedor;
        }

        private async void FrmNavProveedor_Load(object sender, EventArgs e)
        {
            LblUrlActual.Text = _nombreProveedor;

            if (string.IsNullOrWhiteSpace(_urlProveedor))
            {
                MessageBox.Show("Este proveedor no tiene una URL configurada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inicializa el motor de WebView2
            await webView21.EnsureCoreWebView2Async();

            // Actualiza la barra cuando cambia de página dentro del sitio
            webView21.CoreWebView2.NavigationCompleted += (s, args) =>
            {
                if (args.IsSuccess)
                {
                    LblUrlActual.Text = webView21.CoreWebView2.Source;
                    BtnAtras.Enabled = webView21.CoreWebView2.CanGoBack;
                    BtnAdelante.Enabled = webView21.CoreWebView2.CanGoForward;
                }
            };

            // Navega hacia la web del proveedor
            webView21.CoreWebView2.Navigate(_urlProveedor);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2?.CanGoBack == true)
                webView21.CoreWebView2.GoBack();
        }

        private void BtnAdelante_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2?.CanGoForward == true)
                webView21.CoreWebView2.GoForward();
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2?.Reload();
        }
    }
}
