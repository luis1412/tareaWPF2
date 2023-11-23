using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases2.Clases;
using ejercicio8DI.Clases;
using Microsoft.EntityFrameworkCore;

namespace ejercicio8DI.Contexto
{
     class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IGraficaIES_Luis;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
        public DbSet<ProfesorFuncionario> ProfesoresFuncionarios {set; get;}
        public DbSet<ProfesorExtendido> ProfesoresExtendidos {set; get;}
        


    }
}
