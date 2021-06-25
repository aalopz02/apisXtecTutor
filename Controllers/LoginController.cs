using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Cryptography;

namespace apisBlog.Controllers
{
    public class LoginController : ApiController
    {
        AdminI apiAdmin = new AdminImpl();
        EstudianteI apiEstudiante = new EstudianteImpl();

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
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
