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
        // Define tu cadena de conexión aquí (ajusta el nombre del servidor y BD)
        string cadenaConexion = "Server=TU_SERVIDOR;Database=DigitalFarma;Trusted_Connection=True;";
        public frmInicio()
        {
            InitializeComponent();
           
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            try
            {
                // GANANCIAS (Mes Actual) - Usamos el Label lblGanancias
                decimal gananciasMes = clsConsultas.ObtenerGananciasMesActual();
                if (gananciasMes >= 1000)
                    lblGanancias.Text = "$" + (gananciasMes / 1000).ToString("N1") + "k";
                else
                    lblGanancias.Text = gananciasMes.ToString("C0");

                // BALANCE (Ventas - Compras) - Usamos el Label lblBalance
                decimal balanceTotal = clsConsultas.ObtenerBalanceTotal();
                if (Math.Abs(balanceTotal) >= 1000)
                    lblBalance.Text = "$" + (balanceTotal / 1000).ToString("N1") + "k";
                else
                    lblBalance.Text = balanceTotal.ToString("C0");

                // Color del Balance: Rojo si es pérdida, Gris oscuro si es ganancia
                lblBalance.ForeColor = (balanceTotal < 0) ? Color.Red : Color.FromArgb(64, 64, 64);

                // PEDIDOS TOTALES (Cuadrito de la derecha)
                decimal cantPedidos = clsConsultas.ObtenerTotalVentas();
                if (cantPedidos >= 1000)
                    lblPedidosTotales.Text = (cantPedidos / 1000).ToString("N1") + "k";
                else
                    lblPedidosTotales.Text = cantPedidos.ToString("N0"); // "N0" porque son unidades, no pesos
            }
            catch (Exception ex)
            {
                // Si hay error en la base, lo vemos en la consola pero el programa sigue
                Console.WriteLine("Error al cargar indicadores: " + ex.Message);
            }

            // AJUSTE DE GRÁFICOS (UI) 
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

            // GRÁFICO DE BARRAS (GANANCIAS MENSUALES) 
            crtGananciasMensuales.Series.Clear();
            var serieGanancias = crtGananciasMensuales.Series.Add("Ganancias");
            serieGanancias.ChartType = SeriesChartType.Column;

            string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            double[] valores = { 45, 52, 68, 50, 40, 52, 58, 95, 70, 62, 48, 65 };

            for (int i = 0; i < meses.Length; i++)
            {
                int p = serieGanancias.Points.AddXY(meses[i], valores[i]);
                // Color verde DigitalFarma para Agosto, celeste para el resto
                serieGanancias.Points[p].Color = (meses[i] == "Ago") ? Color.FromArgb(0, 182, 147) : Color.FromArgb(220, 243, 239);
            }
            crtGananciasMensuales.ChartAreas[0].AxisX.Interval = 1;

            // ESTILOS DE TABLAS Y CÍRCULOS
            ConfigurarGraficoClientes();

            dgvVentas.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;

            // Iconos circulares 
            HacerCirculo(pcbGanancias);
            HacerCirculo(pcbBalance);
            HacerCirculo(pcbPedido);
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
            // Si ya hay algo en el panel, lo quitamos
            if (this.pnlContenedorPrincipal.Controls.Count > 0)
                this.pnlContenedorPrincipal.Controls.RemoveAt(0);

            Form fh = formularioHijo as Form;
            fh.TopLevel = false; // Importante: no es de nivel superior
            fh.Dock = DockStyle.Fill; // Que ocupe todo el panel
            this.pnlContenedorPrincipal.Controls.Add(fh);
            this.pnlContenedorPrincipal.Tag = fh;
            fh.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas  frm= new frmVentas();
            frm.ShowDialog();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Si el contenido del dashboard está en un control de usuario o quieres recargarlo:
            //if (this.panelContenedorPrincipal.Controls.Count > 0)
             //   this.panelContenedorPrincipal.Controls.RemoveAt(0);

            // Aquí podrías recargar los gráficos iniciales
           // ConfigurarGraficoClientes();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
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

        private void chartClientes_Click_1(object sender, EventArgs e)
        {

        }


        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmPerfil frm = new FrmPerfil();
            frm.ShowDialog();

        /*private void pnlClintes_Paint(object sender, PaintEventArgs e)
        {


        }*/



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
}
