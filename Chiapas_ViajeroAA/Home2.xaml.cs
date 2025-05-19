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
    /// Lógica de interacción para Home2.xaml
    /// </summary>
    public partial class Home2 : Window
    {

        private List<string> imagenes = new List<string>
        {
            "Banner1.png",
            "Banner2.png"
        };

        private int indice = 0;
        private DispatcherTimer temporizador;

        public Home2()
        {
            InitializeComponent();
            Logueado.Content = App.UsuarioLogueado; //Donde aparece el logueado
            CargarImagenUsuario();
            IniciarCarrusel();
            MostrarUltimos4Logos();
        }

        //Logueado

        //Imagen del Usuario
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


        //Carrusel de las imagenes 
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

        //Boton de registros
        private void Btn_Registros(object sender, RoutedEventArgs e)
        {
            Gestion_Operadora2 ventanaRegistro = new Gestion_Operadora2();
            ventanaRegistro.Show();
            this.Hide(); // Cambia Close() por Hide()
        }

        private void Btn_Perfil(object sender, RoutedEventArgs e)
        {
            Perfil VentanaPerfil = new Perfil();
            VentanaPerfil.Show();
        }

        //ventana Usuario
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuarios2 ventanaUsuarios = new Usuarios2();
            ventanaUsuarios.Show();
            this.Hide(); // Cambia Close() por Hide()
        }

        //Ventana Todas las Operadoras
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Operadoras_Todas2 ventanaOperadoras = new Operadoras_Todas2();
            ventanaOperadoras.Show();
            this.Hide(); // Cambia Close() por Hide()
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Operadoras_Todas2 ventanaOperadoras = new Operadoras_Todas2();
            ventanaOperadoras.Show();
            this.Hide(); // Cambia Close() por Hide()
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Estadisticas2 ventanaEstadisticas = new Estadisticas2();
            ventanaEstadisticas.Show();
            this.Close(); // Cambia Close() por Hide()
        }

        //Boton Salir (Inicio Sesión)
        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            MainWindow VentanaSalir = new MainWindow();
            VentanaSalir.Show();

            this.Close();
        }


        //Mostrar las 4 ULtimas Fotos de las operadoras
        private void MostrarUltimos4Logos()
        {
            try
            {
                var repo = new Chiapas.ViajeroAA.Conexion.RepositorioOperadora2();
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

    }
}
