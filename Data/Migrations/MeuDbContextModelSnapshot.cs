// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    partial class MeuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Business.Models.Leitura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("CodigoCliente")
                        .HasColumnType("bigint")
                        .HasColumnName("codigo_Cliente");

                    b.Property<DateTime>("DataLeitura")
                        .HasColumnType("datetime(0)")
                        .HasColumnName("data_leitura");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("latitude");

                    b.Property<long>("LeituraAnterior")
                        .HasColumnType("bigint")
                        .HasColumnName("leitura_anterior");

                    b.Property<long?>("LeituraAtual")
                        .HasColumnType("bigint")
                        .HasColumnName("leitura_atual");

                    b.Property<long>("LeituristaId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_leiturista");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("longitude");

                    b.Property<long>("OcorrenciaId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_ocorrencia");

                    b.HasKey("Id");

                    b.HasIndex("LeituristaId");

                    b.HasIndex("OcorrenciaId");

                    b.ToTable("tbl_leituras");
                });

            modelBuilder.Entity("Business.Models.Leiturista", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ativo");

                    b.Property<long>("Matricula")
                        .HasColumnType("bigint")
                        .HasColumnName("matricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tbl_leituristas");
                });

            modelBuilder.Entity("Business.Models.Ocorrencia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("descricao");

                    b.Property<bool>("PermiteLeitura")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("permite_leitura");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("tbl_ocorrencias");
                });

            modelBuilder.Entity("Business.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cargo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("tbl_usuarios");
                });

            modelBuilder.Entity("Business.Models.Leitura", b =>
                {
                    b.HasOne("Business.Models.Leiturista", "Leiturista")
                        .WithMany("Leituras")
                        .HasForeignKey("LeituristaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Business.Models.Ocorrencia", "Ocorrencia")
                        .WithMany("Leituras")
                        .HasForeignKey("OcorrenciaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Leiturista");

                    b.Navigation("Ocorrencia");
                });

            modelBuilder.Entity("Business.Models.Leiturista", b =>
                {
                    b.Navigation("Leituras");
                });

            modelBuilder.Entity("Business.Models.Ocorrencia", b =>
                {
                    b.Navigation("Leituras");
                });
#pragma warning restore 612, 618
        }
    }
}
