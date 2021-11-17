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
    public class OcorrenciaMapper : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("tbl_ocorrencias");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("varchar(80)");

            builder.Property(x => x.PermiteLeitura)
                .IsRequired()
                .HasColumnName("permite_leitura");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("valor")
                .HasColumnType("decimal(10,2)");

            builder.HasMany(lnq => lnq.Leituras)
                .WithOne(lnq => lnq.Ocorrencia)
                .HasForeignKey(lnq => lnq.OcorrenciaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
