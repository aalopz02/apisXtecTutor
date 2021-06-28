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
    public class CarreraController : ApiController
    {
        // GET: Carrera
        CarreraI apiCarrera = new CarreraMock();

        //https://localhost:44395/api/Carrera
        // GET: Curso
        public List<CARRERA> getCarreras()
        {
            return apiCarrera.getAllCarreras();
        }
    }
}