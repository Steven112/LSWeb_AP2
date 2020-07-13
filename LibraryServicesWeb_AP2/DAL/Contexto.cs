using LibraryServicesWeb_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Devoluciones> Devoluciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\TeacherControl.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = 1,
                Descripcion = "Accion",


            });
            modelBuilder.Entity<Editorial>().HasData(new Editorial
            {
                EditorialId = 1,
                Nombre = "StevenLibrary",
                Dirrecion = "Calle Mella"


            });
            modelBuilder.Entity<Libro>().HasData(new Libro
            {
                LibroId = 1,
                NombreLibro = "Odisea",
                ISBN = "789653266",
                CategoriaId = 1,
                EditorialId = 1,
                Disponibilidad = true,
                FechaImpresion = DateTime.Now,


            });
        }
    }
}
