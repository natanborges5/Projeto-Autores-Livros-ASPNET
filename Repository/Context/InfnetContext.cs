using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Mapeamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class InfnetContext : DbContext
    {
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        public static readonly ILoggerFactory _loggerFactory 
            = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public InfnetContext(DbContextOptions<InfnetContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoresMap());
            modelBuilder.ApplyConfiguration(new LivrosMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}
