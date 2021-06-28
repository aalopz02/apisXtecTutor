using apisBlog.Models;
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
    public class AutoresController : ApiController
    {
        AutorEntradaI apiAutores = new AutoresMock();
        EstudianteI apiEstudiante = new EstudiantesMock();

        /// <summary>
        /// Test method for Autores
        /// </summary>
        [TestMethod]
        public void test()
        {
            apiAutores = new AutoresMock();
            apiEstudiante = new EstudiantesMock();

            IEnumerable<AutorModel> prueba1 = getAutores(1);
            Assert.AreEqual(2017075875, prueba1.First().carnet, "Problema getAutores");
            Assert.AreEqual("nombre1", prueba1.First().nombre, "Problema getAutores");
            Assert.AreEqual("apellido1", prueba1.First().apellido, "Problema getAutores");
            Assert.AreEqual(2, prueba1.Count(), "Problema getAutores");


        }

            /// <summary>
            /// Metodo get Autores
            /// </summary>
            /// <param name="IdEntrada"></param>
            /// <returns>AutorModel</returns>
            //https://localhost:44395/api/Autores?IdEntrada=123
            [System.Web.Mvc.HttpGet]
        // GET: Autores
        public IEnumerable<AutorModel> getAutores(int IdEntrada)
        {
            List<AUTORENTRADA> listaAutores = apiAutores.getAllAutoresEntrada().Where(a => a.IdEntrada == IdEntrada).ToList();
            List<AutorModel> returnList = new List<AutorModel>();
            foreach (AUTORENTRADA aUTORENTRADA in listaAutores) {
                ESTUDIANTE estudiante = apiEstudiante.getEstudiante(aUTORENTRADA.Carnet);
                returnList.Add(new AutorModel {
                    nombre = estudiante.Nombre,
                    apellido = estudiante.Apellido,
                    carnet = estudiante.Carnet
                });
            }
            return returnList;
        }
    }
}