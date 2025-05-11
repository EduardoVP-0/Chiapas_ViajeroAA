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

        public List<VistaOperadora> ObtenerOperadoras()
        {
            var lista = new List<VistaOperadora>();

            using (var conn = _conexion.ObtenerConexion())
            {
                string query = "SELECT id, nombre_operadora, sitio_web, direccion, representante, email FROM operadora";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new VistaOperadora
                        {
                            IdOperadora = reader.GetInt32("id"),
                            NombreOperadora = reader.GetString("nombre_operadora"),
                            SitioWeb = reader.GetString("sitio_web"),
                            Direccion = reader.GetString("direccion"),
                            Representante = reader.GetString("representante"),
                            Email = reader.GetString("email")
                        });
                    }
                }
            }

            return lista;
        }
    }
}
