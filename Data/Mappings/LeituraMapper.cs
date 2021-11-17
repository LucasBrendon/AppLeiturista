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
    public class LeituraMapper : IEntityTypeConfiguration<Leitura>
    {
        public void Configure(EntityTypeBuilder<Leitura> builder)
        {
            builder.ToTable("tbl_leituras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.CodigoCliente)
                .IsRequired()
                .HasColumnName("codigo_Cliente");

            builder.Property(x => x.LeituraAnterior)
                .IsRequired()
                .HasColumnName("leitura_anterior");

            builder.Property(x => x.LeituraAtual)
                .HasColumnName("leitura_atual");

            builder.Property(x => x.LeituristaId)
                .IsRequired()
                .HasColumnName("fk_leiturista");

            builder.Property(x => x.OcorrenciaId)
                .IsRequired()
                .HasColumnName("fk_ocorrencia");

            builder.Property(x => x.Latitude)
                .IsRequired()
                .HasColumnName("latitude")
                .HasColumnType("decimal(12)");

            builder.Property(x => x.Longitude)
                .IsRequired()
                .HasColumnName("longitude")
                .HasColumnType("decimal(13)");

            builder.Property(x => x.DataLeitura)
                .IsRequired()
                .HasColumnName("data_leitura")
                .HasColumnType("datetime(0)");
        }
    }
}
