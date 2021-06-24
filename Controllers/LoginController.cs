using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

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
        public Object Get(int carnet)
        {
            if (apiAdmin.getAdmin(carnet) != null)
            {
                return "es admin";
            }
            else if (apiEstudiante.getEstudiante(carnet) != null)
            {
                return "es estudiante";
            }
            else {
                return "sea mamon";
            }
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
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
