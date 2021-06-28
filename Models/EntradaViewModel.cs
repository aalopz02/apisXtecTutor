using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models
{
    public class EntradaViewModel
    {
        public List<ComentarioModel> listaComentario { set; get; }
        public List<AutorModel> listaAutores { set; get; }
        public string calificacion { get; set; }
        public int IdEntrada { get; set; }
        public string Carrera { get; set; }
        public string Curso { get; set; }
        public string Tema { get; set; }
        public System.DateTime FechaCrear { get; set; }
        public System.DateTime FechaMod { get; set; }
        public int Vistas { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public string titulo { get; set; }

    }
}