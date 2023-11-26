using Clases2.Clases;
using ejercicio8DI.Clases;
using ejercicio8DI.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Clases2.Clases.EmpleadoPublico;
using static Clases2.Clases.Profesor;

namespace ejercicio8DI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public bool anadirOActualizar;
        List<ProfesorFuncionario> listaProfesores = new List<ProfesorFuncionario>();
        List<ProfesorExtendido> listaProfesoresExtendidos = new List<ProfesorExtendido>();
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



            btnAnadirUsuario.IsEnabled = true;
        }

        private void menuArchivo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cargarDatos(ProfesorFuncionario profesorActual)
        {
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
            else
            {
                seguroMedico.SelectedIndex = 1;
            }
            string rutaCompleta = "..\\..\\..\\imagenes\\" + profesorActual.rutaFoto;

            try
            {
                imagenProfesor.Source = (new ImageSourceConverter()).ConvertFromString(rutaCompleta) as ImageSource;

            }
            catch (Exception e) {
                imagenProfesor.Source = (new ImageSourceConverter()).ConvertFromString("..\\..\\..\\imagenes\\profesores\\nada.png") as ImageSource;
            }


        }



        public void anadirRegistrosLista()
        {
            using (Contexto context = new Contexto())
            {
                listaProfesores = context.ProfesoresFuncionarios.ToList();
                listaProfesoresExtendidos = context.ProfesoresExtendidos.ToList();
                cargarDatos(listaProfesores[0]);
            }

        }



        public void activarCamposNuevo(bool activado)
        {
            btnActualizarUsuario.IsEnabled = activado;
            btnPrimero.IsEnabled = activado;
            btnSegundo.IsEnabled = activado;
            btnTercero.IsEnabled = activado;
            btnCuarto.IsEnabled = activado;
            btnBorrarUsuario.IsEnabled = activado;

        }


        public void borrarCampos()
        {
            tbNombre.Text = "";
            tbApellidos.Text = "";
            tbEmail.Text = "";
            destino.IsChecked = false;
            cbEdad.Text = "";
            tbIngreso.Text = "";
        }


        public void cargarCombo()
        {
            cbEdad.Items.Clear();
            for (int i = 22; i < 70; i++)
            {
                cbEdad.Items.Add(i);
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        public void activarDesactivarCamposText(bool isEnabled)
        {
            tbNombre.IsReadOnly = isEnabled;
            tbApellidos.IsReadOnly = isEnabled;
            tbEmail.IsReadOnly = true;
            destino.IsEnabled = !isEnabled;
            cbEdad.IsReadOnly = isEnabled;
            tbIngreso.IsReadOnly = isEnabled;
            rbPracticas.IsEnabled = !isEnabled;
            rbCarrera.IsEnabled = !isEnabled;
            seguroMedico.IsEnabled = !isEnabled;
        }


        public bool comprobarCampos()
        {
            int resultado;

            if (tbNombre.Text.Length <= 0)
            {
                MessageBox.Show("El nombre no puede estar vacio");
                tbNombre.Focus();
                return false;
            }
            else if (tbApellidos.Text.Length <= 0)
            {
                MessageBox.Show("El apellido no puede estar vacio");
                tbApellidos.Focus();
                return false;
            }
            else if (tbIngreso.Text.Length <= 0 || !Int32.TryParse(tbIngreso.Text, out resultado))
            {
                tbIngreso.Focus();
                MessageBox.Show("El año de ingreso no puede estar vacio, o no lo has introducido con numeros enteros");
                return false;
            }
            else if (seguroMedico.SelectedIndex == -1)
            {
                seguroMedico.Focus();
                MessageBox.Show("Selecciona un seguro medico");
                return false;
            }
            else
            {
                return true;
            }
        }


        public void activarFlechas(bool activado) {
            btnPrimero.IsEnabled = activado;
            btnSegundo.IsEnabled = activado;
            btnTercero.IsEnabled = activado;
            btnCuarto.IsEnabled = activado;
            btnActualizarUsuario.IsEnabled = activado;
            btnBorrarUsuario.IsEnabled = activado;
            btnGuardarUsuario.IsEnabled = !activado;
            btnCancelarUsuario.IsEnabled = !activado;
        }


        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            activarFlechas(true);
            imagenProfesor.IsEnabled = true;

            if (comprobarRegistroBD())
            {
                anadirRegistrosLista();
                activarControles(true);
            }
            else
            {
                seleccionarArchivoYCargar();
            }

        }


        public void seleccionarArchivoYCargar()
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

                    foreach (string line in lineas)
                    {
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
                    activarControles(true);
                    anadirFicheroABD(listaProfesores);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void activarControles(bool activar)
        {
            gridBotones.IsEnabled = activar;
            gridContenido.IsEnabled = activar;
            menuFiltros.IsEnabled = activar;
            menuAgrupacion.IsEnabled = activar;
        }

        public void anadirFicheroABD(List<ProfesorFuncionario> profesorFuncionarios, List<ProfesorExtendido> profesorExtendidos = null)
        {
            using (Contexto context = new Contexto())
            {
                context.ProfesoresFuncionarios.AddRange(profesorFuncionarios);
                if (profesorExtendidos != null)
                {
                    context.ProfesoresExtendidos.AddRange(profesorExtendidos);
                }
                context.SaveChanges();
            }


        }


        public bool comprobarRegistroBD()
        {
            var context = new Contexto();

            if (!context.ProfesoresExtendidos.Any() && !context.ProfesoresFuncionarios.Any())
            {
                MessageBox.Show("No hay nigun registro en la base de datos");
                return false;
            }
            else
            {
                return true;
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
            if (indiceActualProfesor < listaProfesores.Count - 1)
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
            activarControles(true);
            activarDesactivarCamposText(false);
            borrarCampos();
            activarFlechas(false);
            cargarCombo();
            anadirOActualizar = true;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            tbNombre.IsReadOnly = true;
            tbApellidos.IsReadOnly = true;
            tbEmail.IsReadOnly = true;
            destino.IsEnabled = true;
            cbEdad.IsReadOnly = false;
            tbIngreso.IsReadOnly = false;
            rbPracticas.IsEnabled = true;
            rbCarrera.IsEnabled = true;
            seguroMedico.IsEnabled = true;
            btnGuardarUsuario.IsEnabled = true;
            anadirOActualizar = false;
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult resultado = MessageBox.Show("Quiere continuar", "Confirmacion", MessageBoxButton.OKCancel);

            if (resultado == MessageBoxResult.OK)
            {
                ProfesorFuncionario p = listaProfesores[indiceActualProfesor];
                using (Contexto context = new Contexto())
                {

                    context.Entry(p).State = EntityState.Deleted;
                    context.SaveChanges();
                    Abrir_Click(sender, new RoutedEventArgs(Button.ClickEvent));

                }

            }

            }

        public string GenerarEmail(string Nombre, string apellidos)
        {
            string[] apellidosArray = apellidos.Split(" ");
            string emailLocal = "";
            if (apellidosArray.Length == 1)
            {
                emailLocal = apellidosArray[0].Substring(0, 2).ToLower() + apellidosArray[0].Substring(0, 2).ToLower() + Nombre.Substring(0, 1).ToLower();
            }
            else
            {
                emailLocal = apellidosArray[0].Substring(0, 2).ToLower() + apellidosArray[1].Substring(0, 2).ToLower() + Nombre.Substring(0, 1).ToLower();
            }
            return emailLocal + "@trass.com";
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Quiere continuar", "Confirmacion", MessageBoxButton.OKCancel);



            if (resultado == MessageBoxResult.OK)
            {
                if (comprobarRegistroBD())
                {
                    Abrir_Click(sender, new RoutedEventArgs(Button.ClickEvent));
                    anadirRegistrosLista();
                }
                else
                {
                    activarCamposNuevo(false);
                    activarControles(false);
                }

            }

        }


        public void guardarUsuarioNuevo() {
            if (comprobarCampos())
            {
                ProfesorFuncionario p = new ProfesorFuncionario();
                p.edad = Int32.Parse(cbEdad.SelectedItem.ToString());
                p.apellidos = tbApellidos.Text;
                if ((bool)rbCarrera.IsChecked)
                {
                    p.tipoFuncionario = TipoFuncionario.DeCarrera;

                }
                else if ((bool)rbPracticas.IsChecked)
                {
                    p.tipoFuncionario = TipoFuncionario.EnPracticas;

                }
                p.AnyoIngresoCuerpo = Int32.Parse(tbIngreso.Text);
                p.DestinoDefinitivo = (bool)destino.IsChecked;
                p.nombreImagen = tbNombre.Text + ".png";
                p.tipoMedico = seguroMedico.SelectedIndex == 0 ? EmpleadoPublico.TipoMedico.SS : EmpleadoPublico.TipoMedico.MUFACE;
                p.Nombre = tbNombre.Text;
                p.Id = GenerarEmail(p.Nombre, p.apellidos);
                p.Materia = "Sin Materia";
                using (Contexto context = new Contexto())
                {
                    context.ProfesoresFuncionarios.Add(p);
                    context.SaveChanges();
                }

                listaProfesores.Add(p);
            }

        }

        public void actualizarUsuario()
        {
           ProfesorFuncionario p = listaProfesores[indiceActualProfesor];

            using (Contexto context = new Contexto())
            {

                if ((bool)rbCarrera.IsChecked)
                {
                    p.tipoFuncionario = TipoFuncionario.DeCarrera;

                }
                else if ((bool)rbPracticas.IsChecked)
                {
                    p.tipoFuncionario = TipoFuncionario.EnPracticas;

                }
                p.AnyoIngresoCuerpo = Int32.Parse(tbIngreso.Text);
                p.DestinoDefinitivo = (bool)destino.IsChecked;
                p.nombreImagen = tbNombre.Text + ".png";
                p.tipoMedico = seguroMedico.SelectedIndex == 0 ? EmpleadoPublico.TipoMedico.SS : EmpleadoPublico.TipoMedico.MUFACE;
                p.Nombre = tbNombre.Text;
                p.Id = GenerarEmail(p.Nombre, p.apellidos);
                p.Materia = "Sin Materia";

                context.ProfesoresFuncionarios.Update(p);
                context.SaveChanges();
                }

        }


            private void btnGuardar_Click(object sender, RoutedEventArgs e)
            {
                if (anadirOActualizar)
                {
                    guardarUsuarioNuevo();
                    borrarCampos();

            }
            else {
                    actualizarUsuario();

            }
            btnGuardarUsuario.IsEnabled = false;
        }

    }
}
