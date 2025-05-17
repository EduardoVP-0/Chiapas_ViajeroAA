using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using Chiapas_ViajeroAA;

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
            Logueado.Content = App.UsuarioLogueado;
            CargarImagenUsuario();
            IniciarCarrusel();
            MostrarUltimos4Logos();

        }

        private void CargarImagenUsuario()
        {
            if (!string.IsNullOrEmpty(App.NombreArchivoFoto))
            {
                try
                {
                    string carpetaFotos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos");
                    string rutaCompleta = Path.Combine(carpetaFotos, App.NombreArchivoFoto);

                    if (File.Exists(rutaCompleta))
                    {
                        ImgLogueado.Source = new BitmapImage(new Uri(rutaCompleta));
                    }
                    else
                    {
                        // Opcional: Cargar una imagen por defecto si no existe
                        ImgLogueado.Source = new BitmapImage(
                            new Uri("pack://application:,,,/Recursos/imagen_default.png"));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar imagen: " + ex.Message);
                    // Opcional: Mostrar imagen por defecto en caso de error
                }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Logueado.Content = App.UsuarioLogueado;
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

        private void Btn_Perfil(object sender, RoutedEventArgs e)
        {
            Perfil VentanaPerfil = new Perfil();
            VentanaPerfil.Show();
        }

        // Modifica el método Btn_Registros en Home.xaml.cs para que quede así:
        private void Btn_Registros(object sender, RoutedEventArgs e)
        {
            Gestion_Operadora ventanaRegistro = new Gestion_Operadora();
            ventanaRegistro.Show();
            this.Hide(); // Cambia Close() por Hide()
        }

        //Mostrar las 4 ULtimas Fotos de las operadoras
        private void MostrarUltimos4Logos()
        {
            try
            {
                var repo = new Chiapas.ViajeroAA.Conexion.RepositorioOperadora();
                var logos = repo.ObtenerUltimos4Logos();

                // Ruta base donde se almacenan las imágenes
                string rutaBase = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos");

                // Cargar imágenes si existen
                if (logos.Count > 0)
                {
                    string ruta1 = System.IO.Path.Combine(rutaBase, logos[0]);
                    if (File.Exists(ruta1))
                        Image1.Source = new BitmapImage(new Uri(ruta1, UriKind.Absolute));
                }

                if (logos.Count > 1)
                {
                    string ruta2 = System.IO.Path.Combine(rutaBase, logos[1]);
                    if (File.Exists(ruta2))
                        Image2.Source = new BitmapImage(new Uri(ruta2, UriKind.Absolute));
                }

                if (logos.Count > 2)
                {
                    string ruta3 = System.IO.Path.Combine(rutaBase, logos[2]);
                    if (File.Exists(ruta3))
                        Image3.Source = new BitmapImage(new Uri(ruta3, UriKind.Absolute));
                }

                if (logos.Count > 3)
                {
                    string ruta4 = System.IO.Path.Combine(rutaBase, logos[3]);
                    if (File.Exists(ruta4))
                        Image4.Source = new BitmapImage(new Uri(ruta4, UriKind.Absolute));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las imágenes de operadoras: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuarios ventanaUsuarios = new Usuarios();
            ventanaUsuarios.Show();
            this.Hide(); // Cambia Close() por Hide()
        }

        //Cambios
    }
}
