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
            Console.WriteLine(persona.Balance);
            try
            {
                if (db.Personas.Add(persona) != null)
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
        public static bool GuardarBalance(int id, decimal balance)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Personas persona = new Personas();
            persona = db.Personas.Find(id);
            if(persona != null)
            {
                try
                {
                    persona.Balance += balance;
                    db.Entry(persona).State = EntityState.Modified;
                    paso = (db.SaveChanges() < 0);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
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
                var eliminar = db.Personas.Find(id);
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
                Persona = db.Personas.Find(id);
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
    }
}
