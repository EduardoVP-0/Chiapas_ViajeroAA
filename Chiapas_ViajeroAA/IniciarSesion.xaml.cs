using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Chiapas.ViajeroAA.Logica;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para IniciarSesion.xaml
    /// </summary>
    public partial class IniciarSesion : Window
    {
        private ValidarAdmin _servicio;
        public IniciarSesion()
        {
            InitializeComponent();
            _servicio = new ValidarAdmin();
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

        //PARA REGRESAR A LA PANTALLA PRINCIAPL
        private void btn_Login(object sender, MouseButtonEventArgs e)
        {
            CrearCuenta ventanaCrear = new CrearCuenta();
            ventanaCrear.Show();

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string contraseña = txtPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese su correo y contraseña.");
                return;
            }

            bool accesoPermitido = _servicio.IniciarSesion(email, contraseña);

            if (accesoPermitido)
            {
                MessageBox.Show("¡Acceso correcto!");
                // Abrir la ventana principal
                Window1 ventana = new Window1();
                ventana.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }
        }
    }
}
