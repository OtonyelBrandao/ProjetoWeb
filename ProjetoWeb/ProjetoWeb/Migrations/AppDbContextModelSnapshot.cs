﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoWeb.Data;

namespace ProjetoWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoWeb.Models.Especialidades", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<string>("NomeDaEspecialidade");

                    b.HasKey("ID");

                    b.ToTable("especialidades");
                });

            modelBuilder.Entity("ProjetoWeb.Models.Profissionais", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EspecialidadesID");

                    b.Property<int>("IDEspecialidades");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.Property<string>("WhatsApp")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("EspecialidadesID");

                    b.ToTable("profissionais");
                });

            modelBuilder.Entity("ProjetoWeb.Models.Profissionais", b =>
                {
                    b.HasOne("ProjetoWeb.Models.Especialidades", "Especialidades")
                        .WithMany()
                        .HasForeignKey("EspecialidadesID");
                });
#pragma warning restore 612, 618
        }
    }
}
