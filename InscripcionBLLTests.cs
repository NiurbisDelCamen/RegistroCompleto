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
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionId = 1;
            decimal BalanceInicial = inscripcion.Balance;
            InscripcionBLL.Buscar(1);
            inscripcion.Balance = 100;
            InscripcionBLL.Guardar(inscripcion);
            Assert.AreEqual(inscripcion.Balance,BalanceInicial );
        }

        [TestMethod()]
        public void ModificarTest()
        {
            
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionId = 1;
            decimal BalanceInicial = inscripcion.Balance;
            InscripcionBLL.Buscar(1);
            inscripcion.Monto = 0;
            inscripcion.Balance = 0;
            inscripcion.Deposito = 0;
            InscripcionBLL.Modificar(inscripcion);
            Assert.AreEqual(inscripcion.Balance, BalanceInicial);
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