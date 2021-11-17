using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UsuarioMapper : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tbl_usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("senha")
                .HasColumnType("varchar(32)");

            builder.Property(x => x.Cargo)
                .IsRequired()
                .HasColumnName("cargo")
                .HasColumnType("varchar(50)");
        }
    }
}
