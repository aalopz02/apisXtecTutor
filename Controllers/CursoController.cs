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
    public class CursoController : ApiController
    {
        CursoI apiCurso = new CursoMock();

        //https://localhost:44395/api/Curso
        // GET: Curso
        public List<CURSO> getCurso()
        {
            return apiCurso.getAllCursos();
        }
    }
}