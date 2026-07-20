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
    {// Lista global para guardar los productos en la memoria de la PC
        List<Producto> listaProductos = new List<Producto>();

        // 🌟 CADENA DE CONEXIÓN ACTIVADA
        string cadenaConexion = "Server=.; Database=BDDigitalFarma; Integrated Security=True";

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            /// 1. Apagamos el generador automático de columnas
            dgvVentas.AutoGenerateColumns = false;

            // 2. Creamos la estructura visual de las columnas de tu grilla
            ConfigurarColumnasGrilla();

            // 3. 🌟 TRAEMOS LOS DATOS REALES DE SQL
            CargarDatosDesdeBD();
        }

        private void ConfigurarColumnasGrilla()
        {
            
            // ====================================================================
            // 🎨 ESTILIZACIÓN IDÉNTICA A CUENTAS CORRIENTES
            // ====================================================================

            // 1. Bordes y estructura general
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentas.GridColor = Color.FromArgb(240, 240, 240);
            dgvVentas.RowHeadersVisible = false; // Quitamos la columna gris de la izquierda
            dgvVentas.AllowUserToAddRows = false; // Evita la fila vacía extra al final

            // 2. Encabezados (Gris claro fijo y centrado)
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(110, 110, 110);
            dgvVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVentas.ColumnHeadersHeight = 40;

            // 3. Filas, Selección y Ajuste de texto para Medicamentos
            dgvVentas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvVentas.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245); // Tu verde agua
            dgvVentas.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Le da aire a las celdas y permite múltiples líneas por la descripción médica
            dgvVentas.DefaultCellStyle.Padding = new Padding(10);
            dgvVentas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 4. Dimensiones y autoajuste de ancho
            dgvVentas.RowTemplate.Height = 50;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosDesdeBD()
        {
            // Usamos las columnas reales de tu tabla de SQL Server
            string query = "SELECT Nombre, StockActual, PrecioVenta FROM Productos";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataReader lector = comando.ExecuteReader();

                    dgvVentas.Rows.Clear();

                    while (lector.Read())
                    {
                        // 1. Creamos un índice de fila nueva en la grilla
                        int n = dgvVentas.Rows.Add();

                        // 2. Metemos cada dato apuntando al (Name) o al orden de la columna que hiciste en el diseñador
                        dgvVentas.Rows[n].Cells["colProducto"].Value = lector["Nombre"].ToString();
                        dgvVentas.Rows[n].Cells["colStock"].Value = lector["StockActual"].ToString() + " en stock";
                        dgvVentas.Rows[n].Cells["colPrecio"].Value = "$ " + lector["PrecioVenta"].ToString();
                        dgvVentas.Rows[n].Cells["colVentas"].Value = "0"; // Tu campo fijo temporal
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            // Lógica para cuando utilices mapeo directo de objetos de la lista
            // var busqueda = listaProductos.Where(x =>
            //     x.Nombre.ToLower().Contains(texto.ToLower()) ||
            //     x.Categoria.ToLower().Contains(texto.ToLower())
            // ).ToList();

            // ActualizarGrilla(busqueda);
        }

        private void cmbFiltrar_MouseClick(object sender, MouseEventArgs e)
        {
            frmFiltroVentas ventanaFiltro = new frmFiltroVentas();

            if (this.listaProductos == null)
            {
                this.listaProductos = new List<Producto>();
            }
            ventanaFiltro.listaParaFiltrar = this.listaProductos;

            ventanaFiltro.StartPosition = FormStartPosition.Manual;
            Point puntoAparicion = cmbFiltrar.PointToScreen(new Point(0, cmbFiltrar.Height));
            ventanaFiltro.Location = puntoAparicion;
            ventanaFiltro.ShowDialog();
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
            // Ahora coincide el nombre del método y el del control que dejaste
            if (!string.IsNullOrEmpty(txtBuscador.Text))
            {
                lblBuscador.Visible = false; // Esconde el marcador de posición si escriben
            }
            else
            {
                lblBuscador.Visible = true; // Lo vuelve a mostrar si borran todo
            }
        }

        //Para cargar los datos en la Grilla desde la BD

        // private void ConfigurarColumnasGrilla()
        // {
        //     dgvVentas.Columns.Clear();
        //     dgvVentas.Columns.Add("Producto", "Producto");
        //     dgvVentas.Columns.Add("Stock", "Stock");
        //     dgvVentas.Columns.Add("Precio", "Precio");
        //     dgvVentas.Columns.Add("Ventas", "Ventas");
        //
        //     // Permite que el texto largo de la descripción se vea en varias líneas
        //     dgvVentas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //     dgvVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        // }

        // private void CargarDatosDesdeBD()
        // {
        //     // Consulta SQL (ajusta los nombres de tus columnas reales)
        //     string query = "SELECT nombre, stock, precio, ventas FROM Productos";
        //
        //     using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        //     {
        //         try
        //         {
        //             conexion.Open();
        //             SqlCommand comando = new SqlCommand(query, conexion);
        //             SqlDataReader lector = comando.ExecuteReader();
        //
        //             dgvVentas.Rows.Clear();
        //
        //             while (lector.Read())
        //             {
        //                 dgvVentas.Rows.Add(
        //                     lector["nombre"].ToString(),
        //                     lector["stock"].ToString() + " en stock",
        //                     "$ " + lector["precio"].ToString(),
        //                     lector["ventas"].ToString()
        //                 );
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             // Si falla la BD, mostramos los de ejemplo para no ver la grilla vacía
        //             dgvVentas.Rows.Add("Ibuprofeno 600\n(Error de conexión)", "0", "$ 0", "0");
        //             Console.WriteLine("Error: " + ex.Message);
        //         }
        //     }
        // }
    }
}
