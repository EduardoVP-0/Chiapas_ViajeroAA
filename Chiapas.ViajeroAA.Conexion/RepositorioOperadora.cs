using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Conexion
{
    public class RepositorioOperadora
    {
        private Conexion _conexion;
        public RepositorioOperadora()
        {
            _conexion = new Conexion();
        }

        //CODIGO DEL DATAGRID
        public List<VistaOperadora> ObtenerOperadoras()
        {
            var lista = new List<VistaOperadora>();

            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT id, logo, nombre_operadora, sitio_web, descripcion, direccion, representante, lada, telefono, representante, email, identificacion FROM operadora";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new VistaOperadora
                        {
                            id = reader.GetInt32("id"),  // <-- Aquí se obtiene el ID
                            IdOperadora = reader.GetInt32("id"),
                            Logo = reader.GetString("logo"),
                            NombreOperadora = reader.GetString("nombre_operadora"),
                            SitioWeb = reader.GetString("sitio_web"),
                            Descripcion = reader.GetString("descripcion"),
                            Lada = reader.GetString("lada"),
                            Telefono = reader.GetString("telefono"),
                            Direccion = reader.GetString("direccion"),
                            Representante = reader.GetString("representante"),
                            Identificacion = reader.GetString("identificacion"),
                            Email = reader.GetString("email")
                        });
                    }
                }
            }

            return lista;
        }

        // Método nuevo para obtener una operadora por su ID
        public VistaOperadora ObtenerOperadoraPorId(int idOperadora)
        {
            VistaOperadora operadora = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT id, logo ,nombre_operadora, sitio_web, descripcion, direccion, lada, telefono, representante, email, identificacion FROM operadora WHERE id = @idOperadora";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOperadora", idOperadora);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            operadora = new VistaOperadora
                            {
                                id = reader.GetInt32("id"),
                                Logo = reader.GetString("logo"),
                                NombreOperadora = reader.GetString("nombre_operadora"),
                                SitioWeb = reader.GetString("sitio_web"),
                                Descripcion = reader.GetString("descripcion"),
                                Direccion = reader.GetString("direccion"),
                                Lada = reader.GetString("lada"),
                                Telefono = reader.GetString("telefono"),
                                Representante = reader.GetString("representante"),
                                Email = reader.GetString("email"),
                                Identificacion = reader.GetString("identificacion")
                            };
                        }
                    }
                }
            }

            return operadora;
        }


        //CONSULTA PARA HACER EL UPDATE DE LOS REGISTROS
        public bool ActualizarOperadora(int id, string logo, string nombre, string sitio, string descripcion,
                                string direccion, string lada, string telefono, string representante,
                                string correo, string identificacion)
        {
            Conexion conexion = new Conexion();

            using (var conn = conexion.ObtenerConexion())
            {
                try
                {
                    // Validaciones de longitud
                    logo = string.IsNullOrWhiteSpace(logo) ? "" : logo.Trim().Substring(0, Math.Min(logo.Length, 255));
                    nombre = string.IsNullOrWhiteSpace(nombre) ? "" : nombre.Trim().Substring(0, Math.Min(nombre.Length, 50));
                    sitio = string.IsNullOrWhiteSpace(sitio) ? "" : sitio.Trim().Substring(0, Math.Min(sitio.Length, 150));
                    descripcion = string.IsNullOrWhiteSpace(descripcion) ? "" : descripcion.Trim(); // TEXT no tiene límite
                    direccion = string.IsNullOrWhiteSpace(direccion) ? "" : direccion.Trim().Substring(0, Math.Min(direccion.Length, 255));
                    lada = string.IsNullOrWhiteSpace(lada) ? "" : lada.Trim().Substring(0, Math.Min(lada.Length, 5));
                    telefono = string.IsNullOrWhiteSpace(telefono) ? "" : telefono.Trim().Substring(0, Math.Min(telefono.Length, 10));
                    representante = string.IsNullOrWhiteSpace(representante) ? "" : representante.Trim().Substring(0, Math.Min(representante.Length, 50));
                    correo = string.IsNullOrWhiteSpace(correo) ? "" : correo.Trim().Substring(0, Math.Min(correo.Length, 50));
                    identificacion = string.IsNullOrWhiteSpace(identificacion) ? "" : identificacion.Trim().Substring(0, Math.Min(identificacion.Length, 5));

                    // IMPORTANTE: corregir el nombre del campo de ID si es diferente
                    string query = @"UPDATE operadora SET 
                                logo = @logo,
                                nombre_operadora = @nombre,
                                sitio_web = @sitio,
                                descripcion = @descripcion,
                                direccion = @direccion,
                                lada = @lada,
                                telefono = @telefono,
                                representante = @representante,
                                email = @correo,
                                identificacion = @identificacion
                             WHERE id = @id";  // <-- Asegúrate de que el campo se llame "id" y no "id_operadora"

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@logo", logo);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@sitio", sitio);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                        cmd.Parameters.AddWithValue("@lada", lada);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@representante", representante);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@identificacion", identificacion);
                        cmd.Parameters.AddWithValue("@id", id);

                        int resultado = cmd.ExecuteNonQuery();
                        if (resultado == 0)
                        {
                            Console.WriteLine("No se actualizó ninguna fila. Verifica que el ID exista.");
                        }

                        return resultado > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar: " + ex.Message);
                    return false;
                }
            }
        }

        // Método nuevo para obtener las últimas 4 operadoras con su logo
        public List<string> ObtenerUltimos4Logos()
        {
            var logos = new List<string>();

            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT logo FROM operadora ORDER BY id DESC LIMIT 4";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string logo = reader.IsDBNull(0) ? null : reader.GetString(0);
                        if (!string.IsNullOrEmpty(logo))
                        {
                            logos.Add(logo);
                        }
                    }
                }
            }

            return logos;
        }
    }
}
