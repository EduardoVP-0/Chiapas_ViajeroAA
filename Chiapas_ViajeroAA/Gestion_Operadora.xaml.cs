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

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Gestion_Operadora.xaml
    /// </summary>
    public partial class Gestion_Operadora : Window
    {
        public Gestion_Operadora()
        {
            InitializeComponent();
        }

        private void BtnAgregarOperadora(object sender, RoutedEventArgs e)
        {
            Registros_Datos VentanaAgregar = new Registros_Datos();
            VentanaAgregar.Show();

            this.Close();
        }
    }
}
