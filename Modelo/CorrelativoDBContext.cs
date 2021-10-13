using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CorrelativoDBContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public CorrelativoDBContext(DbContextOptions<CorrelativoDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajador>()
                .HasIndex(p => new { p.dni })
                .IsUnique(true);
        }

        public CorrelativoDBContext() { }
        public Microsoft.EntityFrameworkCore.DbSet<Trabajador> trabajador { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<TipoDocumento> tipoDocumento { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Correlativo> correlativo { get; set; }
    }
}
