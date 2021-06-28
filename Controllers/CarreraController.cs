using apisBlog.Models.ApisI;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apisBlog.Controllers
{
    [TestClass]
    public class CarreraController : ApiController
    {
        // GET: Carrera
        CarreraI apiCarrera = new CarreraMock();

        [TestMethod]
        public void test()
        {
            apiCarrera = new CarreraMock();
            List<CARRERA> prueba1 = getCarreras();
            Assert.AreEqual("carrera1", prueba1.First().Nombre, "Problema getCarreras");
            Assert.AreEqual("carrera3", prueba1.Last().Nombre, "Problema getCarreras");
            Assert.AreEqual(3, prueba1.Count(), "Problema getCarreras");
        }
        
        /// <summary>
        /// Metodo para get de carreras
        /// </summary>
        /// <returns>Lista de carreras</returns>
        //https://localhost:44395/api/Carrera
        // GET: Curso
        public List<CARRERA> getCarreras()
        {
            return apiCarrera.getAllCarreras();
        }
    }
}