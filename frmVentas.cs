using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pryTesisVentas
{
    public partial class frmVentas : Form
    {
        // Lista en memoria con los datos cargados desde la base de datos
        private List<Producto> listaProductos = new List<Producto>();

        // 🌟 CADENA DE CONEXIÓN ACTIVADA
        private readonly string cadenaConexion = "Server=.; Database=BDDigitalFarma; Integrated Security=True";

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            dgvVentas.AutoGenerateColumns = false;
            ConfigurarColumnasGrilla();
            CargarDatosDesdeBD();
        }

        private void ConfigurarColumnasGrilla()
        {

            // ====================================================================
            // 🎨 ESTILIZACIÓN IDÉNTICA A CUENTAS CORRIENTES
            // ====================================================================

            // Bordes y estructura general
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentas.GridColor = Color.FromArgb(240, 240, 240);
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.AllowUserToAddRows = false;

            // Encabezados
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(110, 110, 110);
            dgvVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVentas.ColumnHeadersHeight = 40;

            // Filas y selección
            dgvVentas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvVentas.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245);
            dgvVentas.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvVentas.DefaultCellStyle.Padding = new Padding(10);
            dgvVentas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Dimensiones
            dgvVentas.RowTemplate.Height = 50;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    

        private void CargarDatosDesdeBD()
        {
            // Usamos las columnas reales de tu tabla de SQL Server
            string query = "SELECT Nombre, StockActual, PrecioVenta FROM Productos";
            listaProductos.Clear();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Producto p = new Producto
                            {
                                Nombre = lector["Nombre"].ToString(),
                                Cantidad = Convert.ToInt32(lector["StockActual"]), // Asigna a Cantidad
                                Precio = Convert.ToDecimal(lector["PrecioVenta"])   // Asigna a Precio
                            };

                            listaProductos.Add(p);
                        }
                    }
                    // Renderizar la lista completa en la grilla
                    MostrarEnGrilla(listaProductos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Dibuja cualquier subconjunto de productos respetando el formato visual
        public void MostrarEnGrilla(List<Producto> lista)
        {
            dgvVentas.Rows.Clear();

            foreach (var prod in lista)
            {
                int n = dgvVentas.Rows.Add();
                dgvVentas.Rows[n].Cells["colProducto"].Value = prod.Nombre;
                dgvVentas.Rows[n].Cells["colStock"].Value = $"{prod.Cantidad} en stock";
                dgvVentas.Rows[n].Cells["colPrecio"].Value = $"$ {prod.Precio:N2}";
                dgvVentas.Rows[n].Cells["colVentas"].Value = "0";
            }
        }

        // 3. Método auxiliar para refrescar la grilla de forma limpia
        public void ActualizarGrilla(List<Producto> lista)
        {
            dgvVentas.DataSource = null; // Limpia el origen anterior para forzar el refresco
            dgvVentas.DataSource = lista; // Asigna la nueva lista ordenada
        }

        
        private void FiltrarBusquedaRapida(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarEnGrilla(listaProductos);
                return;
            }

            string busqueda = texto.Trim().ToLower();

            var filtrados = listaProductos
                .Where(x => x.Nombre != null && x.Nombre.ToLower().Contains(busqueda))
                .ToList();

            MostrarEnGrilla(filtrados);
        }

        private void cmbFiltrar_MouseClick(object sender, MouseEventArgs e)
        {
            frmFiltroVentas ventanaFiltro = new frmFiltroVentas();
            ventanaFiltro.listaParaFiltrar = this.listaProductos;

            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));
            ventanaFiltro.Location = puntoAparicion;

            if (ventanaFiltro.ShowDialog() == DialogResult.OK)
            {
                // Si la ventana de filtros devuelve una lista filtrada, actualizar la grilla:
                //MostrarEnGrilla(ventanaFiltro.listaResultado);
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
            frm.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
            CargarDatosDesdeBD();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmCuentasCorrientes frm = new frmCuentasCorrientes();
            frm.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            frmAyuda frm = new frmAyuda();
            frm.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm = new frmEstadisticas();
            frm.ShowDialog();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            lblBuscador.Visible = string.IsNullOrEmpty(txtBuscador.Text);
            FiltrarBusquedaRapida(txtBuscador.Text);
        }

        
    }
}
