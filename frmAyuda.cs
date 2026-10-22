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
    public partial class frmAyuda : Form
    {
        // cadena de conexión 
        //string cadenaConexion = "Server=TU_SERVIDOR; Database=DigitalFarma; Integrated Security=True";
        public frmAyuda()
        {
            InitializeComponent();
            // Optimización de renderizado para evitar parpadeos
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
        // Método para cargar la grilla de tickets desde una base de datos SQL
        // public void CargarGrillaTickets()
        // {
        //     try 
        //     {
        //         using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        //         {
        //             string query = "SELECT IDTicket, Fecha, TituloProblema, Estado FROM Tickets";
        //             SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
        //             DataTable dt = new DataTable();
        //             adaptador.Fill(dt); 
        //             dgvTickets.DataSource = dt; 
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
        //     }
        // }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblGanancias_Click(object sender, EventArgs e)
        {

        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            CargarPreguntasFrecuentes();
            CargarIndicadores();
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

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmPerfil frm = new FrmPerfil();
            frm.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm = new frmEstadisticas();
            frm.ShowDialog();
        }
        private void CargarPreguntasFrecuentes()
        {
            List<PreguntaFrecuente> listaFaqs = new List<PreguntaFrecuente>()
            {
                new PreguntaFrecuente
                {
                    Id = 1,
                    Pregunta = "¿Cómo hago un nuevo Pedido?",
                    Respuesta = "Debe ir a la pantalla Pedidos, hacer clic sobre el botón verde 'Nuevo Pedido', ingresar el producto, cantidad y proveedor, y presionar 'Agregar al carrito'."
                },
                new PreguntaFrecuente
                {
                    Id = 2,
                    Pregunta = "¿Dónde puedo ver las ganancias mensuales?",
                    Respuesta = "Puede verlas en la pantalla de Inicio en los gráficos ubicados en el centro."
                },
                new PreguntaFrecuente
                {
                    Id = 3,
                    Pregunta = "¿Cómo registrar un nuevo cliente en cuentas corrientes?",
                    Respuesta = "Debe ir a la pantalla Clientes, hacer clic en 'Nuevo Cliente' y completar los datos del formulario (nombre, obra social, número de afiliado y estado)."
                }
            };

            // Pausar el dibujado del panel mientras se insertan controles
            pnlPreguntas.SuspendLayout();
            pnlPreguntas.Controls.Clear();

            foreach (var faq in listaFaqs)
            {
                Button btnPregunta = new Button
                {
                    Text = "  +  " + faq.Pregunta,
                    Width = pnlPreguntas.ClientSize.Width - 25,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    ForeColor = Color.FromArgb(0, 168, 132),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                btnPregunta.FlatAppearance.BorderSize = 0;

                btnPregunta.Click += (s, ev) =>
                {
                    MessageBox.Show(faq.Respuesta, "DigitalFarma - Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                pnlPreguntas.Controls.Add(btnPregunta);
            }

            // Reanudar el dibujado de una sola vez
            pnlPreguntas.ResumeLayout();
        }
        private void CargarIndicadores()
        {
            // Usar la cadena de conexión real de tu aplicación
            string cadenaConexion = clsConsultas.cadena;

            if (string.IsNullOrWhiteSpace(cadenaConexion))
            {
                lblCantTickets.Text = "0 Pendientes";
                lblCantMensajes.Text = "0 Nuevos";
                lblMaps.Text = "Sucursal Córdoba";
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // 1. Contar Tickets Pendientes
                    string queryTickets = "SELECT COUNT(*) FROM Tickets WHERE Estado = 'Pendiente'";
                    using (SqlCommand cmdTickets = new SqlCommand(queryTickets, conexion))
                    {
                        object res = cmdTickets.ExecuteScalar();
                        int cantTickets = res != null ? Convert.ToInt32(res) : 0;
                        lblCantTickets.Text = cantTickets.ToString() + " Pendientes";
                    }

                    // 2. Contar Mensajes
                    string queryMensajes = "SELECT COUNT(*) FROM Mensajes WHERE Leido = 0";
                    using (SqlCommand cmdMensajes = new SqlCommand(queryMensajes, conexion))
                    {
                        object res = cmdMensajes.ExecuteScalar();
                        int cantMensajes = res != null ? Convert.ToInt32(res) : 0;
                        lblCantMensajes.Text = cantMensajes.ToString() + " Nuevos";
                    }

                    // 3. Sucursal
                    lblMaps.Text = "Sucursal Córdoba";
                }
            }
            catch (Exception ex)
            {
                // Si la tabla Tickets o Mensajes aún no existe en SQL, no bloquea la pantalla
                lblCantTickets.Text = "0 Pendientes";
                lblCantMensajes.Text = "0 Nuevos";
                lblMaps.Text = "Sucursal Córdoba";
                Console.WriteLine("Aviso en indicadores: " + ex.Message);
            }
        }

        private void lnkMaps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.google.com/maps/search/FarmaciaFunesGarcia",
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el mapa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
