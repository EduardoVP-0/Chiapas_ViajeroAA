using System;
using System.Windows;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //PARA IR A LA VENTANA DE INICIAR SESION
        private void BtnIniciarSesion(object sender, RoutedEventArgs e)
        {
            IniciarSesion ventana = new IniciarSesion();
            ventana.Show();

            this.Close();
        }

        //PARA IR A LA VENTANA DE CREAR CUENTA
        private void BtnCrearCuenta(object sender, RoutedEventArgs e)
        {
            CrearCuenta ventanacrear = new CrearCuenta();
            ventanacrear.Show();

            this.Close();
        }

    }
}
