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
    /// Lógica de interacción para Operadoras_Todas.xaml
    /// </summary>
    public partial class Operadoras_Todas : Window
    {
        public List<OperadoraUI> Operadoras { get; set; }
        public Operadoras_Todas()
        {
            InitializeComponent();
            CargarOperadoras();
            DataContext = this;
        }
        private void CargarOperadoras()
        {
            Conexion conexion = new Conexion();
            OperadoraLogica logica = new OperadoraLogica(conexion);
            var lista = logica.ObtenerOperadoras();

            Operadoras = new List<OperadoraUI>();
            foreach (var item in lista)
            {
                string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos", item.Logo);

                Operadoras.Add(new OperadoraUI
                {
                    Id = item.Id,
                    NombreOperadora = item.NombreOperadora,
                    LogoRuta = new Uri(rutaImagen, UriKind.Absolute),
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
                DetallesOperadora detalles = new DetallesOperadora(operadora.OperadoraCompleta);
                detalles.Owner = this;
                detalles.Show(); // No cierra la ventana actual
            }
        }

        public class OperadoraUI
        {
            public int Id { get; set; }
            public string NombreOperadora { get; set; }
            public Uri LogoRuta { get; set; }
            public string Representante { get; set; }
            public string Email { get; set; }
            public string SitioWeb { get; set; }
            public OperadoraTuristica OperadoraCompleta { get; set; } // Para ventana emergente
        }
    }
}

