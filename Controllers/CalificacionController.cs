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
    public class CalificacionController : ApiController
    {
        CalificacionEntradaI apiCalificacion = new CalificacionEntradaMock();

        [TestMethod]
        public void test()
        {
            apiCalificacion = new CalificacionEntradaMock();
            Assert.AreEqual(5.0, getOverAll(1), "Problema getPromedioCalificaciones");
            Assert.AreEqual(7.0, getOverAll(2), "Problema getPromedioCalificaciones");
            calificar(1, 2017075876);
            Assert.AreEqual(3.75, getOverAll(1), "Problema calificar");
        }

            /// <summary>
            /// Metodo get calificaciones entrada
            /// </summary>
            /// <param name="IdEntrada"></param>
            /// <returns>double promedio</returns>
            //https://localhost:44395/api/Calificacion?IdEntrada=123
            [System.Web.Mvc.HttpGet]
        public double getOverAll(int IdEntrada)
        {
            double promedio = 0.0;
            IEnumerable<CALIFICACIONENTRADA> calificaciones = apiCalificacion.getAllCalificaciones().Where(c => c.IdEntrada == IdEntrada);
            foreach (CALIFICACIONENTRADA cALIFICACIONENTRADA in calificaciones) {
                promedio += cALIFICACIONENTRADA.Calificacion;
            }
            return promedio / calificaciones.Count();
        }
       /// <summary>
       /// Metodo para calificar con el carbet
       /// </summary>
       /// <param name="IdEntrada"></param>
       /// <param name="Carnet"></param>
        //https://localhost:44395/api/Calificacion?IdEntrada=123&Carnet=123
        [System.Web.Mvc.HttpPost]
        public void calificar(int IdEntrada,int Carnet)
        {
            apiCalificacion.setCalificacion(new CALIFICACIONENTRADA {
                IdEntrada = IdEntrada,
                Carnet = Carnet,
                Fecha = System.DateTime.Today
            });
        }

    }
}