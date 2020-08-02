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
using System.Windows.Navigation;
using System.Windows.Shapes;
using capa1;
using capa3;

namespace interfas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ventas _ventas = new ventas();
        ventascapa3 _capa3 = new ventascapa3();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {

            txtnombre.Text = string.Empty;
            txtventas.Text = string.Empty;
            txtestado.Text = string.Empty;
            txtnombre.Focus();
        }


        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtnombre.Text == "" || txtventas.Text == "" || txtestado.Text == "")
                {
                    MessageBox.Show("Hay Espacios en Blanco", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {

                    _ventas.Nombre = txtnombre.Text;
                    _ventas.TotalVentas = Convert.ToInt64(txtventas.Text);
                    _ventas.Estado = txtestado.Text;
                    int resultado = _capa3.AgregarVentas(_ventas);
                    if (resultado == 1)
                    {
                        MessageBox.Show("Los Datos se Guardaron Correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Limpiar();
                    }

                }
            }
            catch {

                MessageBox.Show("Hubo un Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void btnconsultar_Click(object sender, RoutedEventArgs e)
        {
            consulta _ver = new consulta();
            this.Close();
            _ver.ShowDialog();
        }

      

    }
}
