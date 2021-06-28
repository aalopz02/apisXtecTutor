using apisBlog.Models.ApisI;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apisBlog.Controllers
{
    [TestClass]
    public class ComentariosController : ApiController
    {
        ComentarioEntradaI apiComentarios = new ComentarioEntradaMock();

        [TestMethod]
        public void test()
        {
            apiComentarios = new ComentarioEntradaMock();
            IEnumerable<COMENTARIOENTRADA> prueba1 = getForEntrada(1);
            Assert.AreEqual("contenidoX", prueba1.First().Contenido, "Problema getComentarios");
            setComentario(1, 2017075875, "contenidoCambiado");
            Assert.AreEqual("contenidoCambiado", prueba1.First().Contenido, "Problema getComentarios");
            delete(1);
            Assert.AreEqual("contenidoX2.0", prueba1.First().Contenido, "Problema getComentarios");
        }

        //https://localhost:44395/api/Comentarios?IdEntrada=123
        [System.Web.Mvc.HttpGet]
        public IEnumerable<COMENTARIOENTRADA> getForEntrada(int IdEntrada) {
            return apiComentarios.getAllComentarios().Where(c => c.IdEntrada == IdEntrada);
        }

        //https://localhost:44395/api/Comentarios?IdEntrada=123&Carnet=123&Contenido=cacaacaca
        [System.Web.Mvc.HttpPost]
        public void setComentario(int IdEntrada,int Carnet, String Contenido)
        {
            apiComentarios.setComentario(new COMENTARIOENTRADA {
                IdEntrada = IdEntrada,
                Carnet = Carnet,
                Contenido = Contenido,
                Fecha = System.DateTime.Today
            });
        }

        //https://localhost:44395/api/Comentarios?IdComentario=123
        [System.Web.Mvc.HttpDelete]
        public void delete(int IdComentario)
        {
            apiComentarios.deleteComentario(IdComentario);
        }
    }
}