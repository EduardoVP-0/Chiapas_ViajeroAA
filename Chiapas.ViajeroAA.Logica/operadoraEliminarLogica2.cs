using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class operadoraEliminarLogica2
    {
        public static bool Eliminar(int idOperadora)
        {
            var eliminador = new operadoraEliminar2(); // Instancia
            return eliminador.EliminarOperadora(idOperadora);
        }
    }
}
