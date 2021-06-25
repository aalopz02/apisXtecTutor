using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using apisBlog.Models.ApisModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;

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



        public LoginModel Get(int carnet,string password)
        {
      

            LoginModel model = new LoginModel
            {
            
            };

            if (apiAdmin.getAdmin(carnet) != null)
            {
                if (apiAdmin.getAdmin(carnet).ClavePublica == password)
                {
                    model.info = "Password correcta Admin";
                    model.admin= apiAdmin.getAdmin(carnet);
                    return model;
                }

                else
                {
                    model.info= "Password incorrecta Admin";
                    return model;
                }

            }
            else if (apiEstudiante.getEstudiante(carnet) != null)
            {
                if (apiEstudiante.getEstudiante(carnet).ClavePublica == password)
                {
                    model.info = "Password correcta Estudiante";
                    model.estudiante= apiEstudiante.getEstudiante(carnet);
                    return model;
                }

                else
                {
                    model.info= "Password incorrecta Estudiante";
                    return model;
                }
            }
            else
            {
                model.info= "No es estudiante ni admin";
                return model;
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
