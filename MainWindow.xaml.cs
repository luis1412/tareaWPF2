using Clases2.Clases;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ejercicio8DI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProfesorFuncionario> listaProfesores = new List<ProfesorFuncionario>();

        public MainWindow()
        {
            InitializeComponent();


           // const string rutaFija = "..\\..\\..\\imagenes\\";
            // string miruta = profe.RutaFoto;
            imgPrimero.Source = (new ImageSourceConverter()).ConvertFromString("Resources/flecha1.png") as ImageSource;
            imgSegundo.Source = (new ImageSourceConverter()).ConvertFromString("Resources/flecha.png") as ImageSource;

        }

        private void menuArchivo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cargarDatos(ProfesorFuncionario profesorActual) {
            tbNombre.Text = profesorActual.Nombre;
            tbApellidos.Text = profesorActual.apellidos;
            tbEmail.Text = profesorActual.email;
            destino.IsChecked = profesorActual.DestinoDefinitivo;
            cbEdad.Items.Add(profesorActual.edad);
            cbEdad.SelectedIndex = 0;
            tbIngreso.Text = profesorActual.AnyoIngresoCuerpo + "";
            
            
        }


        private void filtro1(object sender, RoutedEventArgs e)
        {

        }

        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            //Nos situamos en el directorio desde el que se ejecuta la aplicación
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            //En el cuadro de diálogo se van a mostrar todos los archivos que sean de texto o //si no, todos
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //Por defecto, cuando se abra, nos va a mostrar los que sean de texto
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true) //Cuando el usuario le dé a Aceptar
            {
                try
                {   //Obtengo una colección de líneas (en cada una están los datos
                    //de un profesor), luego las iré recorriendo con un foreach
                    var lineas = File.ReadLines(openFileDialog.FileName);
                
                    foreach (string line in lineas) {
                        listaProfesores.Add(new ProfesorFuncionario(line));
                    }
                    cargarDatos(listaProfesores[0]);
                }
                catch
                {

                }
            }
        }

        private void agrupacion2(object sender, RoutedEventArgs e)
        {

        }

        private void agrupacion4(object sender, RoutedEventArgs e)
        {

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Negrita_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Negrita_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Cursiva_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cursiva_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void filtro2(object sender, RoutedEventArgs e)
        {

        }

        private void filtro3(object sender, RoutedEventArgs e)
        {

        }

        private void filtro4(object sender, RoutedEventArgs e)
        {

        }

        private void agrupacion1(object sender, RoutedEventArgs e)
        {

        }

        private void agrupacion3(object sender, RoutedEventArgs e)
        {

        }

        private void menuArchivo_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
