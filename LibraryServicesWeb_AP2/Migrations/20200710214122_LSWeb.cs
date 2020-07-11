﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryServicesWeb_AP2.Migrations
{
    public partial class LSWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(maxLength: 40, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Devoluciones",
                columns: table => new
                {
                    DevolucionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Disponible = table.Column<bool>(nullable: false),
                    FechaDevueltaLibro = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devoluciones", x => x.DevolucionId);
                });

            migrationBuilder.CreateTable(
                name: "Editorials",
                columns: table => new
                {
                    EditorialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Dirrecion = table.Column<string>(maxLength: 40, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorials", x => x.EditorialId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(maxLength: 40, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 40, nullable: false),
                    Matricula = table.Column<string>(maxLength: 9, nullable: false),
                    Celular = table.Column<string>(maxLength: 11, nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    FechaInsercion = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    LibroId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreLibro = table.Column<string>(maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(maxLength: 10, nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    EditorialId = table.Column<int>(nullable: false),
                    FechaImpresion = table.Column<DateTime>(nullable: false),
                    Disponibilidad = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.LibroId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstudianteId = table.Column<int>(nullable: false),
                    LibroId = table.Column<int>(nullable: false),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(maxLength: 40, nullable: false),
                    Celular = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 40, nullable: false),
                    FechaInsercion = table.Column<DateTime>(nullable: false),
                    Nivel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "DevolucionDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DevolucionId = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false),
                    LibroId = table.Column<int>(nullable: false),
                    NombreLibro = table.Column<string>(maxLength: 40, nullable: false),
                    FechaDevolucionLibro = table.Column<DateTime>(nullable: false),
                    FechaDevueltaLibro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevolucionDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DevolucionDetalles_Devoluciones_DevolucionId",
                        column: x => x.DevolucionId,
                        principalTable: "Devoluciones",
                        principalColumn: "DevolucionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevolucionDetalles_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevolucionDetalles_DevolucionId",
                table: "DevolucionDetalles",
                column: "DevolucionId");

            migrationBuilder.CreateIndex(
                name: "IX_DevolucionDetalles_PrestamoId",
                table: "DevolucionDetalles",
                column: "PrestamoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "DevolucionDetalles");

            migrationBuilder.DropTable(
                name: "Editorials");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Devoluciones");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
