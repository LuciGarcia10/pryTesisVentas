using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmDetallePedido : Form
    {
        public List<clsPedido> ListaCompleta { get; set; }
        public clsPedido PedidoSeleccionado { get; set; }
        public frmDetallePedido()
        {
            InitializeComponent();
        }

        private void frmDetallePedido_Load(object sender, EventArgs e)
        {
            // 1. Aplicamos el estilo apenas carga (Copiá el método Estilizar abajo)
            EstilizarGrillaDetalle();

            if (PedidoSeleccionado != null)
            {
                txtNumeroPedido.Text = PedidoSeleccionado.IdPedido.ToString();

                // 2. CLAVE: No generar columnas automáticas
                dgvDetalles.AutoGenerateColumns = false;

                // 3. Cargamos los datos
                dgvDetalles.DataSource = PedidoSeleccionado.Detalles;

                // Calculamos el total
                decimal total = PedidoSeleccionado.Detalles.Sum(x => x.Precio * x.Cantidad);

                // ASIGNACIÓN: Asegurate que el nombre coincida con tu Label
                txtPrecioTotal.Text = total.ToString("C0"); // El "C" le pone el signo $ automáticamente
            }
        }

        // Agregá este método abajo para que se vea pro
        private void EstilizarGrillaDetalle()
        {
            // 1. Fondo blanco y sin bordes feos
            dgvDetalles.BackgroundColor = Color.White;
            dgvDetalles.BorderStyle = BorderStyle.None;

            // 2. Quitamos la columna gris de la izquierda (la del asterisco)
            dgvDetalles.RowHeadersVisible = false;

            // 3. Quitamos la fila vacía del final
            dgvDetalles.AllowUserToAddRows = false;

            // 4. Hacemos que las columnas ocupen todo el ancho
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 5. Estilo de celdas
            dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 250, 245); // Verde claro
            dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDetalles.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // 6. Alineación de los títulos
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvDetalles.EnableHeadersVisualStyles = false;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            // Cerramos el formulario de detalle y volvemos a la pantalla de pedidos
            this.Close();
        }

        private void lblCerrar_MouseEnter(object sender, EventArgs e)
        {
            lblCerrar.ForeColor = Color.Red;
        }

        private void lblCerrar_MouseLeave(object sender, EventArgs e)
        {
            lblCerrar.ForeColor = Color.DimGray; // Vuelve al color original
        }

        private void lblPrecioTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
