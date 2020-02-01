using Microsoft.EntityFrameworkCore;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =DESKTOP-HMJOQ71; Database = PersonasDB; Trusted_Connection = True;");
        }

    }
}
