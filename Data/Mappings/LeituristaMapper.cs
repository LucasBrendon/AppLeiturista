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
    public class LeituristaMapper : IEntityTypeConfiguration<Leiturista>
    {
        public void Configure(EntityTypeBuilder<Leiturista> builder)
        {
            builder.ToTable("tbl_leituristas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Matricula)
                .IsRequired()
                .HasColumnName("matricula");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("ativo");

            builder.HasMany(lnq => lnq.Leituras)
                .WithOne(lnq => lnq.Leiturista)
                .HasForeignKey(lnq => lnq.LeituristaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
