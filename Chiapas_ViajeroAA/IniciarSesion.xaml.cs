using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Chiapas.ViajeroAA.Logica;
using Chiapas_ViajeroAA;

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

        //VALIDAR CORREO Y CONTRASEÑA

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string contraseña = txtPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese su correo y contraseña.");
                return;
            }

            // Declaramos explícitamente la variable datosUsuario
            (string Nombre, string NombreArchivoFoto) datosUsuario = _servicio.ObtenerDatosUsuario(email, contraseña);

            if (datosUsuario.Nombre != null)
            {
                App.UsuarioLogueado = datosUsuario.Nombre;
                App.NombreArchivoFoto = datosUsuario.NombreArchivoFoto;

                // Condición para Liliana Torres
                if (email == "liliana.torres24@gmail.com")
                {
                    Home ventana = new Home();
                    ventana.Show();
                }
                else
                {
                    Home2 ventana = new Home2();
                    ventana.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }
        }
    }
}
