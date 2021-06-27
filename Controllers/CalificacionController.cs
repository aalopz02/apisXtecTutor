using apisBlog.Models.ApisI;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace apisBlog.Controllers
{
    public class CalificacionController : ApiController
    {
        CalificacionEntradaI apiCalificacion = new CalificacionEntradaMock();

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

    }
}