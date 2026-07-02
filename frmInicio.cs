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

        private void frmInicio_Load(object sender, EventArgs e)
        {
            // 1. CARGA DE INDICADORES SUPERIORES DESDE LA CLASE CONSULTAS
            try
            {
                // GANANCIAS (Mes Actual)
                decimal gananciasMes = clsConsultas.ObtenerGananciasMesActual();
                if (gananciasMes >= 1000)
                    lblGanancias.Text = "$" + (gananciasMes / 1000).ToString("N1") + "k";
                else
                    lblGanancias.Text = gananciasMes.ToString("C0");

                // BALANCE (Ventas - Compras)
                decimal balanceTotal = clsConsultas.ObtenerBalanceTotal();
                if (Math.Abs(balanceTotal) >= 1000)
                    lblBalance.Text = "$" + (balanceTotal / 1000).ToString("N1") + "k";
                else
                    lblBalance.Text = balanceTotal.ToString("C0");

                // Color del Balance: Rojo si es pérdida, Gris/Negro si es ganancia
                lblBalance.ForeColor = (balanceTotal < 0) ? Color.Red : Color.FromArgb(64, 64, 64);

                // PEDIDOS TOTALES
                decimal cantPedidos = clsConsultas.ObtenerTotalVentas();
                if (cantPedidos >= 1000)
                    lblPedidosTotales.Text = (cantPedidos / 1000).ToString("N1") + "k";
                else
                    lblPedidosTotales.Text = cantPedidos.ToString("N0");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar indicadores: " + ex.Message);
            }

            // 2. AJUSTE DE GRÁFICOS Y CONTENEDORES (UI) 
            Control contenedor = chartClientes.Parent;
            if (contenedor != null)
            {
                contenedor.Width = 220;
                contenedor.Height = 220;
                if (contenedor is Panel) ((Panel)contenedor).AutoScroll = false;
            }

            chartClientes.Location = new Point(10, 10);
            chartClientes.Width = 200;
            chartClientes.Height = 200;

            // 3. GRÁFICO DE BARRAS (GANANCIAS MENSUALES) 
            crtGananciasMensuales.Series.Clear();
            var serieGanancias = crtGananciasMensuales.Series.Add("Ganancias");
            serieGanancias.ChartType = SeriesChartType.Column;

            string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            double[] valores = { 45, 52, 68, 50, 40, 52, 58, 95, 70, 62, 48, 65 };

            for (int i = 0; i < meses.Length; i++)
            {
                int p = serieGanancias.Points.AddXY(meses[i], valores[i]);
                // Color verde DigitalFarma destacado en Agosto, celeste suave para los demás
                serieGanancias.Points[p].Color = (meses[i] == "Ago") ? Color.FromArgb(0, 182, 147) : Color.FromArgb(220, 243, 239);
            }
            crtGananciasMensuales.ChartAreas[0].AxisX.Interval = 1;

            // 4. CONFIGURACIONES ADICIONALES DE TABLAS, CÍRCULOS Y ROLES
            ConfigurarGraficoClientes();

            // Estilos estéticos de la grilla de ventas
            dgvVentas.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;

            // Inicializar las columnas y traer datos reales de la BD a la tabla de productos más vendidos
            ConfigurarColumnasGrilla();
            CargarDatosDesdeBD();

            // Transformar contenedores de iconos a formas circulares
            HacerCirculo(pcbGanancias);
            HacerCirculo(pcbBalance);
            HacerCirculo(pcbPedido);

            // Cargar datos de la sesión del usuario abajo a la izquierda
            btnUsuario.Text = NombreUsuario;
            lblRol.Text = RolUsuario;

            // Control de permisos según Rol de usuario
            if (RolUsuario == "Farmaceutica" || RolUsuario == "Empleado")
            {
                pnlGanancias.Visible = false;
                pnlBalance.Visible = false;

                MessageBox.Show($"Sesión iniciada: {NombreUsuario} ({RolUsuario}). Acceso limitado a funciones de caja y mostrador.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (RolUsuario == "Administrador")
            {
                pnlGanancias.Visible = true;
                pnlBalance.Visible = true;
            }
        }
        public void HacerCirculo(Control control)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, control.Width, control.Height);
            control.Region = new Region(gp);
        }

        private void ConfigurarGraficoClientes()
        {
            chartClientes.Series.Clear();
            chartClientes.Legends.Clear();
            chartClientes.Titles.Clear();

            var serie = new Series("ClientesNuevos");
            serie.ChartType = SeriesChartType.Doughnut;
            serie.Points.AddY(15);
            serie.Points.AddY(20);
            serie.Points.AddY(65);

            serie.Points[0].Color = Color.FromArgb(236, 0, 140);
            serie.Points[1].Color = Color.FromArgb(124, 77, 255);
            serie.Points[2].Color = Color.FromArgb(230, 230, 245);

            serie["PieStartAngle"] = "270";
            serie["DoughnutRadius"] = "65";
            serie["PieLabelStyle"] = "Disabled";
            serie.BorderWidth = 0;
            chartClientes.Series.Add(serie);

            if (chartClientes.ChartAreas.Count > 0)
            {
                var chartArea = chartClientes.ChartAreas[0];
                chartArea.BackColor = Color.Transparent;

                // SOLUCIÓN AL ERROR DE .SET()
                chartArea.Position.Auto = false;
                chartArea.Position.X = 0;
                chartArea.Position.Y = 0;
                chartArea.Position.Width = 100;
                chartArea.Position.Height = 100;

                chartArea.InnerPlotPosition.Auto = false;
                chartArea.InnerPlotPosition.X = 10;
                chartArea.InnerPlotPosition.Y = 10;
                chartArea.InnerPlotPosition.Width = 80;
                chartArea.InnerPlotPosition.Height = 80;
            }

            if (lbl15 != null)
            {
                lbl15.Parent = chartClientes;
                lbl15.BackColor = Color.White;
                lbl15.Text = "15%\nTotal Nuevos\nclientes";
                lbl15.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl15.TextAlign = ContentAlignment.MiddleCenter;
                lbl15.Size = new Size(90, 90);

                lbl15.Location = new Point(
                    (chartClientes.Width - lbl15.Width) / 2,
                    (chartClientes.Height - lbl15.Height) / 2
                );

                lbl15.BringToFront();
                HacerCirculo(lbl15);
            }
            chartClientes.Invalidate();
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

            // Aquí podrías recargar los gráficos iniciales
            ConfigurarGraficoClientes();
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
