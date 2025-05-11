using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Registros_Datos.xaml
    /// </summary>
    public partial class Registros_Datos : Window
    {
        public Registros_Datos()
        {
            InitializeComponent();
        }

        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            // Crear el diálogo de selección de archivo
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Filtrar los tipos de archivo a permitir: PNG, JPG y JPEG
            openFileDialog.Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            // Mostrar el diálogo de archivo
            if (openFileDialog.ShowDialog() == true)
            {
                // Si el usuario selecciona un archivo, se establece la imagen
                ImgOperadora.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                // Ocultar el Border (dejarlo transparente) para que solo se vea la imagen
                borderImagen.Background = Brushes.Transparent;
                borderImagen.BorderBrush = Brushes.Transparent;
            }
        }


    }
}
