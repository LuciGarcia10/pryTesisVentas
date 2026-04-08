using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class clsConsultas
    {
        // Agregamos 'static' para llamarlo sin crear 'new'
        //Pedidos Totales
        // 1. Centralizamos la cadena de conexión para cambiarla una sola vez acá
        // RECUERDA: Pon tu cadena real (la que sacaste del Explorador de Servidores)
        private static string cadena = "Server=TU_SERVIDOR;Database=DigitalFarma;Trusted_Connection=True;";

        // PEDIDOS TOTALES 
        public static decimal ObtenerTotalVentas()
        {
            decimal total = 0;
            // Cambié SUM por COUNT porque son "Pedidos Totales" (unidades)
            string consulta = "SELECT COUNT(*) FROM Pedidos";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                try
                {
                    conexion.Open();
                    var resultado = comando.ExecuteScalar();
                    if (resultado != DBNull.Value && resultado != null)
                        total = Convert.ToDecimal(resultado);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error en Pedidos Totales: " + ex.Message);
                }
            }
            return total;
        }

        // GANANCIAS DEL MES ACTUAL 
        public static decimal ObtenerGananciasMesActual()
        {
            decimal total = 0;
            string consulta = @"SELECT SUM(total_pedido) 
                                FROM Pedidos 
                                WHERE MONTH(fecha) = MONTH(GETDATE()) 
                                AND YEAR(fecha) = YEAR(GETDATE())";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                try
                {
                    conexion.Open();
                    var resultado = comando.ExecuteScalar();
                    if (resultado != DBNull.Value && resultado != null)
                        total = Convert.ToDecimal(resultado);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error en Ganancias: " + ex.Message);
                }
            }
            return total;
        }

        // BALANCE (VENTAS - COMPRAS)
        public static decimal ObtenerBalanceTotal()
        {
            decimal ventas = 0;
            decimal compras = 0;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    // Suma de Ventas
                    SqlCommand cmdVentas = new SqlCommand("SELECT SUM(total_pedido) FROM Pedidos", conexion);
                    var resVentas = cmdVentas.ExecuteScalar();
                    if (resVentas != DBNull.Value && resVentas != null) ventas = Convert.ToDecimal(resVentas);

                    // Suma de Compras
                    SqlCommand cmdCompras = new SqlCommand("SELECT SUM(monto_compra) FROM Compras", conexion);
                    var resCompras = cmdCompras.ExecuteScalar();
                    if (resCompras != DBNull.Value && resCompras != null) compras = Convert.ToDecimal(resCompras);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error en Balance: " + ex.Message);
                }
            }
            return ventas - compras;
        }

        // ESTADÍSTICAS PARA EL GRÁFICO CIRCULAR (CLIENTES)
        // Este método devuelve 3 valores para la dona
        public static (int nuevos, int antiguos) ObtenerEstadisticasClientes()
        {
            int nuevos = 0;
            int totales = 0;

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    // Contamos los clientes que entraron este mes
                    SqlCommand cmdNuevos = new SqlCommand("SELECT COUNT(*) FROM Clientes WHERE MONTH(fecha_registro) = MONTH(GETDATE())", conexion);
                    nuevos = (int)cmdNuevos.ExecuteScalar();

                    // Contamos todos los clientes
                    SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM Clientes", conexion);
                    totales = (int)cmdTotal.ExecuteScalar();
                }
                catch { /* Si falla devolvemos 0 */ }
            }

            int antiguos = totales - nuevos;
            return (nuevos, antiguos);
        }

        // Graficos de frmProductos:
        // CLIENTES NUEVOS (Conteo de registros del mes actual)
        public static int ObtenerClientesNuevosMes()
        {
            int total = 0;
            string consulta = "SELECT COUNT(*) FROM Clientes WHERE MONTH(fecha_registro) = MONTH(GETDATE()) AND YEAR(fecha_registro) = YEAR(GETDATE())";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    total = (int)new SqlCommand(consulta, conexion).ExecuteScalar();
                }
                catch { /* Manejar error */ }
            }
            return total;
        }

        // TOTAL DE CLIENTES (Todos los registros) 
        public static int ObtenerTotalClientes()
        {
            int total = 0;
            string consulta = "SELECT COUNT(*) FROM Clientes";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    total = (int)new SqlCommand(consulta, conexion).ExecuteScalar();
                }
                catch { /* Manejar error */ }
            }
            return total;
        }

        // PEDIDOS PENDIENTES (Pedidos que aún no se entregaron/pagaron)
        public static int ObtenerPedidosPendientes()
        {
            int total = 0;
            // Asumiendo que tienes una columna 'estado' en tu tabla Pedidos
            string consulta = "SELECT COUNT(*) FROM Pedidos WHERE estado = 'Pendiente'";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    conexion.Open();
                    total = (int)new SqlCommand(consulta, conexion).ExecuteScalar();
                }
                catch { /* Manejar error */ }
            }
            return total;
        }

    }
}
