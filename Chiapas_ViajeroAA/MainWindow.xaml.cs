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

        private void BtnRegistros(Object sender, RoutedEventArgs e)
        {
            Registros_Datos VentanaDatos = new Registros_Datos();
            VentanaDatos.Show();

            this.Close();
        }

        private void BtnGestion(Object sender, RoutedEventArgs e)
        {
            Gestion_Operadora VentanaGes = new Gestion_Operadora();
            VentanaGes.Show();

            this.Close();
        }

        private void BtnHome(Object sender, RoutedEventArgs e)
        {
            Home VentanaHome = new Home();
            VentanaHome.Show();

            this.Close();
        }

    }
}
