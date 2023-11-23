using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases2.Clases
{
    public class Persona
    {
        private string nombre;

        public string rutaFoto { get; set; }
        public string Nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public string Id { get; set; }

       
        public Persona() { }

        public Persona(string nombre, string apellidos, int edad, string rutaFoto)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.Id = GenerarEmail();
            this.rutaFoto = "profesores\\" + rutaFoto;
        }
       
        public virtual String GenerarEmail()
        {
            string[] apellidos = this.apellidos.Split(' ');
            string emailLocal="";
            if (apellidos.Length == 1)
            {
                emailLocal = apellidos[0].Substring(0, 2).ToLower() + apellidos[0].Substring(0, 2).ToLower() + nombre.Substring(0, 1).ToLower();
            }
            else
            {
                emailLocal = apellidos[0].Substring(0, 2).ToLower() + apellidos[1].Substring(0, 2).ToLower() + nombre.Substring(0, 1).ToLower();
            }
            return emailLocal + "@trass.com";
        }

        public override string ToString()
        {
            return $"{nombre.PadRight(5)} \t {apellidos.PadRight(5)} \t {Id.PadRight(15)} \t {edad}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Persona persona &&
                   nombre == persona.nombre &&
                   apellidos == persona.apellidos &&
                   edad == persona.edad;
        }


        public static bool operator >(Persona persona1, Persona persona2) {
            return persona1.edad > persona2.edad;
        }

        public static bool operator <(Persona persona1, Persona persona2)
        {
            return persona1.edad < persona2.edad;
        }


    }
}

