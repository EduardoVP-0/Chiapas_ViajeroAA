using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Chiapas.ViajeroAA.Conexion
{
    public class EstadisticasDatos
    {
        private readonly Conexion conexion;

        public EstadisticasDatos(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public int ObtenerTotalOperadoras()
        {
            using (var con = conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM operadora";
                MySqlCommand cmd = new MySqlCommand(query, con);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int ObtenerTotalAdministradores()
        {
            using (var con = conexion.ObtenerConexion())
            {
               
                string query = "SELECT COUNT(*) FROM administrador";
                MySqlCommand cmd = new MySqlCommand(query, con);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public (string Nombre, int Total) ObtenerOperadoraConMasReservaciones()
        {
            using (var con = conexion.ObtenerConexion())
            {
                
                string query = @"
                    SELECT o.nombre_operadora, COUNT(r.Id) AS Total
                    FROM reservaciones r
                    JOIN operadora o ON o.id = r.IdOperadora
                    GROUP BY r.IdOperadora
                    ORDER BY Total DESC
                    LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombre = reader.GetString("nombre_operadora");
                        int total = reader.GetInt32("Total");
                        return (nombre, total);
                    }
                }
            }
            return ("Sin datos", 0);
        }

        public DataTable ObtenerTopOperadoras()
        {
            using (var con = conexion.ObtenerConexion())
            {
                
                string query = @"
                    SELECT o.nombre_operadora AS operadora, COUNT(r.Id) AS reservaciones
                    FROM reservaciones r
                    JOIN operadora o ON o.id = r.IdOperadora
                    GROUP BY o.nombre_operadora
                    ORDER BY reservaciones DESC";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
    }
}
