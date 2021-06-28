using apisBlog.Models.ApisI;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apisBlog.Controllers
{
    [TestClass]
    public class EstudianteController : ApiController
    {
        EstudianteI apiEstudiante = new EstudiantesMock();
        [TestMethod]
        public void test()
        {
            apiEstudiante = new EstudiantesMock();
            string claveactual = apiEstudiante.getEstudiante(2017075875).ClavePublica;
            Assert.AreEqual("6D5074B4BF2B913866157D7674F1EDA042C5C614876DE876F7512702D2572A06", claveactual);
            patch(2017075875, "clavenueva");
            string clavenueva = apiEstudiante.getEstudiante(2017075875).ClavePublica;
            Assert.AreEqual("1908E1559A550096D6D324A4AF8A7D983C205B2A1019E844042E6F1270AEFDF4", clavenueva,"Problema cambio clave");
        }
        /// <summary>
        /// Metodo cambiar contrasena
        /// </summary>
        /// <param name="carnet"></param>
        /// <param name="clave"></param>
            // GET: Estudiante
            public void patch(int carnet, string clave)
        {
            ESTUDIANTE viejo = apiEstudiante.getEstudiante(carnet);
            var sha256 = new SHA256Managed();
            string passwordSHA = BitConverter.ToString(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clave))).Replace("-", "");
            viejo.ClavePublica = passwordSHA;
            apiEstudiante.modEstudiante(viejo);
        }
    }
}