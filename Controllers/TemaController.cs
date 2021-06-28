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
    public class TemaController : ApiController
    {
        // GET: Tema
        TemaI apiTema = new TemaMock();

        [TestMethod]
        public void test()
        {
            apiTema = new TemaMock();
            List<TEMA> prueba1 = getTemas();
            Assert.AreEqual("tema1", prueba1.First().Nombre, "Problema getTemas");
            Assert.AreEqual("tema4", prueba1.Last().Nombre, "Problema getTemas");
            Assert.AreEqual(4, prueba1.Count(), "Problema getTemas");
        }
        /// <summary>
        /// Metodo para obtener temas
        /// </summary>
        /// <returns></returns>
        //https://localhost:44395/api/Tema
        // GET: Curso
        public List<TEMA> getTemas()
        {
            return apiTema.getAllTemas();
        }
    }
}