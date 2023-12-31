﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ejercicio8DI.Contextos;

#nullable disable

namespace ejercicio8DI.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Clases2.Clases.ProfesorFuncionario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AnyoIngresoCuerpo")
                        .HasColumnType("int");

                    b.Property<bool>("DestinoDefinitivo")
                        .HasColumnType("bit");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TipoProfesor")
                        .HasColumnType("bigint");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("nombreImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rutaFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("tipoFuncionario")
                        .HasColumnType("bigint");

                    b.Property<long>("tipoMedico")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ProfesoresFuncionarios");
                });

            modelBuilder.Entity("ejercicio8DI.Clases.ProfesorExtendido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ECivil")
                        .HasColumnType("int");

                    b.Property<int>("Estatura")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("profesorFuncionarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("profesorFuncionarioId")
                        .IsUnique();

                    b.ToTable("ProfesoresExtendidos");
                });

            modelBuilder.Entity("ejercicio8DI.Clases.ProfesorExtendido", b =>
                {
                    b.HasOne("Clases2.Clases.ProfesorFuncionario", "ProfesorFuncionario")
                        .WithOne("profesorExtendido")
                        .HasForeignKey("ejercicio8DI.Clases.ProfesorExtendido", "profesorFuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfesorFuncionario");
                });

            modelBuilder.Entity("Clases2.Clases.ProfesorFuncionario", b =>
                {
                    b.Navigation("profesorExtendido")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
