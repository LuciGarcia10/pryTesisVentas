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
    public partial class FrmPerfil : Form
    {
        // Lista local para simular las otras cuentas a gestionar por el Administrador
        private List<clsUsuarioSimulado> listaUsuarios;
        public FrmPerfil()
        {
            InitializeComponent();
            ConfigurarEstilosExclusivos();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            // Cargar datos actuales del Admin en los TextBox
            TxtUsuario.Text = "Valeria.Admin";
            TxtEmail.Text = "valeria.admin@digitalfarma.com";
            TxtContraActual.Text = "123456789";
            TxtContraNueva.Text = "";

            // Configurar contraseñas ocultas inicialmente
            TxtContraActual.PasswordChar = '●';
            TxtContraNueva.PasswordChar = '●';

            // Cargar datos de prueba para la grilla de control de permisos
            CargarGrillaUsuarios();
        }

        private void ConfigurarEstilosExclusivos()
        {
            BtnGuardar.BackColor = Color.FromArgb(0, 105, 92); 
            BtnGuardar.ForeColor = Color.White;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnGuardar.Cursor = Cursors.Hand;

            // Estilizar botón Cambiar Foto
            BtnCambiarFoto.BackColor = Color.White;
            BtnCambiarFoto.ForeColor = Color.FromArgb(0, 105, 92);
            BtnCambiarFoto.FlatStyle = FlatStyle.Flat;
            BtnCambiarFoto.FlatAppearance.BorderColor = Color.FromArgb(0, 105, 92);
            BtnCambiarFoto.FlatAppearance.BorderSize = 1;
            BtnCambiarFoto.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Ajustar propiedades de la grilla de usuarios
            DgvPermisos.BackgroundColor = Color.White;
            DgvPermisos.BorderStyle = BorderStyle.None;
            DgvPermisos.RowHeadersVisible = false;
            DgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPermisos.AllowUserToAddRows = false;
           // DgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarGrillaUsuarios()
        {
            listaUsuarios = new List<clsUsuarioSimulado>
            {
                new clsUsuarioSimulado { Usuario = "Cajero_01", Rol = "Cajero", Estado = "Activo" },
                new clsUsuarioSimulado { Usuario = "Cajero_02", Rol = "Cajero", Estado = "Activo" },
                new clsUsuarioSimulado { Usuario = "Farmaceutico_A", Rol = "Farmacéutico", Estado = "Activo" },
                new clsUsuarioSimulado { Usuario = "Farmaceutico_B", Rol = "Farmacéutico", Estado = "Inactivo" }
            };

            DgvPermisos.DataSource = null;
            DgvPermisos.DataSource = listaUsuarios;

            // Verificar si la columna de acciones ya existe para no duplicarla
            if (!DgvPermisos.Columns.Contains("btnAcciones"))
            {
                DataGridViewImageColumn colAccion = new DataGridViewImageColumn();
                colAccion.Name = "btnAcciones";
                colAccion.HeaderText = "Acciones";
                //colAccion.Image = Properties.Resources.Lupita;
                colAccion.ImageLayout = DataGridViewImageCellLayout.Zoom;
                colAccion.Width = 60;
                DgvPermisos.Columns.Add(colAccion);
            }
        }

        private void BtnVerContra_Click(object sender, EventArgs e)
        {
            if (TxtContraNueva.PasswordChar == '●')
            {
                TxtContraNueva.PasswordChar = '\0'; // Muestra el texto plano
                // Cambiar el ícono
                BtnVerContra.Image = Properties.Resources.hide;
            }
            else
            {
                TxtContraNueva.PasswordChar = '●'; // Oculta el texto
                BtnVerContra.Image = Properties.Resources.show;
            }
        }

        private void BtnCambiarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PctFotoPerfil.Image = Image.FromFile(ofd.FileName);
                    PctFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de interfaz
            if (string.IsNullOrWhiteSpace(TxtUsuario.Text) || string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                MessageBox.Show("El nombre de usuario y el email no pueden estar vacíos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("¡Cambios de perfil guardados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Mostrar el cuadro de diálogo de confirmación estandarizado
            DialogResult res = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                // 2. Cerramos la aplicación
                Application.Exit();
            }
        }

        private void DgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DgvPermisos.Columns[e.ColumnIndex].Name == "btnAcciones")
            {
                var usuarioSeleccionado = DgvPermisos.Rows[e.RowIndex].DataBoundItem as clsUsuarioSimulado;
                if (usuarioSeleccionado != null)
                {
                    // Abrir un cuadro de gestion permisos (Admin, Farmacéutico, Cajero)
                    MessageBox.Show($"Abriendo panel de edición de permisos para: {usuarioSeleccionado.Usuario}\nRol actual: {usuarioSeleccionado.Rol}", "Gestión de Permisos");
                }
            }
        }

        // Clase para ver la grilla de control del Administrador
        public class clsUsuarioSimulado
        {
            public string Usuario { get; set; }
            public string Rol { get; set; }
            public string Estado { get; set; }
        }

        private void TxtBuscarU_Enter(object sender, EventArgs e)
        {
            if (TxtBuscarU.Text == "Buscar usuarios...")
            {
                TxtBuscarU.Text = "";
                TxtBuscarU.ForeColor = Color.Black; // Texto normal
            }
        }

        private void TxtBuscarU_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarU.Text))
            {
                TxtBuscarU.Text = "Buscar usuarios...";
                TxtBuscarU.ForeColor = Color.Gray; // Color gris de guía
            }
        }
        private void TxtBuscarU_TextChanged(object sender, EventArgs e)
        {
            // 1. Si la lista original esta vacia o es nula y salimos para evitar errores
            if (listaUsuarios == null) return;

            // 2. Tomamos el texto que ingreso el usuario
            string textoBusqueda = TxtBuscarU.Text.Trim().ToLower();

            // 3. Si el buscador esta vacio volvemos a mostrar todos los registros originales
            if (string.IsNullOrEmpty(textoBusqueda))
            {
                DgvPermisos.DataSource = null;
                DgvPermisos.DataSource = listaUsuarios;
            }
            else
            {
                // 4. Filtramos la lista buscando coincidencias en Usuario o en Rol
                var listaFiltrada = listaUsuarios.Where(x =>
                    x.Usuario.ToLower().Contains(textoBusqueda) ||
                    x.Rol.ToLower().Contains(textoBusqueda)
                ).ToList();

                // 5. Asignamos la lista filtrada como el origen de datos de la grilla
                DgvPermisos.DataSource = null;
                DgvPermisos.DataSource = listaFiltrada;
            }

            // 6. Volvemos a renombrar las columnas
            if (DgvPermisos.Columns["Usuario"] != null) DgvPermisos.Columns["Usuario"].HeaderText = "Usuario";
            if (DgvPermisos.Columns["Rol"] != null) DgvPermisos.Columns["Rol"].HeaderText = "Rol";
            if (DgvPermisos.Columns["Estado"] != null) DgvPermisos.Columns["Estado"].HeaderText = "Estado";
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

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm = new frmEstadisticas();
            frm.ShowDialog();
        }
    }
}
