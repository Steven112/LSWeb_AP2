﻿// <auto-generated />
using System;
using LibraryServicesWeb_AP2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryServicesWeb_AP2.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descripcion = "Accion"
                        });
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.DevolucionDetalles", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DevolucionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDevueltaLibro")
                        .HasColumnType("TEXT");

                    b.Property<int>("LibroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreLibro")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.HasKey("DetalleId");

                    b.HasIndex("DevolucionId");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("LibroId");

                    b.ToTable("DevolucionDetalles");
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Devoluciones", b =>
                {
                    b.Property<int>("DevolucionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDevueltaLibro")
                        .HasColumnType("TEXT");

                    b.HasKey("DevolucionId");

                    b.ToTable("Devoluciones");
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Editorial", b =>
                {
                    b.Property<int>("EditorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dirrecion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.HasKey("EditorialId");

                    b.ToTable("Editorials");

                    b.HasData(
                        new
                        {
                            EditorialId = 1,
                            Dirrecion = "Calle Mella",
                            Nombre = "StevenLibrary"
                        });
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Estudiante", b =>
                {
                    b.Property<int>("EstudianteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<DateTime>("FechaInsercion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(9);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.HasKey("EstudianteId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Libro", b =>
                {
                    b.Property<int>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EditorialId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaImpresion")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("NombreLibro")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("LibroId");

                    b.ToTable("Libros");

                    b.HasData(
                        new
                        {
                            LibroId = 1,
                            CategoriaId = 1,
                            Disponibilidad = true,
                            EditorialId = 1,
                            FechaImpresion = new DateTime(2020, 8, 3, 18, 44, 33, 101, DateTimeKind.Local).AddTicks(2351),
                            ISBN = "789653266",
                            NombreLibro = "Odisea"
                        });
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.PrestamosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("TEXT");

                    b.Property<int>("LibroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TituloLibro")
                        .HasColumnType("TEXT");

                    b.HasKey("DetalleId");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("LibroId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("PrestamosDetalle");
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<DateTime>("FechaInsercion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Celular = "8499866985",
                            Contraseña = "admin",
                            Email = "Enel@gmail.com",
                            FechaInsercion = new DateTime(2020, 8, 3, 18, 44, 33, 102, DateTimeKind.Local).AddTicks(8038),
                            Nivel = "Administrador",
                            NombreUsuario = "admin",
                            Nombres = "Enel Almonte"
                        },
                        new
                        {
                            UsuarioId = 2,
                            Celular = "8499866985",
                            Contraseña = "Natael123",
                            Email = "stivennunez@gmail.com",
                            FechaInsercion = new DateTime(2020, 8, 3, 18, 44, 33, 102, DateTimeKind.Local).AddTicks(8929),
                            Nivel = "Administrador",
                            NombreUsuario = "StevenN",
                            Nombres = "Steven Nunez"
                        });
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.DevolucionDetalles", b =>
                {
                    b.HasOne("LibraryServicesWeb_AP2.Models.Devoluciones", null)
                        .WithMany("devolucionDetalles")
                        .HasForeignKey("DevolucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryServicesWeb_AP2.Models.Estudiante", "estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryServicesWeb_AP2.Models.Libro", "libro")
                        .WithMany()
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryServicesWeb_AP2.Models.PrestamosDetalle", b =>
                {
                    b.HasOne("LibraryServicesWeb_AP2.Models.Estudiante", "estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryServicesWeb_AP2.Models.Libro", "libro")
                        .WithMany()
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryServicesWeb_AP2.Models.Prestamo", null)
                        .WithMany("PrestamosDetalles")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
