using Clases2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace ejercicio8DI.Clases
{



    class Auxiliar
    {
        private static List<ProfesorExtendido> profesoresExtendidos = ProfesorExtendido.GetProfesE();

        public static void mayores35(List<ProfesorFuncionario> profesorFuncionarios)
        {

            var mayores = profesorFuncionarios.Select(e => new { Nombre = e.Nombre, Apellido = e.apellidos, e.edad, e.Materia }).Where(e => e.edad > 35);
            mostrarDatos("Mayores 35", mayores);

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

            mostrarDatos("filtrarAnoDeIngreso", consulta);
        }
        public static void estaturaSuperio160(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = profesorFuncionarios.Join(profesoresExtendidos, (pf => pf.email), (pe => pe.Email), (pf, pe) => new
            {
                pf.Nombre,
                pf.apellidos,
                pf.edad,
                pe.Estatura,
                pe.Peso
            }).Where(pf => pf.Estatura > 160).OrderBy(pe => pe.Estatura).OrderByDescending(pe => pe.Peso);

            mostrarDatos("estaturaSuperio160", consulta);
        }
        public static void agrupar1(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = profesoresExtendidos.Join(profesorFuncionarios, pe => pe.Email, pf => pf.email, (pe, pf) => new { pe, pf })
                                                .GroupBy(final => final.pe.ECivil)
                                                .Select(a => new
                                                {
                                                    Nombre = a.Key,
                                                    Elementos = a.ToList()
                                                });
            string final = "";
            foreach (var grupo in consulta)
            {
               final += ($"Estado Civil: {grupo.Nombre}\n");

                foreach (var elemento in grupo.Elementos)
                {
                    final += ($" Nombre: {elemento.pf.Nombre} \n Email: {elemento.pe.Email} \n Edad: {elemento.pf.edad}\n Peso: {elemento.pe.Peso} \n Estatura: {elemento.pe.Estatura} \n");
                }
                final += "\n";
            }

            MessageBox.Show(final, "Agrupacion 1", MessageBoxButton.OK, MessageBoxImage.Information);

        }    
        
        public static void agrupar2(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = profesoresExtendidos.Join(profesorFuncionarios, pe => pe.Email, pf => pf.email, (pe, pf) => new { pe, pf })
                                                .GroupBy(final => final.pe.ECivil)
                                                .Select(a => new
                                                {
                                                   Valor = a.Key,
                                                   cantidad = a.Count()
                                                });
                                                
            string final = "";
            foreach (var grupo in consulta)
            {
               final += ($"Estado Civil: {grupo.Valor}\n Cantidad: {grupo.cantidad}");

                
                final += "\n";
            }

            MessageBox.Show(final, "Agrupacion 2", MessageBoxButton.OK, MessageBoxImage.Information);

        }   
        
        public static void agrupar3(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = from pf in profesorFuncionarios
                           orderby pf.edad
                           group new { Nombre = pf.Nombre, Apellidos = pf.apellidos, Email = pf.email } by pf.edad into personasAgrupadas
                           select new
                           {
                               Key = personasAgrupadas.Key,
                               Valores = personasAgrupadas
                           };

            string final = "";
            foreach (var grupo in consulta)
            {
                final += ($"Edad: {grupo.Key}\n");

                foreach (var elemento in grupo.Valores)
                {
                    final += ($" Nombre: {elemento.Nombre} \n Email: {elemento.Apellidos} \n Edad: {elemento.Email}\n ");
                }
                final += "\n";
            }

            MessageBox.Show(final, "Agrupacion 1", MessageBoxButton.OK, MessageBoxImage.Information);
        }  
        
        public static void agrupar4(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = from pf in profesorFuncionarios join pe in profesoresExtendidos on pf.email equals pe.Email
                           where pf.edad >= 40
                           orderby pe.Peso
                           orderby pf.apellidos
                           group new { Nombre = pf.Nombre, Apellidos = pf.apellidos, Seguro = pf.tipoMedico, Peso = pe.Peso } by pf.tipoMedico into personasAgrupadas
                           select new
                           {
                               Key = personasAgrupadas.Key,
                               Valores = personasAgrupadas
                           };

            string final = "";
            foreach (var grupo in consulta)
            {
                final += ($"Seguro Medico: {grupo.Key}\n");

                foreach (var elemento in grupo.Valores)
                {
                    final += ($" Nombre: {elemento.Nombre} \n Email: {elemento.Apellidos} \n Seguro: {elemento.Seguro}\n Peso: {elemento.Peso}");
                }
                final += "\n";
            }

            MessageBox.Show(final, "Agrupacion 1", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void filtrarAnoDeIngresoEstadoCivil(List<ProfesorFuncionario> profesorFuncionarios)
        {
            var consulta = profesorFuncionarios.Join(profesoresExtendidos, (pf => pf.email), (pe => pe.Email), ((pf, pe) => new
            {
                pf.Nombre,
                pf.apellidos,
                Año = pf.AnyoIngresoCuerpo,
                Estado = pe.ECivil.ToString()
            })).Where(pf => pf.Año > 2010).Where(pe => pe.Estado.Equals(ProfesorExtendido.EstadoCivil.Casado.ToString()));

            mostrarDatos("Filtrar Año de ingreso", consulta);
        }



        public static void mostrarDatos<T>(string cadena, IEnumerable<T> consulta)
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


            MessageBox.Show(finalTexto, cadena, MessageBoxButton.OK, MessageBoxImage.Information);


        }

    }
}
