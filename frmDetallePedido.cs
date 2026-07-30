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

                // asignacion
                txtPrecioTotal.Text = total.ToString("C0"); // El "C" le pone el signo $ automáticamente
            }
        }

        private void EstilizarGrillaDetalle()
        {
            // 1. Fondo blanco y sin bordes
            dgvDetalles.BackgroundColor = Color.White;
            dgvDetalles.BorderStyle = BorderStyle.None;

            // 2. Quitamos la columna gris de la izquierda
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroPedido.Text))
            {
                MessageBox.Show("Ingrese un número de pedido válido.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtNumeroPedido.Text.Trim(), out int idBuscado))
            {
                // Buscamos dentro de la lista completa que recibió el formulario
                if (ListaCompleta != null)
                {
                    clsPedido pedidoEncontrado = ListaCompleta.FirstOrDefault(p => p.IdPedido == idBuscado);

                    if (pedidoEncontrado != null)
                    {
                        // Actualizamos la vista con el nuevo pedido hallado
                        this.PedidoSeleccionado = pedidoEncontrado;
                        dgvDetalles.DataSource = null;
                        dgvDetalles.DataSource = PedidoSeleccionado.Detalles;

                        decimal total = PedidoSeleccionado.Detalles.Sum(x => x.Precio * x.Cantidad);
                        txtPrecioTotal.Text = total.ToString("C0");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún pedido con el Nº " + idBuscado, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("El número de pedido debe ser numérico.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
