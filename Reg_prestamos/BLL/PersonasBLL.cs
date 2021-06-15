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
    public class PersonasBLL
    {
        public static bool Modificar(Persona personas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(personas).State = EntityState.Modified;
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

        public static bool insertar(Persona personas)
        {
            bool paso = false;
            Contexto db = new Contexto();
             
            try
            {
                db.Personas.Add(personas);
                paso = db.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }


        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = db.Personas.Any(p => p.PersonaID == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;
        }


        public static bool Guardar(Persona personas)
        {
            if (!Existe(personas.PersonaID))
                return insertar(personas);
            else
                return Modificar(personas);
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var registro = db.Personas.Find(id);
                if (registro != null)
                {
                    db.Personas.Remove(registro);
                    paso = db.SaveChanges() > 0;
                }
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

        public static Persona Buscar(int id)
        {
            Contexto db = new Contexto();
            Persona personas;

            try
            {
                personas = db.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return personas;
        }
        public static bool AumentarBalance(int personaId, decimal balancePrestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var persona = contexto.Personas.Find(personaId);
                if (persona != null)
                {
                    persona.Balance += balancePrestamo;
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

        public static bool DisminuirBalance(int personaId, decimal balancePrestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var persona = contexto.Personas.Find(personaId);
                if (persona != null)
                {
                    persona.Balance -= balancePrestamo;
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


        public static List<Persona> GetPersonas()
        {
            List<Persona> lista = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Personas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> criterio)
        {
            List<Persona> lista = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Personas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
