using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiapas.ViajeroAA.Conexion;

namespace Chiapas.ViajeroAA.Logica
{
    public class AdministradorServicio
    {
        private Administrador _dbHelper;

        public AdministradorServicio(Administrador dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public void CrearCuenta(string usuario, string email, string contraseña, string fotoPath)
        {
            // Validar datos de entrada
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(fotoPath))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            // Llamar a la capa de Datos para insertar el usuario
            _dbHelper.InsertarUsuario(usuario, email, contraseña, fotoPath);
        }
    }
}
