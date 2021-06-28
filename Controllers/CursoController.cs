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
    public class CursoController : ApiController
    {
        CursoI apiCurso = new CursoMock();

        [TestMethod]
        public void test()
        {
            apiCurso = new CursoMock();
            List<CURSO> prueba1 = getCurso();
            Assert.AreEqual("curso1", prueba1.First().Nombre, "Problema getCursos");
            Assert.AreEqual("cursoX1", prueba1.Last().Nombre, "Problema getCursos");
            Assert.AreEqual(4, prueba1.Count(), "Problema getCursos");
        }
        /// <summary>
        /// Metodo get Cursos
        /// </summary>
        /// <returns>Lista de cursos</returns>
        //https://localhost:44395/api/Curso
        // GET: Curso
        public List<CURSO> getCurso()
        {
        return apiCurso.getAllCursos();
        }
    }
}