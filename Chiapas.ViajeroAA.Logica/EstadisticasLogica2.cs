using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;
using System.Data;


namespace Chiapas.ViajeroAA.Logica
{
    public class EstadisticasLogica2
    {
        private readonly EstadisticasDatos2 datos;

        public EstadisticasLogica2(EstadisticasDatos2 datos)
        {
            this.datos = datos;
        }

        public int ObtenerTotalOperadoras() => datos.ObtenerTotalOperadoras();

        public int ObtenerTotalAdministradores() => datos.ObtenerTotalAdministradores();

        public (string Nombre, int Total) ObtenerOperadoraTop() => datos.ObtenerOperadoraConMasReservaciones();

        public DataTable ObtenerDatosGrafica() => datos.ObtenerTopOperadoras();
    }
}
