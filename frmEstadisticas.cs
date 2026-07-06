using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pryTesisVentas
{
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            frmInicio frm = new frmInicio();
            frm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frm = new frmVentas();
            frm.ShowDialog();
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

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            // 1. FUNDAMENTAL: Detiene el renderizado fallido en el editor de Visual Studio
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            // 2. CARGA DE INDICADORES SUPERIORES DESDE LA CLASE CONSULTAS
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

                // Color del Balance
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

            // 3. AJUSTE DE CONTENEDORES (UI) 
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

            // 4. LLAMADAS LIMPIAS A TUS MÉTODOS DE CONFIGURACIÓN
            ConfigurarGraficoClientes();
            ConfigurarGraficoBarras(); // Esto ya dibuja las barras y les saca las líneas grises
        }

        private void ConfigurarGraficoBarras()
        {
            crtGananciasMensuales.Series.Clear();
            crtGananciasMensuales.Titles.Clear();

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

            // ESTILIZADO DE EJES (Saca las líneas grises molestas del fondo)
            if (crtGananciasMensuales.ChartAreas.Count > 0)
            {
                var areaBarras = crtGananciasMensuales.ChartAreas[0];
                areaBarras.AxisX.MajorGrid.Enabled = false; // Quita las líneas verticales
                areaBarras.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240); // Líneas horizontales muy suaves
                areaBarras.AxisX.Interval = 1;
                areaBarras.BackColor = Color.White;
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

            // Tus valores simulados
            serie.Points.AddY(15);
            serie.Points.AddY(20);
            serie.Points.AddY(65);

            serie.Points[0].Color = Color.FromArgb(236, 0, 140);   // Rosa fucsia
            serie.Points[1].Color = Color.FromArgb(124, 77, 255);  // Violeta
            serie.Points[2].Color = Color.FromArgb(240, 240, 250);  // Gris/Azulado base muy suave

            serie["PieStartAngle"] = "270";
            serie["DoughnutRadius"] = "60"; // Ajustado para que el centro no ahogue al label
            serie["PieLabelStyle"] = "Disabled";
            serie.BorderWidth = 0;
            chartClientes.Series.Add(serie);

            if (chartClientes.ChartAreas.Count > 0)
            {
                var chartArea = chartClientes.ChartAreas[0];
                chartArea.BackColor = Color.Transparent;

                // Restablecemos el cálculo automático nativo para eliminar la excepción visual
                chartArea.Position.Auto = true;
                chartArea.InnerPlotPosition.Auto = true;
            }

            // CONFIGURACIÓN DEL TEXTO CENTRAL (Etiqueta flotante)
            if (lbl15 != null)
            {
                lbl15.Parent = chartClientes;
                lbl15.BackColor = Color.White;
                lbl15.Text = "15%\r\nNuevos";
                lbl15.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl15.ForeColor = Color.FromArgb(64, 64, 64);
                lbl15.TextAlign = ContentAlignment.MiddleCenter;

                // Reducimos levemente el tamaño para que encaje perfecto en el centro de la dona sin solapar los bordes
                lbl15.Size = new Size(75, 75);

                // Centrado exacto matemático relativo al Chart control
                lbl15.Location = new Point(
                    (chartClientes.Width - lbl15.Width) / 2,
                    (chartClientes.Height - lbl15.Height) / 2
                );

                lbl15.BringToFront();
                HacerCirculo(lbl15);
            }
            chartClientes.Invalidate();
        }


        // Método para refrescar todos los números y gráficos
        private void ActualizarDatos()
        {
            try
            {
                // 1. REFRESCAR INDICADORES DESDE LA BASE DE DATOS
                decimal gananciasMes = clsConsultas.ObtenerGananciasMesActual();
                if (gananciasMes >= 1000)
                    lblGanancias.Text = "$" + (gananciasMes / 1000).ToString("N1") + "k";
                else
                    lblGanancias.Text = gananciasMes.ToString("C0");

                decimal balanceTotal = clsConsultas.ObtenerBalanceTotal();
                if (Math.Abs(balanceTotal) >= 1000)
                    lblBalance.Text = "$" + (balanceTotal / 1000).ToString("N1") + "k";
                else
                    lblBalance.Text = balanceTotal.ToString("C0");

                lblBalance.ForeColor = (balanceTotal < 0) ? Color.Red : Color.FromArgb(64, 64, 64);

                decimal cantPedidos = clsConsultas.ObtenerTotalVentas();
                if (cantPedidos >= 1000)
                    lblPedidosTotales.Text = (cantPedidos / 1000).ToString("N1") + "k";
                else
                    lblPedidosTotales.Text = cantPedidos.ToString("N0");

                // 2. REFRESCAR GRÁFICOS
                ConfigurarGraficoClientes();
                ConfigurarGraficoBarras();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar los datos en tiempo real: " + ex.Message);
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            // Cada 1 minuto el reloj va a ejecutar esto automáticamente
            ActualizarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
    }

}
