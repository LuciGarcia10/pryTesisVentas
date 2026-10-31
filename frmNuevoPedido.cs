using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTesisVentas
{
    public partial class frmNuevoPedido : Form
    {
        List<clsDetallePedido> compra = new List<clsDetallePedido>();
        DataTable dtProductos = new DataTable();
        public frmNuevoPedido()
        {
            InitializeComponent();
            CargarProductosDesdeBase();
        }
        // Estructura para vincular cada selector de producto con su respectiva cantidad
        private class FilaProductoControl
        {
            public ComboBox CmbProd { get; set; }
            public NumericUpDown NumCant { get; set; }
        }

        private List<FilaProductoControl> filasDinamicas = new List<FilaProductoControl>();
        private void frmNuevoPedido_Load(object sender, EventArgs e)
        {
            // Registramos la primera fila que ya existe en el diseño
            filasDinamicas.Add(new FilaProductoControl
            {
                CmbProd = cmbProductos,
                NumCant = numCantidad
            });
        }
        
        private void CargarProductosDesdeBase()
        {
            string cadenaConexion = clsConsultas.cadena;
            // Traemos también PrecioVenta para calcular los importes reales
            string query = "SELECT IdProducto, Nombre, PrecioVenta FROM Productos ORDER BY Nombre ASC";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    dtProductos.Clear();
                    adaptador.Fill(dtProductos);

                    cmbProductos.DisplayMember = "Nombre";
                    cmbProductos.ValueMember = "IdProducto";
                    cmbProductos.DataSource = dtProductos;

                    cmbProductos.SelectedIndex = -1;
                    cmbProductos.Text = "Escribir o elegir producto...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los productos de la base: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (compra.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Tenés productos en el carrito. ¿Estás seguro de que querés cancelar el pedido? Se borrará todo.",
                    "DigitalFarma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnAgregararCompras_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbProveedores.Text) || cmbProveedores.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccioná un proveedor.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la cantidad ingresada sea válida
            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("Ingresá una cantidad mayor a 0.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string proveedor = cmbProveedores.Text.Trim();
            int cantidad = (int)numCantidad.Value;
            int agregadosEnEstePaso = 0;
            // Recorrer la lista de filas dinámicas (el combo original + los generados con el '+')
            foreach (var fila in filasDinamicas)
            {
                if (fila.CmbProd.SelectedIndex != -1 && fila.CmbProd.SelectedValue != null)
                {
                    int idProd = Convert.ToInt32(fila.CmbProd.SelectedValue);
                    string nombreProd = fila.CmbProd.Text;
                    // Extraer el precio real del producto vinculado
                    decimal precio = 0;
                    DataRowView rowView = fila.CmbProd.SelectedItem as DataRowView;
                    if (rowView != null && rowView["PrecioVenta"] != DBNull.Value)
                    {
                        precio = Convert.ToDecimal(rowView["PrecioVenta"]);
                    }
                    // Comprobar si ya existe en la lista para sumar cantidad o crearlo nuevo
                    var existente = compra.FirstOrDefault(x => x.IdProducto == idProd);
                    if (existente != null)
                    {
                        existente.Cantidad += cantidad;
                    }
                    else
                    {
                        compra.Add(new clsDetallePedido
                        {
                            IdProducto = idProd,
                            Producto = nombreProd,
                            Cantidad = cantidad,
                            Precio = precio,
                            Proveedor = proveedor
                        });
                    }

                    agregadosEnEstePaso++;
                }
            }
            // Si ningún combo tenía un producto elegido, avisar
            if (agregadosEnEstePaso == 0)
            {
                MessageBox.Show("Por favor, seleccioná al menos un producto de la lista.", "DigitalFarma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Bloquear proveedor para mantener la orden bajo el mismo proveedor
            cmbProveedores.Enabled = false;
            // Notificación y reset de campos
            int totalUnidades = compra.Sum(x => x.Cantidad);
            MessageBox.Show($"¡Se cargaron {agregadosEnEstePaso} producto(s) a la compra!\nLlevás {compra.Count} producto(s) en total ({totalUnidades} unidades). Ya podés verlos en 'Ver compras'.",
                            "Productos Agregados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Limpiar selectores
            foreach (var fila in filasDinamicas)
            {
                fila.CmbProd.SelectedIndex = -1;
                fila.CmbProd.Text = "Elegir Producto...";
            }
            numCantidad.Value = 1;
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnVerCompras_Click(object sender, EventArgs e)
        {
            if (compra.Count == 0)
            {
                MessageBox.Show("Todavía no se ha agregado ningún producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Hide(); // Oculta "Hacer Pedido" para que no quede detrás

            frmCompras ventanaCompras = new frmCompras(compra);
            ventanaCompras.StartPosition = FormStartPosition.CenterParent;
            ventanaCompras.ShowDialog();

            // Si el pedido se confirmó, se cierra definitivamente
            if (compra.Count == 0)
            {
                this.Close();
            }
            else
            {
                this.Show(); // Si volvió sin pedir, reaparece "Hacer Pedido"
            }
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctMas_Click(object sender, EventArgs e)
        {
            int separacion = 35; // Distancia en píxeles que baja cada sección
            // Desplazar hacia abajo los controles inferiores (el PictureBox NO se mueve)
            lblCantidad.Top += separacion;
            numCantidad.Top += separacion;
            lblProveedores.Top += separacion;
            cmbProveedores.Top += separacion;
            btnVerCompras.Top += separacion;
            btnAgregararCompras.Top += separacion;
            this.Height += separacion; // Agranda la ventana para que los botones no queden tapados
            // Determinar la posición Y debajo del último ComboBox creado
            FilaProductoControl ultimaFila = filasDinamicas.Last();
            int nuevoTop = ultimaFila.CmbProd.Top + separacion;
            // Crear el nuevo ComboBox alineado con el primero
            ComboBox nuevoCmb = new ComboBox();
            nuevoCmb.Left = cmbProductos.Left;
            nuevoCmb.Top = nuevoTop;
            nuevoCmb.Width = cmbProductos.Width;
            nuevoCmb.Font = cmbProductos.Font;
            nuevoCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            // Asignar los datos independientes traídos de SQL
            nuevoCmb.DisplayMember = "Nombre";
            nuevoCmb.ValueMember = "IdProducto";
            nuevoCmb.DataSource = dtProductos.Copy();
            nuevoCmb.SelectedIndex = -1;
            // Agregar el nuevo ComboBox al formulario
            this.Controls.Add(nuevoCmb);
            nuevoCmb.BringToFront();
            // Registrar el nuevo control en la lista dinámica
            filasDinamicas.Add(new FilaProductoControl
            {
                CmbProd = nuevoCmb,
                NumCant = numCantidad
            });
        }

    }
}
