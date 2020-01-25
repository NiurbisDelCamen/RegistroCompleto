using Microsoft.EntityFrameworkCore;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Personas> Persona { get; set; }
        public object Personas { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\DESKTOP - HMJOQ71\USER; Database = TestDb; Trusted_Connection = True");
        }

    }
}
