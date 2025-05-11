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
    /// Lógica de interacción para EditarOperadora.xaml
    /// </summary>
    public partial class EditarOperadora : Window
    {
        public EditarOperadora(int idOperadora)
        {
            InitializeComponent();
            TxtIdOperadora.Text = idOperadora.ToString(); // Mostrar el ID recibido
        }
    }

}
