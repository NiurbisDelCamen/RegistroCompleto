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

            if(inscripcion.Balance >0)
            {
                PersonasBLL.GuardarBalance(inscripcion.InscripcionId, (-1 * inscripcion.Deposito));
                inscripcion.Balance -= inscripcion.Deposito;
            }
            else
            {
                PersonasBLL.GuardarBalance(inscripcion.InscripcionId, (inscripcion.Monto - inscripcion.Deposito));
                inscripcion.Balance = (inscripcion.Monto - inscripcion.Deposito);
            }
            try
            {
                if (db.Inscripciones.Add(inscripcion) != null)
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

        //Modificar
        public static bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(inscripcion).State = EntityState.Modified;
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

        //Eliminar.
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Inscripciones.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

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
