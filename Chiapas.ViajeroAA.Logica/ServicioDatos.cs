using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    
    public class ServicioDatos
    {
        private DatosOperadora _dbHelper;
        public ServicioDatos(DatosOperadora dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public void CrearOperadora(string nombreoperadora, string sitioweb, string descripcion, string direccion,
            string ladaa, string telefono, string representante, string correo, string identificacion, string fotoPath)
        {
            // Validar datos de entrada
            if (string.IsNullOrEmpty(nombreoperadora) || string.IsNullOrEmpty(sitioweb) || string.IsNullOrEmpty(descripcion) ||
                string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(ladaa) || string.IsNullOrEmpty(telefono)
                || string.IsNullOrEmpty(representante) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(fotoPath))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            // Llamar a la capa de Datos para insertar el usuario
            _dbHelper.InsertarOperadora(nombreoperadora, sitioweb, descripcion, direccion,
             ladaa, telefono, representante, correo, identificacion, fotoPath);
        }
    }
    
}
