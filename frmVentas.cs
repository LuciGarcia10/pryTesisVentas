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
        // Lista global para guardar los productos en la memoria de la PC
        List<Producto> listaProductos = new List<Producto>();
        // Cadena de conexión a tu base de datos en Córdoba
        //string cadenaConexion = "Server=.; Database=BDDigitalFarma; Integrated Security=True";
        

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            // CONFIGURACIÓN DE LA GRILLA

            // 1. ESTO VA PRIMERO: Apagamos el generador automático antes de hacer nada

            dgvVentas.AutoGenerateColumns = false;

        }
        

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Dejalo vacío o usalo si el usuario hace clic en un botón específico dentro de la fila (como "Editar" o "Eliminar")
            // Queda vacío y limpio para acciones específicas (ej. si agregás un botón de acción por fila)
            // Configuración de columnas
            dgvVentas.Columns.Add("Producto", "Producto");
            dgvVentas.Columns.Add("Stock", "Stock");
            dgvVentas.Columns.Add("Precio", "Precio");
            dgvVentas.Columns.Add("Ventas", "Ventas");
            // Agregar datos de ejemplo
            dgvVentas.Rows.Add("Ibuprofeno 600\nMedicamento analgésico...", "32 en stock", "$ 2.500", "20");
            dgvVentas.Rows.Add("Loratadina\nAntihistamínico para alergias...", "31 en stock", "$ 4.890", "19");
        }
        // 3. Método auxiliar para refrescar la grilla de forma limpia
        public void ActualizarGrilla(List<Producto> lista)
        {
            dgvVentas.DataSource = null; // Limpia el origen anterior para forzar el refresco
            dgvVentas.DataSource = lista; // Asigna la nueva lista ordenada
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Corregimos la consistencia interna con txtBuscador
            if (txtBuscador.Text != "")
            {
                lblBuscador.Visible = false;
            }
            else
            {
                lblBuscador.Visible = true;
            }
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
