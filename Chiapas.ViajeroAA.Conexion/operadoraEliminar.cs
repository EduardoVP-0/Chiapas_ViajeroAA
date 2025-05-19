using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Conexion
{
    public class operadoraEliminar
    {
        private Conexion _conexion;

        public operadoraEliminar()
        {
            _conexion = new Conexion();
        }

        public bool EliminarOperadora(int idOperadora)
        {
            bool resultado = false;

            using (MySqlConnection conn = _conexion.ObtenerConexion())
            {
                try
                {
                    string query = "DELETE FROM operadora WHERE id = @IdOperadora";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdOperadora", idOperadora);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    // 1451 es el código de error de MySQL para violación de clave foránea
                    if (ex.Number == 1451)
                    {
                        // No lanzar la excepción, solo regresar false
                        return false;
                    }
                    else
                    {
                        // Otros errores sí los lanzamos
                        throw new Exception("Error al eliminar la operadora: " + ex.Message);
                    }
                }
            }

            return resultado;
        }

    }
}
