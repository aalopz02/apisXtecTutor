using apisBlog.Models.ApisI;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace apisBlog.Controllers
{
    public class EstudianteController : ApiController
    {
        EstudianteI apiEstudiante = new EstudiantesMock();

        // GET: Estudiante
        public void patch(int carnet, string clave)
        {
            ESTUDIANTE viejo = apiEstudiante.getEstudiante(carnet);
            var sha256 = new SHA256Managed();
            string passwordSHA = BitConverter.ToString(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave))).Replace("-", "");
            viejo.ClavePublica = passwordSHA;
            apiEstudiante.setEstudiante(viejo);
        }
    }
}