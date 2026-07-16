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
            // 1. Cargamos tu lista de la clase PreguntaFrecuente
            List<PreguntaFrecuente> listaFaqs = new List<PreguntaFrecuente>()
            {
                new PreguntaFrecuente { Id = 1, Pregunta = "¿Como hago un nuevo Pedido?", Respuesta = "Debe ir a la pantalla Pedidos, hacer click sobre el boton verde llamado Nuevo Pedido, poner el mobre del produsto que necesita, la cantidad y el proveedore, fianlmente debe hacer click en el boton agregar al carrito." },
                new PreguntaFrecuente { Id = 2, Pregunta = "¿Donde puedo ver las ganacias mensuales?", Respuesta = "Puede verlas en la pantalla de Inicio en los graficos ubicados en el centro." },
                new PreguntaFrecuente { Id = 3, Pregunta = "¿Cómo registrar un nuevo cliente en cuentas corrientes?", Respuesta = "Debe ir a la pantalla Clientes, ahi debe hacer clisk en el boton verde llamado Nuevo Cliente, debe ingresar el nombre del cliente, la obra social del cliente, su numero de afiliacion de la obra social, el estado de cuenta ." }
            };

            // 2. Limpiamos el panel por las dudas
            pnlPreguntas.Controls.Clear();

            // 3. Creamos un "renglón" para cada pregunta
            foreach (var faq in listaFaqs)
            {
                // Usamos un botón para que el usuario pueda hacer clic
                Button btnPregunta = new Button();
                btnPregunta.Text = "  +  " + faq.Pregunta;
                btnPregunta.Width = pnlPreguntas.Width - 25; // Para que no toque el borde
                btnPregunta.Height = 40;
                btnPregunta.TextAlign = ContentAlignment.MiddleLeft;
                btnPregunta.FlatStyle = FlatStyle.Flat;
                btnPregunta.FlatAppearance.BorderSize = 0; // Sin bordes feos
                btnPregunta.Cursor = Cursors.Hand;

                // El color verde para el texto
                btnPregunta.ForeColor = Color.FromArgb(0, 168, 132);
                btnPregunta.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cuando el usuario hace clic, muestra la respuesta
                btnPregunta.Click += (s, ev) => {
                    MessageBox.Show(faq.Respuesta, "DigitalFarma - Ayuda");
                };

                // Agregamos el botón al panel
                pnlPreguntas.Controls.Add(btnPregunta);
            }
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
        private void CargarIndicadores()
        {
            // Asegúrate de usar tu cadena de conexión real
            string cadenaConexion = "Server=TU_SERVIDOR; Database=DigitalFarma; Integrated Security=True";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // 1. Contar Tickets Pendientes
                    string queryTickets = "SELECT COUNT(*) FROM Tickets WHERE Estado = 'Pendiente'";
                    SqlCommand cmdTickets = new SqlCommand(queryTickets, conexion);
                    int cantTickets = (int)cmdTickets.ExecuteScalar();
                    lblCantTickets.Text = cantTickets.ToString() + " Pendientes";

                    // 2. Contar Mensajes (ajusta según tu tabla de mensajes)
                    string queryMensajes = "SELECT COUNT(*) FROM Mensajes WHERE Leido = 0";
                    SqlCommand cmdMensajes = new SqlCommand(queryMensajes, conexion);
                    int cantMensajes = (int)cmdMensajes.ExecuteScalar();
                    lblCantMensajes.Text = cantMensajes.ToString() + " Nuevos";

                    // 3. Sucursal Córdoba (si quieres que sea un enlace)
                    lblMaps.Text = "Sucursal Cordoba";
                }
            }
            catch (Exception ex)
            {
                // Es buena práctica avisar si algo falló con la base de datos
                Console.WriteLine("Error al cargar indicadores: " + ex.Message);
            }
        }

        private void lnkMaps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Esta línea abre el navegador predeterminado del usuario con la URL de Google Maps
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.google.com/maps/search/FarmaciaFunesGarcia",
                    UseShellExecute = true // Esto le dice al sistema operativo que abra el navegador
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el mapa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
