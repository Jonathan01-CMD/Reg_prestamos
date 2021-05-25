using Microsoft.EntityFrameworkCore;
using Reg_prestamos.DAL;
using Reg_prestamos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reg_prestamos.BLL
{
    public class PersonasBLL
    {
        public static bool Modificar(RegPersona registro)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(registro).State = EntityState.Modified;
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

        public static bool insertar(RegPersona registro)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
               
                db.RegPersona.Add(registro);
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
                encontrado = db.RegPersona.Any(p => p.RegistroId == id);
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


        public static bool Guardar(RegPersona registro)
        {
            if (!Existe(registro.RegistroId))
                return insertar(registro);
            else
                return Modificar(registro);
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var registro = db.RegPersona.Find(id);
                if (registro != null)
                {
                    db.RegPersona.Remove(registro);
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

        public static RegPersona Buscar(int id)
        {
            Contexto db = new Contexto();
            RegPersona registro;

            try
            {
                registro = db.Registros.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return registro;
        }
        public static List<RegPersona> GetPersonas()
        {
            List<RegPersona> lista = new List<RegPersona>();
            Contexto db = new Contexto();
            try
            {
                lista = db.RegPersona.ToList();
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

        public static List<RegPersona> GetList(Expression<Func<RegPersona, bool>> criterio)
        {
            List<RegPersona> lista = new List<RegPersona>();
            Contexto db = new Contexto();
            try
            {
                lista = db.RegPersona.Where(criterio).ToList();
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
