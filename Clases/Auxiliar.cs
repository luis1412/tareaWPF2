using Clases2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ejercicio8DI.Clases
{



    class Auxiliar
    {
        private static List<ProfesorExtendido> profesoresExtendidos = ProfesorExtendido.GetProfesE();

        public static void mayores35(List<ProfesorFuncionario> profesorFuncionarios)
        {

            var mayores = profesorFuncionarios.Select(e => new { Nombre = e.Nombre, Apellido = e.apellidos, e.edad, e.Materia }).Where(e => e.edad > 35);
            mostrarDatos(mayores);

        }
        public static void filtrarAnoDeIngreso(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = profesorFuncionarios.Select(e => new
            {
                e.Nombre,
                e.apellidos,
                e.edad,
                e.Materia,
                e.AnyoIngresoCuerpo,
                TipoFuncionario = e.tipoFuncionario.ToString(),
                TipoMedico = e.tipoMedico.ToString(),
                DestinoDefinitivo = e.DestinoDefinitivo ? "Si" : "No",
                e.rutaFoto
            }).Where(e => e.AnyoIngresoCuerpo > 2010);

            mostrarDatos(consulta);
        }

        public static void filtrarAnoDeIngresoEstadoCivil(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = profesorFuncionarios.Join(profesoresExtendidos, (pf => pf.email), (pe => pe.Email), ((pf, pe) => new
            {
                pf.Nombre,
                pf.apellidos,
               Año = pf.AnyoIngresoCuerpo,
                Estado = pe.ECivil.ToString()
            })).Where(pf => pf.Año > 2010).Where(pe => pe.Estado.Equals("Casado"));

            mostrarDatos(consulta);
        }



        public static void mostrarDatos<T>(IEnumerable<T> consulta)
        {

            System.Reflection.PropertyInfo[] listaPropiedades = typeof(T).GetProperties();
            string finalTexto = "";
            foreach (var item in consulta)
            {
                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    finalTexto += ($"{propiedad.Name}: {propiedad.GetValue(item)} \n");
                }
                finalTexto += "\n";
            }


            MessageBox.Show(finalTexto, "Anyo Ingreso mayor a 2010", MessageBoxButton.OK, MessageBoxImage.Information);


        }


    }
}
