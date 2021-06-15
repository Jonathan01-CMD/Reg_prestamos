using Microsoft.EntityFrameworkCore;
using Reg_prestamos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public DbSet<Prestamos> Prestamos { get; set; }

        public DbSet<Moras> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/DatosPersonas.db");
        }








    }
}
