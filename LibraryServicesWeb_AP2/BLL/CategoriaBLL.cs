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
    public class CategoriaBLL
    {
        public static bool Guardar(Categoria cagoria)
        {
            if (!Existe(cagoria.CategoriaId))
                return Insertar(cagoria);
            else
                return Modificar(cagoria);
        }
        private static bool Insertar(Categoria categoria)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Categorias.Add(categoria);
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
        public static bool Modificar(Categoria categoria)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(categoria).State = EntityState.Modified;
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
                var persona = contexto.Categorias.Find(id);

                if (persona != null)
                {
                    contexto.Categorias.Remove(persona);
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

        public static Categoria Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categoria categoria;

            try
            {
                categoria = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return categoria;
        }

        public static List<Categoria> GetList(Expression<Func<Categoria, bool>> criterio)
        {
            List<Categoria> lista = new List<Categoria>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Categorias.Where(criterio).ToList();
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
                encontrado = contexto.Categorias.Any(e => e.CategoriaId == id);
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

        public static List<Categoria> GetCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Categorias.ToList();
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
