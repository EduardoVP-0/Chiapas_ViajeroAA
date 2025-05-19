using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Conexion
{
    public class operadoraEliminar2
    {
        private Conexion _conexion;

        public operadoraEliminar2()
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

                    string query = "DELETE FROM operadora2 WHERE id = @IdOperadora";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdOperadora", idOperadora);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la operadora: " + ex.Message);
                }
            }

            return resultado;
        }
    }
}
