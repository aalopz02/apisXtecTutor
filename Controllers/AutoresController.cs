using apisBlog.Models;
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
    public class AutoresController : ApiController
    {
        AutorEntradaI apiAutores = new AutoresMock();
        EstudianteI apiEstudiante = new EstudiantesMock();

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