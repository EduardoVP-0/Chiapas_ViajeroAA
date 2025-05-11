using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para CrearCuenta.xaml
    /// </summary>
    public partial class CrearCuenta : Window
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }



        //PARA REGRESAR A LA PANTALLA PRINCIAPL
        private void Btn_Iniciar(object sender, MouseButtonEventArgs e)
        {
            IniciarSesion ventanaIniciar = new IniciarSesion();
            ventanaIniciar.Show();

            this.Close();
        }


        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text == "usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.Foreground = Brushes.Black;
            }
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "usuario";
                txtUsuario.Foreground = new SolidColorBrush(Color.FromRgb(118, 113, 113));
            }
        }


        //PARA EL TXTEMAIL DE EMAIL
        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            // Si el texto es "email", lo borra y cambia el color del texto a negro
            if (txtEmail.Text == "email")
            {
                txtEmail.Text = "";
                txtEmail.Foreground = Brushes.Black;
            }
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            // Si el campo está vacío, muestra el texto "email"
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "email";
                txtEmail.Foreground = new SolidColorBrush(Color.FromRgb(118, 113, 113));
            }
        }


        //PARA EL TXTCONTRASEÑA DE CONTRASEÑA
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = string.IsNullOrEmpty(txtPassword.Password)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Password))
                passwordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Password))
                passwordPlaceholder.Visibility = Visibility.Visible;
        }

        //SECCION DONDE HACE FUNCIONAR LA IMAGEN
        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                ImgEmpleado.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                // Oculta el Border al mostrar la imagen
                borderImagen.Background = Brushes.Transparent;
                borderImagen.BorderBrush = Brushes.Transparent;
            }
        }


    }
}
