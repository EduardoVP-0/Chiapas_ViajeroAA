using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chiapas.ViajeroAA.Conexion;
using Chiapas.ViajeroAA.Logica;
using Path = System.IO.Path;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Operadoras_Todas2.xaml
    /// </summary>
    public partial class Operadoras_Todas2 : Window
    {
        public List<OperadoraUI> Operadoras { get; set; }
        public Operadoras_Todas2()
        {
            InitializeComponent();
            CargarOperadoras();
            DataContext = this;
        }
        private void CargarOperadoras()
        {
            Conexion conexion = new Conexion();
            OperadoraLogica2 logica = new OperadoraLogica2(conexion);
            var lista = logica.ObtenerOperadoras();

            Operadoras = new List<OperadoraUI>();
            foreach (var item in lista)
            {
                string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos", item.Logo);
                var imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(rutaImagen, UriKind.Absolute);
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.EndInit();

                Operadoras.Add(new OperadoraUI
                {
                    Id = item.Id,
                    NombreOperadora = item.NombreOperadora,
                    LogoImagen = imagen,
                    Representante = item.Representante,
                    Email = item.Email,
                    SitioWeb = item.SitioWeb,
                    OperadoraCompleta = item
                });
            }
        }

        private void BtnVerMas_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as FrameworkElement;
            if (boton?.DataContext is OperadoraUI operadora)
            {
                DetallesOperadora2 detalles = new DetallesOperadora2(operadora.OperadoraCompleta);
                detalles.Owner = this;
                detalles.Show(); // No cierra la ventana actual
            }
        }

        private void BtnHome3(object sender, RoutedEventArgs e)
        {
            Home2 ventanaHome3 = new Home2();
            ventanaHome3.Show();

            this.Close();
        }

        public class OperadoraUI
        {
            public int Id { get; set; }
            public string NombreOperadora { get; set; }
            public BitmapImage LogoImagen { get; set; }
            public string Representante { get; set; }
            public string Email { get; set; }
            public string SitioWeb { get; set; }
            public OperadoraTuristica2 OperadoraCompleta { get; set; } // Para ventana emergente
        }
    }
}
