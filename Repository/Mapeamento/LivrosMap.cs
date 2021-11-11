using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Mapeamento
{
    public class LivrosMap : IEntityTypeConfiguration<Livros>
    {
        public void Configure(EntityTypeBuilder<Livros> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.titulo).IsRequired().HasMaxLength(200);
            builder.Property(x => x.isbn).IsRequired();
            builder.Property(x => x.ano).IsRequired();
            builder.Property(x => x.autorId);

            // RELACIONAMENTO BI-DIRECIONAL
            builder.HasOne<Autores>(x => x.Autores);

        }
    }
}
