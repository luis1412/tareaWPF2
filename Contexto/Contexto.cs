using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases2.Clases;
using ejercicio8DI.Clases;
using Microsoft.EntityFrameworkCore;

namespace ejercicio8DI.Contextos
{
     class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IGraficaIES;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public DbSet<ProfesorFuncionario> ProfesoresFuncionarios {set; get;}
        public DbSet<ProfesorExtendido> ProfesoresExtendidos {set; get;}
        


    }
}
