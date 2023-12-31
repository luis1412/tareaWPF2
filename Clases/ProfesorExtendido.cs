﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases2.Clases;

namespace ejercicio8DI.Clases
{
   public class ProfesorExtendido
    {
        public int Id { get; set; }

       public string profesorFuncionarioId { get; set; }

        public ProfesorFuncionario ProfesorFuncionario { get; set; }


        public enum EstadoCivil
        {
            Soltero,
            Casado,
            Divorciado,
            Viudo
        }

        // Clase ProfesorExtendido
        /*
        public ProfesorExtendido(EstadoCivil estadoCivil, string email, int peso, int estatura)
        {
            ECivil = estadoCivil;
            Email = email;
            Peso = peso;
            Estatura = estatura;
        }

        public ProfesorExtendido() { }
        */
        public EstadoCivil ECivil { get; set; }
        public int Peso { get; set; }
        public int Estatura { get; set; }


        



        public static List<ProfesorExtendido> GetProfesE()
        {
            List<ProfesorExtendido> listaProfesores = new List<ProfesorExtendido>();

            listaProfesores.Add(new ProfesorExtendido() {
                ECivil = EstadoCivil.Soltero,
                profesorFuncionarioId = "lhercru721@g.educaand.es",
                Estatura = 185,
                Peso = 65,
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Soltero,
                profesorFuncionarioId = "sdomnic@g.educaand.es",
                Estatura = 170,
                Peso = 70
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Casado,
                profesorFuncionarioId = "mgarcia123@g.educaand.es",
                Estatura = 175,
                Peso = 68
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Viudo,
                profesorFuncionarioId = "cmartinez@g.educaand.es",
                Estatura = 180,
                Peso = 75
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Soltero,
                profesorFuncionarioId = "lperez@g.educaand.es",
                Estatura = 170,
                Peso = 60
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Casado,
                profesorFuncionarioId = "jrodriguez@g.educaand.es",
                Estatura = 175,
                Peso = 72
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Divorciado,
                profesorFuncionarioId = "asanchez@g.educaand.es",
                Estatura = 160,
                Peso = 65
            });

            listaProfesores.Add(new ProfesorExtendido()
            {
                ECivil = EstadoCivil.Viudo,
                profesorFuncionarioId = "plopez@g.educaand.es",
                Estatura = 190,
                Peso = 80
            });

            return listaProfesores;
        }

    }
}
