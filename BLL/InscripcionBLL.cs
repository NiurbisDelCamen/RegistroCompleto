using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Registro.BLL
{
   public class InscripcionBLL
    {
        public static bool Guardar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Inscripciones.Add(inscripcion) != null)
                    paso = db.SaveChanges() > 0 && AfectarBalance(inscripcion);
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

        //Modificar
        public static bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if(inscripcion.Deposito >0)
                {
                    db.Entry(inscripcion).State = EntityState.Modified;
                    paso = db.SaveChanges() > 0 && AfectarBalanceModificado(inscripcion);
                }
                else
                {
                    db.Entry(inscripcion).State = EntityState.Modified;
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

        public static bool AfectarBalance(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db= new Contexto();

            try
            {
                db.Personas.Find(inscripcion.PersonaId).Balance += inscripcion.Balance;
                paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;

        }
         public static bool AfectarBalanceModificado(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Personas.Find(inscripcion.PersonaId).Balance += inscripcion.Deposito;
                paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }

        //Eliminar.
        public static bool Eliminar(int id, int PersonaId)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Inscripciones.Find(id).Balance = 0;
                db.Personas.Find(PersonaId).Balance = 0;
                paso = (db.SaveChanges() > 0);

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
        
        //Buscar
        public static Inscripciones Buscar(int id)
        {
            Contexto db = new Contexto();
            Inscripciones Inscripcion = new Inscripciones();

            try
            {
                Inscripcion = db.Inscripciones.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Inscripcion;
        }
        
        //GetList
        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> inscripcion)
        {
            List<Inscripciones> Lista = new List<Inscripciones>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Inscripciones.Where(inscripcion).ToList(); 
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

    }
}
