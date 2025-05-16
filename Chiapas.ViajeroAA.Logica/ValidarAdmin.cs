using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class ValidarAdmin
    {
        private RepositorioAdministrador _repositorio;

        public ValidarAdmin()
        {
            _repositorio = new RepositorioAdministrador();
        }

        public (string Nombre, string NombreArchivoFoto) ObtenerDatosUsuario(string email, string contraseña)
        {
            return _repositorio.ObtenerDatosUsuario(email, contraseña);
        }
    }
}
