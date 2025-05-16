using System.Windows;

namespace Chiapas_ViajeroAA
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _usuarioLogueado;
        private static string _nombreArchivoFoto; // Solo guardamos el nombre del archivo

        public static string UsuarioLogueado
        {
            get => _usuarioLogueado;
            set => _usuarioLogueado = value;
        }

        public static string NombreArchivoFoto
        {
            get => _nombreArchivoFoto;
            set => _nombreArchivoFoto = value;
        }
    }
}
