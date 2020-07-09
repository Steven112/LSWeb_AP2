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
    public class EditorialBLL
    {
        public static bool Guardar(Editorial editorial)
        {
            if (!Existe(editorial.EditorialId))
                return Insertar(editorial);
            else
                return Modificar(editorial);
        }
        private static bool Insertar(Editorial editorial)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Editorials.Add(editorial);
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
        public static bool Modificar(Editorial editorial)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(editorial).State = EntityState.Modified;
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
                var editorial = contexto.Editorials.Find(id);

                if (editorial != null)
                {
                    contexto.Editorials.Remove(editorial);
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

        public static Editorial Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Editorial editorial;

            try
            {
                editorial = contexto.Editorials.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return editorial;
        }

        public static List<Editorial> GetList(Expression<Func<Editorial, bool>> criterio)
        {
            List<Editorial> lista = new List<Editorial>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Editorials.Where(criterio).ToList();
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
                encontrado = contexto.Editorials.Any(e => e.EditorialId == id);
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

        public static List<Editorial> GetEditorial()
        {
            List<Editorial> lista = new List<Editorial>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Editorials.ToList();
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
