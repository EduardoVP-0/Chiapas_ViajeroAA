using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class OperadoraVistaServicio2
    {
        private RepositorioOperadora2 _repositorio;
        public OperadoraVistaServicio2()
        {
            _repositorio = new RepositorioOperadora2();
        }

        public List<VistaOperadora2> ObtenerTodas()
        {
            return _repositorio.ObtenerOperadoras();
        }
    }
}
