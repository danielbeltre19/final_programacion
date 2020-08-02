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
using capa1;
using capa3;

namespace interfas
{
    /// <summary>
    /// Lógica de interacción para consulta.xaml
    /// </summary>
    public partial class consulta : Window
    {
        ventas _ventas = new ventas();
        ventascapa3 _capa3 = new ventascapa3();

        public consulta()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {

            txtnombre.Text = string.Empty;
            txtventas.Text = string.Empty;
            txtestado.Text = string.Empty;
            txtbuscar.Text = string.Empty;
            txtnombre.Focus();
        }

        private void btnmostrar_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtbuscar.Text == ""))
            {
                _ventas.Nombre = txtbuscar.Text;
                Limpiar();
                dgdatos.ItemsSource = _capa3.MostrarVentasNombre(_ventas);
               
            }
        }

        private void dgdatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ventas = dgdatos.SelectedItem as ventas;
            if (_ventas != null)
            {
                txtnombre.Text = _ventas.Nombre;
                txtventas.Text =Convert.ToString (_ventas.TotalVentas);
                txtestado.Text = _ventas.Estado;
            }
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text != "" && txtventas.Text != "" && txtestado.Text != "")
            {
                _ventas.Nombre = txtnombre.Text;
                _ventas.TotalVentas = Convert.ToInt64 (txtventas.Text);
                _ventas.Estado = txtestado.Text;
                if (_capa3.ModificarVentas(_ventas) > 0)
                {
                    MessageBox.Show("Se modifico Correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dgdatos.Items.Refresh();
                    dgdatos.ItemsSource = _capa3.MostrarVentas();
                    Limpiar();
                }
                else {

                    MessageBox.Show("No se pudo Modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
                }
            }
                else{
                  MessageBox.Show("Seleccionar un Registro...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text != "" && txtventas.Text != "" && txtestado.Text != "") 
            {
                MessageBoxResult r = MessageBox.Show("Estas seguro que quieres Eliminar el Registro", "Alert!", MessageBoxButton.OKCancel,MessageBoxImage.Question);
                if (r == MessageBoxResult.OK)
                {
                    _capa3.Eliminar(_ventas);
                    dgdatos.Items.Refresh();
                    dgdatos.ItemsSource = _capa3.MostrarVentas();
                }
                if(r == MessageBoxResult.Cancel)
                {

                }
            }
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _ver = new MainWindow();
            this.Close();
            _ver.ShowDialog();
        }
        }
    }

