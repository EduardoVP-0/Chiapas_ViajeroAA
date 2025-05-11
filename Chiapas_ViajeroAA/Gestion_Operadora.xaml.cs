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
using Chiapas.ViajeroAA.Logica;
using Chiapas.ViajeroAA.Conexion;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Gestion_Operadora.xaml
    /// </summary>
    public partial class Gestion_Operadora : Window
    {
        private OperadoraVistaServicio _servicio;
        public Gestion_Operadora()
        {
            InitializeComponent();
            _servicio = new OperadoraVistaServicio();
            CargarDatos();
        }
        private void CargarDatos()
        {
            miDataGrid.ItemsSource = _servicio.ObtenerTodas();
        }

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            var operadora = (VistaOperadora)miDataGrid.SelectedItem;

            if (operadora != null)
            {
                MessageBox.Show($"Datos de la operadora:\n\n" +
                                $"Nombre: {operadora.NombreOperadora}\n" +
                                $"Sitio Web: {operadora.SitioWeb}\n" +
                                $"Dirección: {operadora.Direccion}\n" +
                                $"Representante: {operadora.Representante}\n" +
                                $"Email: {operadora.Email}");
            }
        }

        private void BtnAgregarOperadora(object sender, RoutedEventArgs e)
        {
            Registros_Datos VentanaAgregar = new Registros_Datos();
            VentanaAgregar.Show();

            this.Close();
        }
    }
}
