using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para IniciarSesion.xaml
    /// </summary>
    public partial class IniciarSesion : Window
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }


        //PARA EL TXTEMAIL DE EMAIL
        private void txtEmail_MouseEnter(object sender, MouseEventArgs e)
        {
            // Si el texto aún es "email", lo borra
            if (txtEmail.Text == "email")
            {
                txtEmail.Text = "";
                txtEmail.Foreground = Brushes.Black;
            }
        }

        private void txtEmail_MouseLeave(object sender, MouseEventArgs e)
        {
            // Si el campo está vacío, vuelve a poner "email"
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "email";
                txtEmail.Foreground = new SolidColorBrush(Color.FromRgb(118, 113, 113));
            }
        }




        //PARA EL TXTCONTRASEÑA DE CONTRASEÑA
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Oculta el placeholder si hay texto
            passwordPlaceholder.Visibility = string.IsNullOrEmpty(txtPassword.Password)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void txtPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            // Si no hay texto, oculta placeholder
            if (string.IsNullOrEmpty(txtPassword.Password))
                passwordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void txtPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            // Si sigue vacío al salir el cursor, vuelve a mostrar placeholder
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



    }
}
