using MySql.Data.MySqlClient;
using System;
//
namespace Chiapas.ViajeroAA.Conexion
{
    public class Conexion
    {
        private readonly string cadenaConexion =
           "server=localhost;port=3306;" +
            "database=chiapas_viajero_aa;User Id=root; password=root";
        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar =
                new MySqlConnection(cadenaConexion);
            try
            {
                conectar.Open();
            }
            catch (Exception )
            {
                Console.WriteLine("error");
            }
            return conectar;
        }
    }
}
