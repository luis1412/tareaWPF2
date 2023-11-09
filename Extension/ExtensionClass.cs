using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Clases2.Clases;

namespace Clases2.Metodos
{
    internal static class ExtensionClass
    {

        public static int WordCount(this String cadena)
        {
            string[] palabras = cadena.Trim().Split(' ');

            return palabras.Length;
        }

        public static string FirstLetterToUpper(this String cadena)
        {
            string final = "";
            char[] arrayCadenas = cadena.ToCharArray();
            arrayCadenas[0] = Char.ToUpper(arrayCadenas[0]);
            foreach (char c in arrayCadenas)
            {
                final += c;
            }
            return final;
        }

        public static bool SeekRemove(this List<Persona> lista, Persona persona)
        {
            int indice = -1;

            for (int i = 0; i < lista.Count; i++)
            {
                if (persona.Equals(lista[i]))
                {
                    indice = i;
                }
            }

            if (indice == -1)
            {
                return false;
            }
            else
            {
                lista.RemoveAt(indice);
                return true;
            }
        }

        public static int encontrarPersona(this List<Persona> lista, Persona persona)
        {
            int indice = -1;
            Persona personaEncontrada = lista.Find(p => p.Nombre == persona.Nombre && p.apellidos == persona.apellidos && p.apellidos == persona.apellidos);
            if (personaEncontrada != null)
            {
                indice = lista.IndexOf(personaEncontrada);
            }
            else {
                Console.WriteLine("Persona no encontrada");
            }

            return indice;
        }
    }
}
