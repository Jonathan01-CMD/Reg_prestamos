using Microsoft.EntityFrameworkCore;
using Reg_prestamos.DAL;
using Reg_prestamos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Reg_prestamos.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PersonasID))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(e => e.PrestamoID == id);
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

        private static bool Insertar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(prestamos);
                paso = contexto.SaveChanges() > 0;
                AfectarBalance(prestamos);
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

        private static bool Modificar(Prestamos prestamos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(prestamos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
                AfectarBalance(prestamos);
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
                var prestamos = contexto.Prestamos.Find(id);

                if (prestamos != null)
                {
                    contexto.Prestamos.Remove(prestamos);//remueve la entidad
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
        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }
        private static bool AfectarBalance(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;

                db.Personas.Find(prestamo.PersonasID).Balance = prestamo.Balance;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
        public static List<Prestamos> GetPersonas()
        {
            List<Prestamos> lista = new List<Prestamos>();
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

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
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
    }
}
