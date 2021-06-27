using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models
{
    public class EntradaViewModel
    {
        public List<Comentariomodel> listaComentario { set; get; }
        public List<AutorModel> listaAutores { set; get; }
        public string calificacion { get; set; }
        public int IdEntrada { get; set; }
        public int Carrera { get; set; }
        public string Curso { get; set; }
        public int Tema { get; set; }
        public System.DateTime FechaCrear { get; set; }
        public System.DateTime FechaMod { get; set; }
        public int Vistas { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
    }
}