using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiapas.ViajeroAA.Conexion
{
    public class OperadoraTuristica
    {
        public int Id { get; set; }
        public string NombreOperadora { get; set; }
        public string Logo { get; set; } // nombre del archivo
        public string Representante { get; set; }
        public string Email { get; set; }
        public string SitioWeb { get; set; }
    }
}
