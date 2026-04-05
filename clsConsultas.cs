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
        public static decimal ObtenerTotalVentas()
        {
            decimal total = 0;
            string cadenaConexion = "tu_cadena_aqui";
            string consulta = "SELECT SUM(total_pedido) FROM Pedidos";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
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
                    System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
                }
            }
            return total;
        }

        //Ganancias
        public static decimal ObtenerGananciasMesActual()
        {
            decimal total = 0;
            // RECUERDA: Cambia esto por tu cadena de conexión real
            string cadenaConexion = "tu_cadena_de_conexion_aqui";

            // SQL que suma el total de pedidos filtrando por el mes y año actual
            string consulta = @"SELECT SUM(total_pedido) 
                        FROM Pedidos 
                        WHERE MONTH(fecha) = MONTH(GETDATE()) 
                        AND YEAR(fecha) = YEAR(GETDATE())";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                try
                {
                    conexion.Open();
                    var resultado = comando.ExecuteScalar();
                    if (resultado != DBNull.Value && resultado != null)
                    {
                        total = Convert.ToDecimal(resultado);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error en Ganancias: " + ex.Message);
                }
            }
            return total;
        }

        //Balance
        public static decimal ObtenerBalanceTotal()
        {
            decimal ventas = 0;
            decimal compras = 0;
            string cadenaConexion = "tu_cadena_aqui";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    // 1. Sumamos las ventas
                    SqlCommand cmdVentas = new SqlCommand("SELECT SUM(total_pedido) FROM Pedidos", conexion);
                    var resVentas = cmdVentas.ExecuteScalar();
                    if (resVentas != DBNull.Value) ventas = Convert.ToDecimal(resVentas);

                    // 2. Sumamos las compras (Asumiendo que tenés una tabla 'Compras')
                    SqlCommand cmdCompras = new SqlCommand("SELECT SUM(monto_compra) FROM Compras", conexion);
                    var resCompras = cmdCompras.ExecuteScalar();
                    if (resCompras != DBNull.Value) compras = Convert.ToDecimal(resCompras);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error en Balance: " + ex.Message);
                }
            }
            return ventas - compras; // El balance es la ganancia real neta
        }
    }
}
