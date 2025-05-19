using System;
using System.Windows;
using MySql.Data.MySqlClient;
using Chiapas.ViajeroAA.Conexion;
using System.IO;
using System.Windows.Media.Imaging;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para EditarOperadora2.xaml
    /// </summary>
    public partial class EditarOperadora2 : Window
    {
        public EditarOperadora2(int idOperadora)
        {
            InitializeComponent();
            TxtIdOperadora.Text = idOperadora.ToString(); // Mostrar el ID recibido

            // Crear una instancia del repositorio de operadora
            var repositorio = new RepositorioOperadora2();

            // Obtener los detalles de la operadora desde la base de datos
            VistaOperadora2 operadora = repositorio.ObtenerOperadoraPorId(idOperadora);

            if (operadora != null)
            {
                // Rellenar los campos con los datos de la operadora
                TxtNombre.Text = operadora.NombreOperadora;  // Rellenar TxtNombre
                // Aquí puedes rellenar más campos si es necesario
                TxtSitio.Text = operadora.SitioWeb;
                TxtDescripcion.Text = operadora.Descripcion;
                TxtDireccion.Text = operadora.Direccion;
                CmbLada.Text = operadora.Lada;
                TxtTelefono.Text = operadora.Telefono;
                TxtRepresentante.Text = operadora.Representante;
                TxtCorreo.Text = operadora.Email;
                TxtIdentificacion.Text = operadora.Identificacion;


                //PARA MOSTRAR LA IMAGEN
                // Obtener el nombre de la imagen almacenado en "Logo" desde la base de datos
                string nombreImagen = operadora.Logo;  // Aquí es donde se obtiene el nombre de la imagen

                // Construir la ruta completa de la imagen
                string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos", nombreImagen);

                // Verificar si la imagen existe en la ruta
                if (File.Exists(rutaImagen))
                {
                    // Asignar la imagen al control ImgOperadora
                    ImgOperadora.Source = new BitmapImage(new Uri(rutaImagen));
                }
                else
                {
                    // Aquí puedes asignar una imagen por defecto si no se encuentra la imagen
                    MessageBox.Show("La imagen no se encontró.");
                }
            }
            else
            {
                MessageBox.Show("Operadora no encontrada.");
            }
        }

        //BOTON PARA REGRESAR
        private void BtnRegresar(Object Sender, RoutedEventArgs e)
        {
            Gestion_Operadora2 ventanaRegresar = new Gestion_Operadora2();
            ventanaRegresar.Show();

            this.Close();
        }

        //BOTON PARA CAMBIAR LA IMAGEN
        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaOrigen = openFileDialog.FileName;

                // Generamos un nombre único para la imagen utilizando GUID y la extensión original
                string extension = System.IO.Path.GetExtension(rutaOrigen); // Obtenemos la extensión del archivo (ejemplo .jpg)
                string nombreUnicoImagen = Guid.NewGuid().ToString() + extension; // Generamos el nombre único

                // Definimos la ruta de destino donde guardaremos la imagen con el nombre único
                string rutaDestino = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos", nombreUnicoImagen);

                try
                {
                    // Copiamos la imagen a la nueva ruta con el nuevo nombre
                    File.Copy(rutaOrigen, rutaDestino, true); // Sobrescribe si ya existe

                    // Actualizamos la imagen que se muestra en la interfaz
                    ImgOperadora.Source = new BitmapImage(new Uri(rutaDestino));

                    // Guardamos el nombre único de la imagen seleccionada (para usarlo al actualizar la operadora en la base de datos)
                    nombreImagenSeleccionada = nombreUnicoImagen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar imagen: " + ex.Message);
                }
            }
        }

        // Variable global para almacenar el nombre único de la imagen seleccionada
        private string nombreImagenSeleccionada = null;



        //BOTON PARA HACER EL UPDATE DE LOS REGISTROS
        private void Btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de editar este registro?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Obtener datos del formulario
                int id = int.Parse(TxtIdOperadora.Text);
                string logo = nombreImagenSeleccionada ?? System.IO.Path.GetFileName(((BitmapImage)ImgOperadora.Source).UriSource.LocalPath); // usar la nueva imagen o la actual
                string nombre = TxtNombre.Text;
                string sitio = TxtSitio.Text;
                string descripcion = TxtDescripcion.Text;
                string direccion = TxtDireccion.Text;
                string lada = CmbLada.Text;
                string telefono = TxtTelefono.Text;
                string representante = TxtRepresentante.Text;
                string correo = TxtCorreo.Text;
                string identificacion = TxtIdentificacion.Text;

                // Llamar a la capa lógica
                RepositorioOperadora2 repo = new RepositorioOperadora2();
                bool resultado = repo.ActualizarOperadora(id, logo, nombre, sitio, descripcion, direccion, lada, telefono, representante, correo, identificacion);

                if (resultado)
                {
                    MessageBox.Show("Datos editados correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    Gestion_Operadora2 ventana = new Gestion_Operadora2();
                    ventana.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error al editar los datos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
