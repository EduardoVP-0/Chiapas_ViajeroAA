using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Conexion
{
    public class RepositorioOperadora2
    {
        private Conexion _conexion;
        public RepositorioOperadora2()
        {
            _conexion = new Conexion();
        }

        //CODIGO DEL DATAGRID
        public List<VistaOperadora2> ObtenerOperadoras()
        {
            var lista = new List<VistaOperadora2>();

            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT id, logo, nombre_operadora, sitio_web, descripcion, direccion, representante, lada, telefono, representante, email, identificacion FROM operadora2";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new VistaOperadora2
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
        public VistaOperadora2 ObtenerOperadoraPorId(int idOperadora)
        {
            VistaOperadora2 operadora = null;

            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT id, logo ,nombre_operadora, sitio_web, descripcion, direccion, lada, telefono, representante, email, identificacion FROM operadora2 WHERE id = @idOperadora";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOperadora", idOperadora);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            operadora = new VistaOperadora2
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
                    // Validaciones de longitud (manejo seguro de Substring)
                    logo = string.IsNullOrWhiteSpace(logo) ? "" : logo.Trim();
                    logo = logo.Length > 255 ? logo.Substring(0, 255) : logo;

                    nombre = string.IsNullOrWhiteSpace(nombre) ? "" : nombre.Trim();
                    nombre = nombre.Length > 50 ? nombre.Substring(0, 50) : nombre;

                    sitio = string.IsNullOrWhiteSpace(sitio) ? "" : sitio.Trim();
                    sitio = sitio.Length > 150 ? sitio.Substring(0, 150) : sitio;

                    descripcion = string.IsNullOrWhiteSpace(descripcion) ? "" : descripcion.Trim(); // TEXT no tiene límite

                    direccion = string.IsNullOrWhiteSpace(direccion) ? "" : direccion.Trim();
                    direccion = direccion.Length > 255 ? direccion.Substring(0, 255) : direccion;

                    lada = string.IsNullOrWhiteSpace(lada) ? "" : lada.Trim();
                    lada = lada.Length > 5 ? lada.Substring(0, 5) : lada;

                    telefono = string.IsNullOrWhiteSpace(telefono) ? "" : telefono.Trim();
                    telefono = telefono.Length > 10 ? telefono.Substring(0, 10) : telefono;

                    representante = string.IsNullOrWhiteSpace(representante) ? "" : representante.Trim();
                    representante = representante.Length > 50 ? representante.Substring(0, 50) : representante;

                    correo = string.IsNullOrWhiteSpace(correo) ? "" : correo.Trim();
                    correo = correo.Length > 50 ? correo.Substring(0, 50) : correo;

                    identificacion = string.IsNullOrWhiteSpace(identificacion) ? "" : identificacion.Trim();
                    identificacion = identificacion.Length > 5 ? identificacion.Substring(0, 5) : identificacion;

                    // Consulta SQL
                    string query = @"UPDATE operadora2 SET 
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
                     WHERE id = @id";

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
                string query = "SELECT logo FROM operadora2 ORDER BY id DESC LIMIT 4";

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
