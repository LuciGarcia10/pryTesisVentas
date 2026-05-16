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
    public partial class frmNuevoPedido : Form
    {
        List<clsDetallePedido> carrito = new List<clsDetallePedido>();
        public frmNuevoPedido()
        {
            InitializeComponent();
        }

        private void frmNuevoPedido_Load(object sender, EventArgs e)
        {

        }

        private void lblHacerPedido1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {
            // Si el cuadro de texto NO está vacío, ocultamos el label de ayuda
            if (txtNombreProducto.Text.Trim().Length > 0)
            {
                lblNombreProducto.Visible = false;
            }
            else
            {
                // Si borra todo, volvemos a mostrar el label "Elegir el nombre..."
                lblNombreProducto.Visible = true;
            }
        }

        private void lblNombreProducto_Click(object sender, EventArgs e)
        {
            // Al tocar el texto de ayuda, mandamos el foco al TextBox para poder escribir
            txtNombreProducto.Focus();
        }

        private void txtNombreProducto_Enter(object sender, EventArgs e)
        {
            // Apenas el usuario hace clic o llega con el TAB, ocultamos el label
            lblNombreProducto.Visible = false;
        }

        private void txtNombreProducto_Leave(object sender, EventArgs e)
        {
            // Si sale del cuadro y NO escribió nada, mostramos el label de nuevo
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                lblNombreProducto.Visible = true;
            }
        }

        private void btnAgregaralCarrito_Click(object sender, EventArgs e)
        {
            // Validamos que no esté vacío (usamos el texto del label como referencia)
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.");
                return;
            }

            // Creamos un nuevo item de pedido
            clsDetallePedido nuevoItem = new clsDetallePedido();
            nuevoItem.Producto = txtNombreProducto.Text;
            nuevoItem.Cantidad = (int)numCantidad.Value; // Asumiendo que usás un NumericUpDown
            nuevoItem.Proveedor = cmbProveedores.Text;

            // Lo sumamos a la lista
            carrito.Add(nuevoItem);

            // Limpiamos para el siguiente
            txtNombreProducto.Clear();
            lblNombreProducto.Visible = true;
            MessageBox.Show("Producto agregado al carrito temporal.");
        }

        private void btnVerCarrito_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ahora que frmCarrito existe, esto va a compilar de diez:
            frmCarrito ventanaCarrito = new frmCarrito(carrito);
            ventanaCarrito.ShowDialog();
        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si el carrito tiene productos, avisamos antes de cerrar
            if (carrito.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Tenés productos en el carrito. ¿Estás seguro de que querés cancelar el pedido? Se borrará todo.",
                    "DigitalFarma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    this.Close(); // Cerramos la ventana
                }
            }
            else
            {
                // Si no hay nada, cerramos directamente
                this.Close();
            }
        }
    }
}
