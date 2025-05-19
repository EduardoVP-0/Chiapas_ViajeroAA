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
using Chiapas.ViajeroAA.Conexion;
using Chiapas.ViajeroAA.Logica;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Usuarios2.xaml
    /// </summary>
    public partial class Usuarios2 : Window
    {
        private Conexion conexion;
        private UsuarioLogica logica;
        public Usuarios2()
        {
            InitializeComponent();
            conexion = new Conexion(); // Tu clase debe implementar AbrirConexion() y CerrarConexion()
            logica = new UsuarioLogica(conexion);

            // Establecer botón inicial activo
            BtnAgentes.IsEnabled = false;
            _currentActiveButton = BtnAgentes;
            BtnAgentes_Click(null, null);
        }
        

        private void BtnAgentes_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(BtnAgentes);
            List<AgenteViaje> lista = logica.ObtenerAgentes();
            dgUsuarios.ItemsSource = lista;
        }

        private void BtnViajeros_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(BtnViajeros);
            List<Viajero> lista = logica.ObtenerViajeros();
            dgUsuarios.ItemsSource = lista;
        }

        private Button _currentActiveButton;

        private void SetActiveButton(Button activeButton)
        {
            // Resetear el botón anterior
            if (_currentActiveButton != null)
            {
                _currentActiveButton.IsEnabled = true; // Restablecer estado
            }

            // Establecer el nuevo botón activo
            _currentActiveButton = activeButton;
            _currentActiveButton.IsEnabled = false; // Deshabilitar para mantener el estilo
        }


        private void BtnHome(object sender, RoutedEventArgs e)
        {
            Home2 ventanacasa = new Home2();
            ventanacasa.Show();

            this.Close();
        }
    }
}
