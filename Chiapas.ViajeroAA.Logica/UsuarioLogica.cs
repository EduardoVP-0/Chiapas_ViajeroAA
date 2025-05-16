using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;
using MySql.Data.MySqlClient;

namespace Chiapas.ViajeroAA.Logica
{
    public class UsuarioLogica
    {
        private Chiapas.ViajeroAA.Conexion.Conexion conexion;

        public UsuarioLogica(Chiapas.ViajeroAA.Conexion.Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<VistaUsuarios> ObtenerAdministradores()
        {
            List<VistaUsuarios> lista = new List<VistaUsuarios>();
            var query = "SELECT usuario, email FROM administrador";

            MySqlCommand cmd = new MySqlCommand(query, conexion.ObtenerConexion());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new VistaUsuarios
                {
                    Usuario = reader.GetString("usuario"),
                    Correo = reader.GetString("email")
                });
            }

            reader.Close();
            return lista;
        }

        public List<AgenteViaje> ObtenerAgentes()
        {
            List<AgenteViaje> lista = new List<AgenteViaje>();
            var query = "SELECT usuario, correo FROM agente_viaje";

            MySqlCommand cmd = new MySqlCommand(query, conexion.ObtenerConexion());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new AgenteViaje
                {
                    Usuario = reader.GetString("usuario"),
                    Correo = reader.GetString("correo")
                });
            }

            reader.Close();
            return lista;
        }

        public List<Viajero> ObtenerViajeros()
        {
            List<Viajero> lista = new List<Viajero>();
            var query = "SELECT usuario, correo FROM viajero";

            MySqlCommand cmd = new MySqlCommand(query, conexion.ObtenerConexion());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Viajero
                {
                    Usuario = reader.GetString("usuario"),
                    Correo = reader.GetString("correo")
                });
            }

            reader.Close();
            return lista;
        }
    }
}
