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
    public class TemaController : ApiController
    {
        // GET: Tema
        TemaI apiTema = new TemaMock();

        //https://localhost:44395/api/Tema
        // GET: Curso
        public List<TEMA> getTemas()
        {
            return apiTema.getAllTemas();
        }
    }
}