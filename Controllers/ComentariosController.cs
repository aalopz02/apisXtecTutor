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
    public class ComentariosController : ApiController
    {
        ComentarioEntradaI apiComentarios = new ComentarioEntradaMock();

        // GET: Comenatarios
        public IEnumerable<COMENTARIOENTRADA> getForEntrada(int IdEntrada) {
            return apiComentarios.getAllComentarios().Where(c => c.IdEntrada == IdEntrada);
        }

        public void delete(int IdComentario)
        {
            apiComentarios.deleteComentario(IdComentario);
        }
    }
}