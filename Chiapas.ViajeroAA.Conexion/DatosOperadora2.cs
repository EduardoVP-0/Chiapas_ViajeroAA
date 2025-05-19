using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Chiapas.ViajeroAA.Conexion
{
    public class DatosOperadora2
    {
        // Método que inserta los datos de usuario en la base de datos
        public void InsertarOperadora(string nombreoperadora, string sitioweb, string descripcion, string direccion,
        string ladaa, string telefono, string representante, string correo, string identificacion, string fotoPath)
        {
            Conexion _conexion =
                new Conexion();

            // Aquí usas la conexión ya existente, asumo que tienes algo similar a lo siguiente:
            using (MySqlConnection connection = _conexion.ObtenerConexion())
            {

                string query = "INSERT INTO operadora2 (nombre_operadora, sitio_web, descripcion, direccion, lada, telefono, representante, email, identificacion, logo) " +
                    "VALUES (@nombre_operadora, @sitio_web, @descripcion, @direccion, @lada, @telefono, @representante, @email, @identificacion, @logo)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre_operadora", nombreoperadora);
                    cmd.Parameters.AddWithValue("@sitio_web", sitioweb);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@direccion", direccion);// Asegúrate de encriptar la contraseña antes
                    cmd.Parameters.AddWithValue("@lada", ladaa); // El nombre del archivo de la foto
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@representante", representante);
                    cmd.Parameters.AddWithValue("@email", correo);
                    cmd.Parameters.AddWithValue("@identificacion", identificacion);
                    cmd.Parameters.AddWithValue("@logo", fotoPath);


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
