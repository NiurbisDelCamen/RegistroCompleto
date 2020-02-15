using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.BLL.Tests
{
    [TestClass()]
    public class InscripcionBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionId = 0;
            inscripcion.Fecha= DateTime.Now;
            inscripcion.PersonaId = 1;
            inscripcion.Monto = 500;
            inscripcion.Balance = 250;
            inscripcion.Deposito = 100;
            inscripcion.Comentarios = "Probando";
            paso = InscripcionBLL.Guardar(inscripcion);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionId = 1;
            inscripcion.Fecha = DateTime.Now;
            inscripcion.PersonaId = 1;
            inscripcion.Comentarios = "Probando";
            inscripcion.Monto = 0;
            inscripcion.Balance = 500;
            inscripcion.Deposito = 0;
            paso = InscripcionBLL.Modificar(inscripcion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = InscripcionBLL.Eliminar(2, 1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripcion;
            inscripcion = InscripcionBLL.Buscar(1);
            Assert.AreEqual(inscripcion, inscripcion);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Inscripciones>();
            listado = InscripcionBLL.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}