using System;
using System.Collections.Generic;
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
using System.IO;
using Path = System.IO.Path;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para DetallesOperadora2.xaml
    /// </summary>
    public partial class DetallesOperadora2 : Window
    {
        public DetallesOperadora2(OperadoraTuristica2 operadora)
        {
            InitializeComponent();
            TxtId.Text = operadora.Id.ToString();
            TxtNombre.Text = operadora.NombreOperadora;
            TxtRepresentante.Text = operadora.Representante;
            TxtEmail.Text = operadora.Email;
            TxtSitioWeb.Text = operadora.SitioWeb;
            TxtDescripcion.Text = operadora.Descripcion;
            TxtDireccion.Text = operadora.Direccion;
            TxtIdentificacion.Text = operadora.Identificacion;
            TxtLada.Text = operadora.Lada;
            TxtTelefono.Text = operadora.Telefono;

            string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos", operadora.Logo);
            if (File.Exists(rutaImagen))
            {
                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(rutaImagen, UriKind.Absolute);
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.EndInit();

                ImgLogo.Source = imagen;
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de imagen: " + rutaImagen, "Error de imagen", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
