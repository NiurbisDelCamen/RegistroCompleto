using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Persona.Add(persona) != null)
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
        public static bool Modificar(Personas Persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(Persona).State = EntityState.Modified;
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
                var eliminar = db.Persona.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);

            }catch(Exception)
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
        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas Persona = new Personas();
            try
            {
                Persona = db.Persona.Find(id);
            }
            catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return Persona;

        }

        internal static Personas Buscar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
