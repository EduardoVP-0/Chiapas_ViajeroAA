using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private List<string> imagenes = new List<string>
        {
            "Banner1.png",
            "Banner2.png"
        };

        private int indice = 0;
        private DispatcherTimer temporizador;

        public Home()
        {
            InitializeComponent();
            IniciarCarrusel();
        }

        private void IniciarCarrusel()
        {
            temporizador = new DispatcherTimer();
            temporizador.Interval = TimeSpan.FromSeconds(5);
            temporizador.Tick += CambiarImagen;
            temporizador.Start();

            CambiarImagen(null, null); // Mostrar la primera imagen de inmediato
        }

        private void CambiarImagen(object sender, EventArgs e)
        {
            try
            {
                string ruta = imagenes[indice];
                CarruselImage.Source = new BitmapImage(new Uri(ruta, UriKind.Relative));

                // Aplicar la animación de opacidad (fade)
                Storyboard fadeStoryboard = (Storyboard)FindResource("FadeStoryboard");
                CarruselImage.BeginStoryboard(fadeStoryboard);

                // Siguiente índice
                indice = (indice + 1) % imagenes.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen del carrusel: " + ex.Message);
            }
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            MainWindow VentanaSalir = new MainWindow();
            VentanaSalir.Show();

            this.Close();
        }

        private void Btn_Registros(object sender, RoutedEventArgs e)
        {
            Gestion_Operadora ventanaRegistro = new Gestion_Operadora();
            ventanaRegistro.Show();

            this.Close();
        }
    }
}
