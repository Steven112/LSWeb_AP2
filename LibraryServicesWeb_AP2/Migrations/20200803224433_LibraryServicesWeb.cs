﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryServicesWeb_AP2.Migrations
{
    public partial class LibraryServicesWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(maxLength: 40, nullable: false)
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
                    FechaDevueltaLibro = table.Column<DateTime>(nullable: false)
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
                    Dirrecion = table.Column<string>(maxLength: 40, nullable: false)
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
                    Celular = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    FechaInsercion = table.Column<DateTime>(nullable: false)
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
                    Disponibilidad = table.Column<bool>(nullable: false)
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
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: false)
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
                    NombreUsuario = table.Column<string>(maxLength: 25, nullable: false),
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
                    EstudianteId = table.Column<int>(nullable: false),
                    LibroId = table.Column<int>(nullable: false),
                    NombreLibro = table.Column<string>(maxLength: 40, nullable: false),
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
                        name: "FK_DevolucionDetalles_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevolucionDetalles_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrestamoId = table.Column<int>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    LibroId = table.Column<int>(nullable: false),
                    TituloLibro = table.Column<string>(nullable: true),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion" },
                values: new object[] { 1, "Accion" });

            migrationBuilder.InsertData(
                table: "Editorials",
                columns: new[] { "EditorialId", "Dirrecion", "Nombre" },
                values: new object[] { 1, "Calle Mella", "StevenLibrary" });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "LibroId", "CategoriaId", "Disponibilidad", "EditorialId", "FechaImpresion", "ISBN", "NombreLibro" },
                values: new object[] { 1, 1, true, 1, new DateTime(2020, 8, 3, 18, 44, 33, 101, DateTimeKind.Local).AddTicks(2351), "789653266", "Odisea" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Celular", "Contraseña", "Email", "FechaInsercion", "Nivel", "NombreUsuario", "Nombres" },
                values: new object[] { 1, "8499866985", "admin", "Enel@gmail.com", new DateTime(2020, 8, 3, 18, 44, 33, 102, DateTimeKind.Local).AddTicks(8038), "Administrador", "admin", "Enel Almonte" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Celular", "Contraseña", "Email", "FechaInsercion", "Nivel", "NombreUsuario", "Nombres" },
                values: new object[] { 2, "8499866985", "Natael123", "stivennunez@gmail.com", new DateTime(2020, 8, 3, 18, 44, 33, 102, DateTimeKind.Local).AddTicks(8929), "Administrador", "StevenN", "Steven Nunez" });

            migrationBuilder.CreateIndex(
                name: "IX_DevolucionDetalles_DevolucionId",
                table: "DevolucionDetalles",
                column: "DevolucionId");

            migrationBuilder.CreateIndex(
                name: "IX_DevolucionDetalles_EstudianteId",
                table: "DevolucionDetalles",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_DevolucionDetalles_LibroId",
                table: "DevolucionDetalles",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosDetalle_EstudianteId",
                table: "PrestamosDetalle",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosDetalle_LibroId",
                table: "PrestamosDetalle",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosDetalle_PrestamoId",
                table: "PrestamosDetalle",
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
                name: "PrestamosDetalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Devoluciones");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
