using LibraryServicesWeb_AP2.DAL;
using LibraryServicesWeb_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryServicesWeb_AP2.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamo prestamo)
        {

            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        private static bool Insertar(Prestamo prestamo)
        {
            Libro libro = new Libro();
            bool paso = false;
            Contexto contexto = new Contexto();
           
            try
            {

                foreach (var item in prestamo.PrestamosDetalles)
                {
                    var book = contexto.Libros.Find(item.LibroId);
                    if (book != null)
                    {
                        book.Disponibilidad = false;
                    }
                    
                }
                contexto.Prestamos.Add(prestamo);
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
        public static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(prestamo.PrestamoId);
            try
            {
                foreach (var item in anterior.PrestamosDetalles)
                {
                    if (!prestamo.PrestamosDetalles.Exists(o => o.DetalleId == item.DetalleId))
                    {
                        var libro = LibroBLL.Buscar(item.LibroId);
                        libro.Disponibilidad=true;
                        LibroBLL.Modificar(libro);
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in prestamo.PrestamosDetalles)
                {
                    if (item.DetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        var book = LibroBLL.Buscar(item.LibroId);
                        book.Disponibilidad=false;
                        LibroBLL.Modificar(book);
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                        var libro = LibroBLL.Buscar(item.LibroId);
                        libro.Disponibilidad=false;
                        LibroBLL.Modificar(libro);

                    }
                }

                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);


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
             Contexto contexto = new Contexto();
            bool paso = false;
            
            try
            {
                Prestamo prestamo = PrestamosBLL.Buscar(id);

                 
               
                foreach (var item in prestamo.PrestamosDetalles) //Afecta el inventario
                {
                    var libro = LibroBLL.Buscar(item.LibroId);
                    libro.Disponibilidad = true;
                   LibroBLL.Modificar(libro);
                }

                contexto.Prestamos.Remove(prestamo);
                paso = (contexto.SaveChanges() > 0);
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

        public static Prestamo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamo prestamo;

            try
            {
                prestamo = contexto.Prestamos.Where(e => e.PrestamoId == id).Include(e => e.PrestamosDetalles).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> criterio)
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
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
                encontrado = contexto.Prestamos.Any(e => e.PrestamoId == id);
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

        public static List<Prestamo> GetPrestamo()
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.ToList();
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
