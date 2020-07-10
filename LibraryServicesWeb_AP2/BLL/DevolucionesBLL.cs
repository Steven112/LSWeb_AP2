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

            try
            {
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
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var devoluciones = contexto.Devoluciones.Find(id);

                if (devoluciones != null)
                {
                    contexto.Devoluciones.Remove(devoluciones);
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

        public static Devoluciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Devoluciones devoluciones;

            try
            {
                devoluciones = contexto.Devoluciones.Find(id);
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
