using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class operadoraEliminarLogica
    {
        public static bool Eliminar(int idOperadora)
        {
            var eliminador = new operadoraEliminar(); // Instancia
            return eliminador.EliminarOperadora(idOperadora);
        }
    }
    }