﻿using Clases2.Clases;
using ejercicio8DI.Clases;
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
using static Clases2.Clases.EmpleadoPublico;
using static Clases2.Clases.Profesor;

namespace ejercicio8DI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProfesorFuncionario> listaProfesores = new List<ProfesorFuncionario>();
        int indiceActualProfesor = 0;
        const string rutaFija = "..\\..\\..\\imagenes\\iconos\\";
        public MainWindow()
        {
            InitializeComponent();
            seguroMedico.Items.Add("SS");
            seguroMedico.Items.Add("MUFACE");

            gridBotones.IsEnabled = false;
            gridContenido.IsEnabled = false;
            menuFiltros.IsEnabled = false;
            menuAgrupacion.IsEnabled = false;

          
            //Imagenes flechas
            imgPrimero.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "flechaIzquierda.png") as ImageSource;
            imgSegundo.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "flechaGordaIzquierda.png") as ImageSource;
            imgTercero.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "flechaGordaDerecha.png") as ImageSource;
            imgCuarto.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "flechaDerecha.png") as ImageSource;
           //Imagenes interaccion usuarios y profesores
            imgActualizarUsuario.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "actualizarUsuario.png") as ImageSource;
            imgAnadir.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "agregarUsuario.png") as ImageSource;
            imgBorrarUsuario.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "borrarUsuario.png") as ImageSource;
            imgCancelar.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "eliminar.png") as ImageSource;
            imgGuardar.Source = (new ImageSourceConverter()).ConvertFromString(rutaFija + "guardar.png") as ImageSource;
        }

        private void menuArchivo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cargarDatos(ProfesorFuncionario profesorActual) {
            tbNombre.Text = profesorActual.Nombre;
            tbApellidos.Text = profesorActual.apellidos;
            tbEmail.Text = profesorActual.Id;
            destino.IsChecked = profesorActual.DestinoDefinitivo;
            for (int i = 22; i < 70; i++)
            {
                cbEdad.Items.Add(i);
            }
            foreach (int i in cbEdad.Items)
            {
                if (i == profesorActual.edad)
                {
                    cbEdad.SelectedItem = i;
                }
            }
            tbIngreso.Text = profesorActual.AnyoIngresoCuerpo + "";
            if (profesorActual.tipoFuncionario == Profesor.TipoFuncionario.EnPracticas)
            {
                rbPracticas.IsChecked = true;
            }
            else if (profesorActual.tipoFuncionario == Profesor.TipoFuncionario.DeCarrera)
            {
                rbCarrera.IsChecked = true;
            }
            if (profesorActual.tipoMedico == EmpleadoPublico.TipoMedico.SS)
            {
                seguroMedico.SelectedIndex = 0;
            }
            else { 
                seguroMedico.SelectedIndex = 1;
            }
            string rutaCompleta = "..\\..\\..\\imagenes\\" + profesorActual.rutaFoto;
            imagenProfesor.Source = (new ImageSourceConverter()).ConvertFromString(rutaCompleta) as ImageSource;


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
                        string[] texto = line.Split(";");
                        string Nombre = texto[0];
                        string apellidos = texto[1];
                        int edad = Int32.Parse(texto[2]);
                        string Id = texto[3];
                        string Materia = texto[4];
                        TipoFuncionario tipoFuncionario = (TipoFuncionario)Enum.Parse(typeof(TipoFuncionario), texto[5]);
                        int AnyoIngresoCuerpo = Int32.Parse(texto[6]);
                        bool DestinoDefinitivo = (texto[7].Equals("true") ? true : false);
                        EmpleadoPublico.TipoMedico tipoMedico = (EmpleadoPublico.TipoMedico)Enum.Parse(typeof(EmpleadoPublico.TipoMedico), texto[8]);
                        string nombreImagen = texto[9];
                        string rutaFoto = "profesores\\" + nombreImagen;
                        ProfesorFuncionario p = new ProfesorFuncionario();
                        p.rutaFoto = rutaFoto;
                        p.edad = edad;
                        p.Materia = Materia;
                        p.apellidos = apellidos;
                        p.Id = Id;
                        p.tipoFuncionario = tipoFuncionario;
                        p.AnyoIngresoCuerpo = AnyoIngresoCuerpo;
                        p.DestinoDefinitivo = DestinoDefinitivo;
                        p.nombreImagen = nombreImagen;
                        p.tipoMedico = tipoMedico;
                        p.Nombre = Nombre;
                        listaProfesores.Add(p);
                    }
                    cargarDatos(listaProfesores[0]);
                    gridBotones.IsEnabled = true;
                    gridContenido.IsEnabled = true;
                    menuFiltros.IsEnabled = true;
                    menuAgrupacion.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos(listaProfesores[0]);
            indiceActualProfesor = 0;
        }

        private void btnSegundo_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActualProfesor > 0)
            {
                indiceActualProfesor--;
                cargarDatos(listaProfesores[indiceActualProfesor]);
            }

        }

        private void btnTercero_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActualProfesor < listaProfesores.Count-1)
            {
                indiceActualProfesor++;
                cargarDatos(listaProfesores[indiceActualProfesor]);
            }
            
        }

        private void btnCuarto_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos(listaProfesores[listaProfesores.Count - 1]);
            indiceActualProfesor = listaProfesores.Count;
        }

        private void agrupacion1(object sender, RoutedEventArgs e)
        {
            Auxiliar.agrupar1(listaProfesores);
        }

        private void agrupacion3(object sender, RoutedEventArgs e)
        {
            Auxiliar.agrupar3(listaProfesores);
        }

        private void agrupacion2(object sender, RoutedEventArgs e)
        {
            Auxiliar.agrupar2(listaProfesores);
        }

        private void agrupacion4(object sender, RoutedEventArgs e)
        {
            Auxiliar.agrupar4(listaProfesores);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Negrita_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var control in gridContenido.Children)
            {
                if (control is Control) 
                {
                    Control elemento = (Control)control;
                    elemento.FontWeight = FontWeights.Bold;
                }
            }
        }

        private void Negrita_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var control in gridContenido.Children)
            {
                if (control is Control)
                {
                    Control elemento = (Control)control;
                    elemento.FontWeight = FontWeights.Normal;
                }
            }
        }

        private void Cursiva_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var control in gridContenido.Children)
            {
                if (control is Control)
                {
                    Control elemento = (Control)control;
                    elemento.FontStyle = FontStyles.Italic;
                }
            }
        }
        private void Cursiva_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var control in gridContenido.Children)
            {
                if (control is Control)
                {
                    Control elemento = (Control)control;
                    elemento.FontStyle = FontStyles.Normal;
                }
            }
        }

        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void filtro1(object sender, RoutedEventArgs e)
        {
            Auxiliar.mayores35(listaProfesores); 
        }

        private void filtro2(object sender, RoutedEventArgs e)
        {
            Auxiliar.filtrarAnoDeIngreso(listaProfesores);
        }

        private void filtro3(object sender, RoutedEventArgs e)
        {
            Auxiliar.filtrarAnoDeIngresoEstadoCivil(listaProfesores);
        }

        private void filtro4(object sender, RoutedEventArgs e)
        {
            Auxiliar.estaturaSuperio160(listaProfesores);
        }



        private void menuArchivo_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
