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
using LiveCharts;
using LiveCharts.Wpf;
using System.Data;
using Chiapas.ViajeroAA.Conexion;
using Chiapas.ViajeroAA.Logica;

namespace Pagina_Principal
{
    /// <summary>
    /// Lógica de interacción para Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }

        public Estadisticas()
        {
            InitializeComponent();

            // Cargar datos
            var conexion = new Conexion();
            var datos = new EstadisticasDatos(conexion);
            var logica = new EstadisticasLogica(datos);

            TxtTotalOperadoras.Text = logica.ObtenerTotalOperadoras().ToString();
            TxtTotalAdministradores.Text = logica.ObtenerTotalAdministradores().ToString();

            var top = logica.ObtenerOperadoraTop();
            TxtTopOperadora.Text = $"{top.Nombre} ({top.Total})";

            var dt = logica.ObtenerDatosGrafica();

            var valores = new ChartValues<int>();
            Labels = new List<string>();

            foreach (DataRow fila in dt.Rows)
            {
                Labels.Add(fila["Operadora"].ToString());
                valores.Add(int.Parse(fila["Reservaciones"].ToString()));
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Reservaciones",
                    Values = valores
                }
            };

            DataContext = this;
        }
    }
}
