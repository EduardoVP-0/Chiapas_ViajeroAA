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
            var operadoraVista = (VistaOperadora)miDataGrid.SelectedItem;

            if (operadoraVista != null)
            {
                // Crear un objeto OperadoraTuristica con los datos disponibles en VistaOperadora
                OperadoraTuristica operadoraCompleta = new OperadoraTuristica
                {
                    Id = operadoraVista.id, // Asegúrate de que el nombre de la propiedad coincida
                    NombreOperadora = operadoraVista.NombreOperadora,
                    Representante = operadoraVista.Representante,
                    Email = operadoraVista.Email,
                    SitioWeb = operadoraVista.SitioWeb,
                    Direccion = operadoraVista.Direccion,
                    // Si hay campos en DetallesOperadora que no están en VistaOperadora, puedes dejarlos vacíos o asignar valores por defecto
                    Descripcion = operadoraVista.Descripcion, // Si no está en VistaOperadora
                    Identificacion = operadoraVista.Identificacion, // Si no está en VistaOperadora
                    Lada = operadoraVista.Lada, // Si no está en VistaOperadora
                    Telefono = operadoraVista.Telefono, // Si no está en VistaOperadora
                    Logo = operadoraVista.Logo // Si no está en VistaOperadora
                };

                // Abrir la ventana DetallesOperadora con los datos
                DetallesOperadora ventanaDetalles = new DetallesOperadora(operadoraCompleta);
                ventanaDetalles.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una operadora primero.");
            }
        }

        private void BtnAgregarOperadora(object sender, RoutedEventArgs e)
        {
            Registros_Datos VentanaAgregar = new Registros_Datos();
            VentanaAgregar.Show();

            this.Close();
        }

        //CODIGO PARA LA VENTANA DE EDITAR
        private void BtnEditar(object sender, RoutedEventArgs e)
        {
            var operadoraSeleccionada = (VistaOperadora)miDataGrid.SelectedItem;

            if (operadoraSeleccionada != null)
            {
                // Abrir la ventana EditarOperadora y pasarle el ID
                EditarOperadora ventanaEditar = new EditarOperadora(operadoraSeleccionada.id);
                ventanaEditar.Show();

                this.Close(); // Cerrar la ventana actual si lo deseas
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una operadora primero.");
            }
        }




        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (miDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una fila para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            dynamic filaSeleccionada = miDataGrid.SelectedItem;
            int id = filaSeleccionada.IdOperadora; // Ajusta según el nombre exacto del campo

            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de eliminar esta operadora?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                bool exito = operadoraEliminarLogica.Eliminar(id);
                if (exito)
                {
                    MessageBox.Show("Operadora eliminada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarDatos(); // Refresca el DataGrid
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la operadora.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnHome(object sender, RoutedEventArgs e)
        {
            Home VentanaHome = new Home();
            VentanaHome.Show();

            this.Close();
        }
    }
}
