using LibraryServicesWeb_AP2.DAL;
using LibraryServicesWeb_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.BLL
{
    public class LibroBLL
    {
        public static bool Guardar(Libro libro)
        {
            if (!Existe(libro.LibroId))
                return Insertar(libro);
            else
                return Modificar(libro);
        }
        private static bool Insertar(Libro libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Libros.Add(libro);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Libro libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(libro).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var libro = contexto.Libros.Find(id);

                if (libro != null)
                {
                    contexto.Libros.Remove(libro);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Libro Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Libro libro;

            try
            {
                libro = contexto.Libros.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return libro;
        }

        public static List<Libro> GetList(Expression<Func<Libro, bool>> criterio)
        {
            List<Libro> lista = new List<Libro>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Libros.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Libros.Any(e => e.LibroId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Libro> GetLibros()
        {
            List<Libro> lista = new List<Libro>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Libros.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
