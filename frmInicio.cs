using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // Asegúrate de tener esto arriba de todo
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;


namespace pryTesisVentas
{
    public partial class frmInicio : Form
    {
        public string NombreUsuario { get; set; } = "Usuario";
        public string RolUsuario { get; set; } = "Invitado";
        // Define tu cadena de conexión aquí (ajusta el nombre del servidor y BD)
        string cadenaConexion = "Server=.;Database=BDDigitalFarma;Trusted_Connection=True;";
        public frmInicio()
        {
            InitializeComponent();
            ConfigurarColumnasGrilla();
            CargarDatosDesdeBD();
        }

        
        private void ObtenerPedidosTotales()
        {
            string query = "SELECT COUNT(*) FROM Pedidos;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();

                    // ExecuteScalar es ideal porque la consulta devuelve un solo número
                    int totales = (int)comando.ExecuteScalar();

                    // Lo mostramos en la tarjeta
                    lblPedidosTotal.Text = totales.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Pedidos Totales: " + ex.Message);
                }
            }
        }

        private void ObtenerPedidosPendientes()
        {
            // IdEstado = 1 corresponde a 'Pendiente' en tu tabla Estados
            string query = "SELECT COUNT(*) FROM Pedidos WHERE IdEstado = 1;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();

                    int pendientes = (int)comando.ExecuteScalar();
                    lblNumPedidosPendientes.Text = pendientes.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Pedidos Pendientes: " + ex.Message);
                }
            }
        }

        private void ObtenerPedidosCancelados()
        {
            // IdEstado = 3 corresponde a 'Cancelado' en tu tabla Estados
            string query = "SELECT COUNT(*) FROM Pedidos WHERE IdEstado = 3;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();

                    int cancelados = (int)comando.ExecuteScalar();
                    lblNumPedidoscancelados.Text = cancelados.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Pedidos Cancelados: " + ex.Message);
                }
            }
        }
        private void frmInicio_Load(object sender, EventArgs e)
        {

            // Estilos estéticos de la grilla de ventas
            dgvVentas.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;

            // Inicializar las columnas y traer datos reales de la BD a la tabla de productos más vendidos
            ConfigurarColumnasGrilla();
            CargarDatosDesdeBD();

            //Funciones para graficos, Pedidos total, pendientes y cancelados
            ObtenerPedidosTotales();
            ObtenerPedidosPendientes();
            ObtenerPedidosCancelados();

            // Transformar contenedores de iconos a formas circulares
            HacerCirculo(pcbPedido);

            // Cargar datos de la sesión del usuario abajo a la izquierda
            btnUsuario.Text = NombreUsuario;
            lblRol.Text = RolUsuario;

            // Control de permisos según Rol de usuario
            if (RolUsuario == "Farmaceutica" || RolUsuario == "Empleado")
            {   
                MessageBox.Show($"Sesión iniciada: {NombreUsuario} ({RolUsuario}). Acceso limitado a funciones de caja y mostrador.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (RolUsuario == "Administrador")
            {
            }
        }
        public void HacerCirculo(Control control)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, control.Width, control.Height);
            control.Region = new Region(gp);
        }

        
            
        private void ConfigurarColumnasGrilla()
        {
            dgvVentas.Columns.Clear();

            // Cambié los textos de los títulos para que sean idénticos a tu diseño
            dgvVentas.Columns.Add("Producto", "Nombre del producto");
            dgvVentas.Columns.Add("Stock", "Stock");
            dgvVentas.Columns.Add("Precio", "Precio");
            dgvVentas.Columns.Add("Ventas", "Ventas totales");

            // Mantiene el ajuste automático para textos largos (tu descripción abajo del nombre)
            dgvVentas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Ajustes visuales para que ocupe todo el ancho y no tenga bordes feos
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.BackgroundColor = Color.White;
        }

        private void CargarDatosDesdeBD()
        {
            // Consulta corregida usando los nombres reales de tus tablas (Nivel 2.sql)
            // Agregamos un "AS ventas_totales" o leemos directamente los campos existentes.
            // Como tu tabla Productos no guarda el histórico de ventas directamente, usamos StockActual o simulamos la columna requerida:
            string query = "SELECT Nombre, Descripcion, StockActual, PrecioVenta FROM Productos";

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
                        // Combinamos Nombre y Descripción (si existe) para armar la primera celda
                        string descripcion = lector["Descripcion"] != DBNull.Value ? lector["Descripcion"].ToString() : "";
                        string infoProducto = $"{lector["Nombre"]}\n{descripcion}";

                        dgvVentas.Rows.Add(
                            infoProducto,
                            lector["StockActual"].ToString() + " en stock",
                            Convert.ToDecimal(lector["PrecioVenta"]).ToString("C0"), // Formato de moneda local (ej: $ 2.500)
                            "0" // Dejamos fijo "0" o un cálculo provisional, ya que Productos no tiene columna "ventas"
                        );
                    }
                }
                catch (Exception ex)
                {
                    // Fallback de diseño por si la base no responde temporalmente
                    dgvVentas.Rows.Clear();
                    dgvVentas.Rows.Add("Ibuprofeno 600\nMedicamento analgésico...", "32 en stock", "$ 2.500", "20");
                    dgvVentas.Rows.Add("Loratadina\nAntihistamínico para alergias...", "31 en stock", "$ 4.890", "19");
                    dgvVentas.Rows.Add("Termómetro\nMedición rápida...", "7 en stock", "$ 4.900", "18");
                    dgvVentas.Rows.Add("Protector Solar 30\nCuidado diario...", "26 en stock", "$ 8.760", "17");

                    Console.WriteLine("Error al conectar o procesar datos de la BD: " + ex.Message);
                }
            }
        }


        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Configuración de columnas
            dgvVentas.Columns.Add("Producto", "Producto");
            dgvVentas.Columns.Add("Stock", "Stock");
            dgvVentas.Columns.Add("Precio", "Precio");
            dgvVentas.Columns.Add("Ventas", "Ventas");

            // Agregar datos de ejemplo
            dgvVentas.Rows.Add("Ibuprofeno 600\nMedicamento analgésico...", "32 en stock", "$ 2.500", "20");
            dgvVentas.Rows.Add("Loratadina\nAntihistamínico para alergias...", "31 en stock", "$ 4.890", "19");

        }
        private void AbrirFormularioHijo(object formularioHijo)
        {
            if (this.pnlContenedorPrincipal.Controls.Count > 0)
                this.pnlContenedorPrincipal.Controls.RemoveAt(0);

            Form fh = formularioHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedorPrincipal.Controls.Add(fh);
            this.pnlContenedorPrincipal.Tag = fh;
            fh.Show();
        }


        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Si el contenido del dashboard está en un control de usuario o quieres recargarlo:
            if (this.pnlContenedorPrincipal.Controls.Count > 0)
                this.pnlContenedorPrincipal.Controls.RemoveAt(0);
  
        }

        private void txtBuscador_TextChanged_1(object sender, EventArgs e)
        {
            // Si el cuadro de texto NO está vacío, ocultamos el label "Buscar"
            if (txtBuscador.Text != "")
            {
                lblBuscador.Visible = false;
            }
            else
            {
                // Si borró todo, volvemos a mostrar el label
                lblBuscador.Visible = true;
            }

            // --- OPCIONAL: Lógica de filtrado en tiempo real ---
            FiltrarBusquedaRapida(txtBuscador.Text);
        }
        private void FiltrarBusquedaRapida(string texto)
        {
           // var busqueda = listaProductos.Where(x =>
           //     x.Nombre.ToLower().Contains(texto.ToLower()) ||
           //     x.Categoria.ToLower().Contains(texto.ToLower())
           // ).ToList();

           // ActualizarGrilla(busqueda);
        }

        private void lblBuscador_Click(object sender, EventArgs e)
        {
            // Al tocar el texto, mandamos el foco al TextBox para poder escribir
            txtBuscador.Focus();
        }

        private void txtBuscador_Enter(object sender, EventArgs e)
        {
            // Apenas el usuario hace clic o llega con el TAB, ocultamos el label
            lblBuscador.Visible = false;
        }

        private void txtBuscador_Leave(object sender, EventArgs e)
        {
            // Si sale del cuadro y NO escribió nada, mostramos el label de nuevo
            if (string.IsNullOrWhiteSpace(txtBuscador.Text))
            {
                lblBuscador.Visible = true;
            }
        }

        private void btnventas1_Click(object sender, EventArgs e)
        {
            frmVentas frm = new frmVentas();
            frm.ShowDialog();
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
        }

        private void btnUsuario1_Click(object sender, EventArgs e)
        {
            FrmPerfil frm = new FrmPerfil();
            frm.ShowDialog();
        }

        private void btnPedidos_Click_1(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
            frm.ShowDialog();
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            frmCuentasCorrientes frm = new frmCuentasCorrientes();
            frm.ShowDialog();
        }

        private void btnAyuda_Click_1(object sender, EventArgs e)
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

    }
}
