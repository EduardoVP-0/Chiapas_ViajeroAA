using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chiapas.ViajeroAA.Conexion;
using Chiapas.ViajeroAA.Logica;

namespace Pagina_Principal
{
    public partial class Registros_Datos : Window
    {
        private ServicioDatos _Serviciodatos;
        private string rutaImagenSeleccionada = string.Empty;

        public Registros_Datos()
        {
            InitializeComponent();
            _Serviciodatos = new ServicioDatos(new DatosOperadora());
        }

        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                ImgOperadora.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                // Oculta el Border al mostrar la imagen
                borderImagen.Background = Brushes.Transparent;
                borderImagen.BorderBrush = Brushes.Transparent;

                rutaImagenSeleccionada = openFileDialog.FileName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nombreoperadora = TxtNombre.Text;
            string sitioweb = TxtSitio.Text;
            string descripcion = TxtDescripcion.Text;
            string direccion = TxtDireccion.Text;
            string ladaa = CmbLada.Text;
            string telefono = TxtTelefono.Text;
            string representante = TxtRepresentante.Text;
            string correo = TxtCorreo.Text;
            string identificacion = TxtIdentificacion.Text;
            string fotoPath = string.Empty;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(nombreoperadora) || string.IsNullOrEmpty(sitioweb) || string.IsNullOrEmpty(descripcion)
                || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(ladaa) || string.IsNullOrEmpty(telefono)
                || string.IsNullOrEmpty(representante) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(identificacion))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Verificar que la imagen esté seleccionada
            if (ImgOperadora.Source != null)
            {
                fotoPath = GuardarImagen();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una foto.");
                return;
            }

            try
            {
                _Serviciodatos.CrearOperadora(nombreoperadora, sitioweb, descripcion, direccion,
                    ladaa, telefono, representante, correo, identificacion, fotoPath);

                MessageBox.Show("Operadora guardada exitosamente.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private string GuardarImagen()
        {
            string carpetaFotos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos");
            Directory.CreateDirectory(carpetaFotos); // Crea carpeta si no existe

            string nombreImagen = Guid.NewGuid().ToString() + Path.GetExtension(rutaImagenSeleccionada);
            string destino = Path.Combine(carpetaFotos, nombreImagen);

            File.Copy(rutaImagenSeleccionada, destino, true); // 'true' para sobrescribir si existe

            return nombreImagen; // Esto guarda solo el nombre, no la ruta completa
        }

        private void LimpiarFormulario()
        {
            TxtNombre.Clear();
            TxtSitio.Clear();
            TxtDescripcion.Clear();
            TxtDireccion.Clear();
            CmbLada.SelectedIndex = -1;
            TxtTelefono.Clear();
            TxtRepresentante.Clear();
            TxtCorreo.Clear();
            TxtIdentificacion.Clear();

            ImgOperadora.Source = null;
            borderImagen.Background = Brushes.White;
            borderImagen.BorderBrush = Brushes.Gray;

            rutaImagenSeleccionada = string.Empty;

            TxtNombre.Focus(); // Opcional: enfoca al primer campo
        }

        private void BtnRegresar(Object Sender, RoutedEventArgs e)
        {
            Gestion_Operadora ventanaRegresar = new Gestion_Operadora();
            ventanaRegresar.Show();
            this.Close();
        }
    }
}
