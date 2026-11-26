using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmNuevoPedido : Form
    {
        private readonly DataTable dtProductos = new DataTable();
        private readonly DataTable dtProveedores = new DataTable();
        public frmNuevoPedido()
        {
            InitializeComponent();
            CargarProductosDesdeBase();
        }

        
        private void frmNuevoPedido_Load(object sender, EventArgs e)
        {
            CargarProductosDesdeBase();
            CargarProveedoresDesdeBase();
        }
        
        private void CargarProductosDesdeBase()
        {
            string cadenaConexion = clsConsultas.cadena;
            // Traemos también PrecioVenta para calcular los importes reales
            string query = "SELECT IdProducto, Nombre, PrecioVenta FROM Productos ORDER BY Nombre ASC";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    dtProductos.Clear();
                    adaptador.Fill(dtProductos);

                    cmbProductos.DisplayMember = "Nombre";
                    cmbProductos.ValueMember = "IdProducto";
                    cmbProductos.DataSource = dtProductos;

                    cmbProductos.SelectedIndex = -1;
                    cmbProductos.Text = "Escribir o elegir producto...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los productos de la base: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarProveedoresDesdeBase()
        {
            string cadenaConexion = clsConsultas.cadena;
            // Ajustá los nombres de columnas si en tu tabla Proveedores se llaman distinto
            string query = "SELECT IdProveedor, Nombre, Canal, UrlWeb, TelefonoWhatsApp FROM Proveedores ORDER BY Nombre ASC";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    dtProveedores.Clear();
                    adaptador.Fill(dtProveedores);

                    cmbProveedores.DisplayMember = "Nombre";
                    cmbProveedores.ValueMember = "IdProveedor";
                    cmbProveedores.DataSource = dtProveedores;

                    cmbProveedores.SelectedIndex = -1;
                    cmbProveedores.Text = "Elegir Proveedor...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los proveedores de la base: " + ex.Message,
                        "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCanalProveedor_Click(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedIndex == -1 || !(cmbProveedores.SelectedItem is DataRowView filaProv))
            {
                MessageBox.Show("Por favor, seleccioná un proveedor.", "DigitalFarma",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreProveedor = filaProv["Nombre"]?.ToString().Trim() ?? "";
            string canal = filaProv["Canal"]?.ToString().Trim() ?? "";

            if (string.Equals(canal, "Web", StringComparison.OrdinalIgnoreCase))
            {
                string urlProveedor = filaProv["UrlWeb"]?.ToString().Trim() ?? "";

                var frmWeb = new FrmNavProveedor(nombreProveedor, urlProveedor);
                frmWeb.Show();
            }
            else if (string.Equals(canal, "WhatsApp", StringComparison.OrdinalIgnoreCase))
            {
                string telefonoProveedor = filaProv["TelefonoWhatsApp"]?.ToString().Trim() ?? "";
                string productoInicial = cmbProductos.SelectedIndex != -1 ? cmbProductos.Text.Trim() : "";

                // Reemplazá FrmPedidoWhatsApp por el nombre real del formulario de WhatsApp que crees
               //////// var frmWpp = new FrmPedidoWhatsApp(nombreProveedor, telefonoProveedor, productoInicial);
               ////// frmWpp.ShowDialog();
            }
            else
            {
                MessageBox.Show("El proveedor seleccionado no tiene un canal (Web o WhatsApp) configurado.",
                    "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
