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
    public class DevolucionesBLL
    {
        public static bool Guardar(Devoluciones devoluciones)
        {
            if (!Existe(devoluciones.DevolucionId))
                return Insertar(devoluciones);
            else
                return Modificar(devoluciones);
        }
        private static bool Insertar(Devoluciones devoluciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                foreach (var item in devoluciones.devolucionDetalles)
                {
                    var book = contexto.Libros.Find(item.LibroId);
                    if (book != null)
                    {
                        book.Disponibilidad = true;
                    }

                }
                contexto.Devoluciones.Add(devoluciones);
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
        public static bool Modificar(Devoluciones devoluciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(devoluciones.DevolucionId);
            try
            {

                foreach (var item in anterior.devolucionDetalles)
                {
                    var aux = contexto.Libros.Find(item.LibroId);
                    if (!devoluciones.devolucionDetalles.Exists(d => d.DevolucionId == item.DevolucionId))
                    {
                        var libro = LibroBLL.Buscar(item.LibroId);
                        libro.Disponibilidad = true;
                        LibroBLL.Modificar(libro);
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in devoluciones.devolucionDetalles)
                {

                    var aux = contexto.Libros.Find(item.LibroId);
                    if (item.DevolucionId == 0)
                    {
                        var libro = LibroBLL.Buscar(item.LibroId);
                        libro.Disponibilidad = false;
                        LibroBLL.Modificar(libro);

                    }
                    else

                        contexto.Entry(item).State = EntityState.Modified;

                }
                contexto.Entry(devoluciones).State = EntityState.Modified;
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
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Devoluciones devoluciones= DevolucionesBLL.Buscar(id);



                foreach (var item in devoluciones.devolucionDetalles) //Afecta el inventario
                {
                    var libro = LibroBLL.Buscar(item.LibroId);
                    libro.Disponibilidad = false;
                    LibroBLL.Modificar(libro);
                }

                contexto.Devoluciones.Remove(devoluciones);
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

        public static Devoluciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Devoluciones devoluciones;

            try
            {
                devoluciones = contexto.Devoluciones.Where(e => e.DevolucionId == id).Include(e => e.devolucionDetalles).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return devoluciones;
        }


        public static List<Devoluciones> GetList(Expression<Func<Devoluciones, bool>> criterio)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Devoluciones.Where(criterio).ToList();
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
                encontrado = contexto.Devoluciones.Any(e => e.DevolucionId == id);
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

        public static List<Devoluciones> GetDevoluciones()
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Devoluciones.ToList();
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
