using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Mapeamento
{
    public class AutoresMap : IEntityTypeConfiguration<Autores>
    {
        public void Configure(EntityTypeBuilder<Autores> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.nome).HasMaxLength(50);
            builder.Property(x => x.sobrenome).HasMaxLength(50);
            builder.Property(x => x.dataAniversario);
            builder.Property(x => x.Email).HasMaxLength(50);

            // RELACIONAMENTO BI-DIRECIONAL
            builder.HasMany<Livros>(x => x.Livros).WithOne(x => x.Autores);

        }
    }
}
