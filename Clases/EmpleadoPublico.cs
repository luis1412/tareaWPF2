using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases2.Clases
{
    internal interface EmpleadoPublico
    {

        public enum TipoMedico : uint
        {
            SS = 1,
            MUFACE = 2,
        }

        TipoMedico tipoMedico { get; set; }

        public (int , int , int ) TiempoServicio();
        public int getSexenios();
        public int getTrienios();

    }
}
