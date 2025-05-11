using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Chiapas.ViajeroAA.Conexion
{
    public class Administrador
    {
        // Método que inserta los datos de usuario en la base de datos
        public void InsertarUsuario(string usuario, string email, string contraseña, string foto)
        {
            Conexion _conexion =
                new Conexion();

            // Aquí usas la conexión ya existente, asumo que tienes algo similar a lo siguiente:
            using (MySqlConnection connection = _conexion.ObtenerConexion())
            {
                
                string query = "INSERT INTO administrador (usuario, email, contraseña, foto) VALUES (@usuario, @email, @contraseña, @foto)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña); // Asegúrate de encriptar la contraseña antes
                    cmd.Parameters.AddWithValue("@foto", foto); // El nombre del archivo de la foto

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
