using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class OperadoraVistaServicio
    {
        private RepositorioOperadora _repositorio;
        public OperadoraVistaServicio()
        {
            _repositorio = new RepositorioOperadora();
        }

        public List<VistaOperadora> ObtenerTodas()
        {
            return _repositorio.ObtenerOperadoras();
        }
    }
}
