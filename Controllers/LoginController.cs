using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apisBlog.Controllers
{
    [TestClass]
    
    public class LoginController : ApiController
    {
        AdminI apiAdmin = new AdminImpl();
        EstudianteI apiEstudiante = new EstudianteImpl();
        /// <summary>
        /// Test method for Login
        /// </summary>
        [TestMethod]
        public void test() {
            apiAdmin = new AdminMock();
            apiEstudiante = new EstudiantesMock();

            string estudiante1 = Get(2017075875);
            Assert.AreEqual("Es estudiante", estudiante1,  "Problema validacion tipo usuario");
            string estudiante2 = Get(2017075876);
            Assert.AreEqual("Es estudiante", estudiante2, "Problema validacion tipo usuario");
            string admin1 = Get(123);
            Assert.AreEqual("Es admin", admin1, "Problema validacion tipo usuario");
            string admin2 = Get(1234);
            Assert.AreEqual("Es admin", admin2, "Problema validacion tipo usuario");
            string anonymous = Get(0000);
            Assert.AreEqual("No es estudiante ni admin", anonymous, "Problema validacion password usuario");


            ESTUDIANTE estudiantecontbien = (ESTUDIANTE) Get(2017075875, "clave");
            Assert.AreEqual(2017075875, estudiantecontbien.Carnet, "Problema validacion password usuario");
            Assert.AreEqual("nombre1", estudiantecontbien.Nombre, "Problema validacion password usuario");
            Assert.AreEqual("apellido1", estudiantecontbien.Apellido, "Problema validacion password usuario");
            Assert.AreEqual("apellido1.2", estudiantecontbien.Apellido2, "Problema validacion password usuario");
            Assert.AreEqual("correo1", estudiantecontbien.Correo, "Problema validacion password usuario");
            ADMIN admincontbien = (ADMIN) Get(123, "clave");
            Assert.AreEqual(123, admincontbien.Carnet, "Problema validacion password usuario");
            Assert.AreEqual("admin1", admincontbien.Nombre, "Problema validacion password usuario");
            Assert.AreEqual("apellido", admincontbien.Apellido, "Problema validacion password usuario");
            string estudiantecontmal = (string) Get(2017075876,"clave incorrecta");
            Assert.AreEqual("Password incorrecta Estudiante", estudiantecontmal, "Problema validacion password usuario");
            string admincontmal = (string) Get(1234,"clave incorrecta");
            Assert.AreEqual("Password incorrecta Admin", admincontmal, "Problema validacion password usuario");
            string anonymouscont = (string) Get(0000, "clave incorrecta");
            Assert.AreEqual("No es estudiante ni admin", anonymouscont, "Problema validacion password usuario");

        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// Metodo para ver si es estudiante o admin
        /// </summary>
        /// <param name="carnet"></param>
        /// <returns>String de tipo</returns>
        // GET api/Login?carnet=1234
        public String Get(int carnet)
        {
            if (apiAdmin.getAdmin(carnet) != null)
            {
                return "Es admin";
            }
            else if (apiEstudiante.getEstudiante(carnet) != null)
            {
                return "Es estudiante";
            }
            else {
                return "No es estudiante ni admin";
            }
        }


        /// <summary>
        /// Metodo para iniciar sesion
        /// </summary>
        /// <param name="carnet"></param>
        /// <param name="password"></param>
        /// <returns>String si error, Objeto estudiante o admin si es correcto el login</returns>
        // GET api/Login?carnet=1234&password=clave
        public Object Get(int carnet,string password)
        {

            var sha256 = new SHA256Managed();
            string passwordSHA=BitConverter.ToString(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))).Replace("-", "");
            if (apiAdmin.getAdmin(carnet) != null)
            {
                if (apiAdmin.getAdmin(carnet).ClavePublica == passwordSHA)
                {
                    ADMIN admin = new ADMIN
                    {
                        Carnet = apiAdmin.getAdmin(carnet).Carnet,
                        Apellido = apiAdmin.getAdmin(carnet).Apellido,
                        Nombre = apiAdmin.getAdmin(carnet).Nombre
                    };
                    return admin;
                }

                else
                {
                   return "Password incorrecta Admin";
                }

            }
            else if (apiEstudiante.getEstudiante(carnet) != null)
            {
                if (apiEstudiante.getEstudiante(carnet).ClavePublica == passwordSHA)
                {
                    ESTUDIANTE estudiante = new ESTUDIANTE
                    {
                        Carnet = apiEstudiante.getEstudiante(carnet).Carnet,
                        Apellido = apiEstudiante.getEstudiante(carnet).Apellido,
                        Nombre = apiEstudiante.getEstudiante(carnet).Nombre,
                        Apellido2 = apiEstudiante.getEstudiante(carnet).Apellido2,
                        Correo=apiEstudiante.getEstudiante(carnet).Correo
                    };
                    return estudiante;
                }

                else
                {
                    return "Password incorrecta Estudiante";
                }
            }
            else
            {
                 return "No es estudiante ni admin";
            }
          
        }

        // POST api/values
        public void Post(string value)
        {
            apiAdmin.setAdmin(new ADMIN
            {
                Nombre = "admin",
                Carnet = 123,
                Apellido = "ap1",
                ClavePublica = "clave"
            });
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
