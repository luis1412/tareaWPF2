using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases2.Clases
{
    internal class ProfesorFuncionario : Profesor, EmpleadoPublico
    {
        public int AnyoIngresoCuerpo;
        public bool DestinoDefinitivo;
        public EmpleadoPublico.TipoMedico tipoMedico { get; set; }
        public Profesor.TipoFuncionario tipoFuncionario { get; set; }
        public string nombreImagen;
        public ProfesorFuncionario() { 
        
        }

        public ProfesorFuncionario(string textoSplit)
        {
            string[] texto = textoSplit.Split(';');
            base.Nombre = texto[0];
            base.apellidos = texto[1];
            base.edad = Int32.Parse(texto[2]);
            base.email = texto[3];
            base.Materia = texto[4];
            base.TipoProfesor = (TipoFuncionario)Enum.Parse(typeof(TipoFuncionario), texto[5]);
            AnyoIngresoCuerpo = Int32.Parse(texto[6]);
            DestinoDefinitivo = (texto[7].Equals("true")?true:false);
            tipoMedico = (EmpleadoPublico.TipoMedico) Enum.Parse(typeof(EmpleadoPublico.TipoMedico), texto[8]);
            nombreImagen = texto[9];
        }
        public ProfesorFuncionario(string nombre, string apellidos, int edad, string materia, int anyoIngresoCuerpo, bool destinoDefinitivo) : base(nombre, apellidos, edad, materia)
        {

            this.AnyoIngresoCuerpo = anyoIngresoCuerpo;
           this.DestinoDefinitivo = destinoDefinitivo;
        }  
        
        public ProfesorFuncionario(string nombre, string apellidos, int edad, string materia, int anyoIngresoCuerpo, bool destinoDefinitivo, TipoFuncionario tipoProfesor, EmpleadoPublico.TipoMedico tipoMedico  ) : base(nombre, apellidos, edad, materia)
        {

            this.AnyoIngresoCuerpo = anyoIngresoCuerpo;
           this.DestinoDefinitivo = destinoDefinitivo;
            this.tipoMedico = tipoMedico;
            this.tipoFuncionario = tipoProfesor;
        }


        public static string cambiarBoolPorSi(bool DestinoDefinitivo) {

            if (DestinoDefinitivo)
            {
                return "Si";
            }
            else {
                return "No";
            
            }
        }

        public override string ToString()
        {
            return base.ToStringProfesor() + "\t" + tipoFuncionario.ToString() + "\t" + AnyoIngresoCuerpo + "\t"+ cambiarBoolPorSi(DestinoDefinitivo) + "\t" +  tipoMedico.ToString();
        }




        public (int , int , int ) TiempoServicio()
        {
            DateTime fechaIngreso = new DateTime(AnyoIngresoCuerpo, 9, 1);
            DateTime fechaActual = DateTime.Now;
            TimeSpan diferencia = fechaActual - fechaIngreso;
            int anos = diferencia.Days / 365;
            int meses = (diferencia.Days % 365) / 30;
            int dias = (diferencia.Days % 365) % 30;

            return (anos, meses, dias);
        }
        public int getSexenios()
        {
           int anos =  TiempoServicio().Item1;
            return anos / 6;
        }

        public int getTrienios()
        {
            int anos = TiempoServicio().Item1;
            return anos / 3;
        }






    }
}
