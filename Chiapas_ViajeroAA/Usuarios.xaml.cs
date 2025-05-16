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
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        private Conexion conexion;
        private UsuarioLogica logica;
        public Usuarios()
        {
            InitializeComponent();
            conexion = new Conexion(); // Tu clase debe implementar AbrirConexion() y CerrarConexion()
            logica = new UsuarioLogica(conexion);
        }
        private void BtnAdministradores_Click(object sender, RoutedEventArgs e)
        {
            List<VistaUsuarios> lista = logica.ObtenerAdministradores();
            dgUsuarios.ItemsSource = lista;
        }

        private void BtnAgentes_Click(object sender, RoutedEventArgs e)
        {
            List<AgenteViaje> lista = logica.ObtenerAgentes();
            dgUsuarios.ItemsSource = lista;
        }

        private void BtnViajeros_Click(object sender, RoutedEventArgs e)
        {
            List<Viajero> lista = logica.ObtenerViajeros();
            dgUsuarios.ItemsSource = lista;
        }
    }
}
