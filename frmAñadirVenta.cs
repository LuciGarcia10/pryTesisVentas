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
    public partial class frmAñadirVenta : Form
    {
        private List<ItemCarrito> listaCarrito = new List<ItemCarrito>();
        public frmAñadirVenta()
        {
            InitializeComponent();
            ConfigurarTabla();
        }
        private void ConfigurarTabla()
        {
            // Configuramos el DataGridView para que use nuestra lista
            dgvCarrito.DataSource = null;
            dgvCarrito.AutoGenerateColumns = false;

            // (Cantidad, Producto, Precio Total)
        }
        private void frmAñadirVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnAñadiraCarrito_Click(object sender, EventArgs e)
        {
            // 1. Validar cantidad
            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("Por favor, seleccione una cantidad mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el producto (Simulado o desde tu buscador)
            string nombreProducto = txtBuscar.Text;
            decimal precioSimulado = 15.50m; // Aquí conectarías con tu base de datos para traer el precio real

            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Por favor, busque y seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Verificar si el producto ya existe en el carrito para sumar la cantidad
            var itemExistente = listaCarrito.FirstOrDefault(p => p.Producto == nombreProducto);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                // Agregar nuevo ítem
                listaCarrito.Add(new ItemCarrito
                {
                    Producto = nombreProducto,
                    Cantidad = cantidad,
                    PrecioUnitario = precioSimulado
                });
            }

            // 4. Actualizar la interfaz
            ActualizarInterfaz();
        }
        private void ActualizarInterfaz()
        {
            // Refrescar el DataGridView
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = listaCarrito;

            // Calcular el precio total acumulado 
            decimal precioTotalGeneral = listaCarrito.Sum(item => item.PrecioTotal);

            // Mostrar el total en el TextBox correspondiente (formateado a dinero)
            txtPrecioTotal.Text = precioTotalGeneral.ToString("C2");

            // Resetear el control de cantidad a 0 o 1 para la siguiente entrada
            numCantidad.Value = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cancelar la venta actual?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Cierra la ventana actual
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (listaCarrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Aquí ejecutas tu lógica de base de datos para guardar la venta (INSERT INTO Ventas...)
            MessageBox.Show("Venta procesada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar todo para una nueva venta
            listaCarrito.Clear();
            ActualizarInterfaz();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                // Obtener el objeto seleccionado en la fila
                ItemCarrito itemSeleccionado = (ItemCarrito)dgvCarrito.CurrentRow.DataBoundItem;

                // Remover de la lista
                listaCarrito.Remove(itemSeleccionado);

                // Actualizar la interfaz
                ActualizarInterfaz();
            }
            else
            {
                MessageBox.Show("Seleccione un producto del carrito para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
