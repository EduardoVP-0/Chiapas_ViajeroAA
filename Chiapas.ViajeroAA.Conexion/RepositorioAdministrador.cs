using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Chiapas.ViajeroAA.Conexion
{
    public class RepositorioAdministrador
    {
        private Conexion _conexion;

        public RepositorioAdministrador()
        {
            _conexion = new Conexion(); // ← Sin "Conexion" al inicio
        }

        public (string Nombre, string NombreArchivoFoto) ObtenerDatosUsuario(string email, string contraseña)
        {
            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT usuario, foto FROM administrador WHERE email = @Email AND contraseña = @Password";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", contraseña);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader["usuario"].ToString(),
                                    reader["foto"].ToString());
                        }
                    }
                }
            }
            return (null, null);
        }
    }
    }
