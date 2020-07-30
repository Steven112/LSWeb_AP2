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
                    contexto.Prestamos.Add(prestamo);
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
        public static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(prestamo.PrestamoId);
            try
            {

                foreach (var item in anterior.PrestamosDetalles)
                {
                    var aux = contexto.Libros.Find(item.LibroId);
                    if (!prestamo.PrestamosDetalles.Exists(d => d.PrestamoId== item.PrestamoId))
                    {
                        if (aux != null)
                        {
                            aux.Disponibilidad = true;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in prestamo.PrestamosDetalles)
                {

                    var aux = contexto.Libros.Find(item.LibroId);
                    if (item.PrestamoId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (aux != null)
                        {
                            aux.Disponibilidad = false;
                        }

                    }
                    else

                        contexto.Entry(item).State = EntityState.Modified;

                }
                contexto.Entry(prestamo).State = EntityState.Modified;
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
            Prestamo prestamo = new Prestamo();
            try
            {
                var envio = contexto.Prestamos.Find(id);

                if (envio != null)
                {

                    foreach (var item in prestamo.PrestamosDetalles)
                    {
                        var aux = contexto.Libros.Find(item.LibroId);
                        if (!prestamo.PrestamosDetalles.Exists(d => d.PrestamoId == item.PrestamoId))
                        {
                            if (aux != null)
                            {
                                aux.Disponibilidad = true;
                            }
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    contexto.Prestamos.Remove(envio);
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
