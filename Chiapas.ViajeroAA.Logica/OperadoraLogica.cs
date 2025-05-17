using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class OperadoraLogica
    {
        private Chiapas.ViajeroAA.Conexion.Conexion conexion;

        public OperadoraLogica(Chiapas.ViajeroAA.Conexion.Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<OperadoraTuristica> ObtenerOperadoras()
        {
            List<OperadoraTuristica> lista = new List<OperadoraTuristica>();
            string query = "SELECT id, nombre_operadora, logo, representante, email, sitio_web FROM operadora";

            using (var conn = conexion.ObtenerConexion())
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new OperadoraTuristica
                    {
                        Id = reader.GetInt32("id"),
                        NombreOperadora = reader.GetString("nombre_operadora"),
                        Logo = reader.GetString("logo"),
                        Representante = reader.GetString("representante"),
                        Email = reader.GetString("email"),
                        SitioWeb = reader.GetString("sitio_web")
                    });
                }
            }
            return lista;
        }
    }
}
