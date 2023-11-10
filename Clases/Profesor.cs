using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases2.Clases
{
    abstract class Profesor : Persona
    {
        public string Materia { get; set; }
        public TipoFuncionario TipoProfesor { get; set; }

        public Profesor(string nombre, string apellidos, int edad, string materia, string rutaFoto) : base(nombre, apellidos, edad, rutaFoto)
        {
            Materia = materia;
        }

        public Profesor(string nombre, string apellidos, int edad, string rutaFoto) : base(nombre, apellidos, edad, rutaFoto)
        {
        }

        public Profesor()
        {

        }

        public enum TipoFuncionario : uint
        {
            Interino = 1,
            EnPracticas = 2,
            DeCarrera = 3
        }

        public string ToStringProfesor()
        {
            return base.ToString() + "\t" + Materia.PadRight(15) + "\t";
        }

        public abstract override string ToString();
    }
}
