﻿using apisBlog.Models.ApisI;
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