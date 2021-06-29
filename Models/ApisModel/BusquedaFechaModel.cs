using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisModel
{
    public class BusquedaFechaModel
    {
        public int IdEntrada { get; set; }
        public string Carrera { get; set; }
        public string Curso { get; set; }
        public string Tema { get; set; }
        public System.DateTime FechaCrear { get; set; }
        public System.DateTime FechaMod { get; set; }
        public int Vistas { get; set; }

        public double CalificacionProm { get; set; }

        public int NumComentarios { get; set; }

        public List<ESTUDIANTE> Autores { get; set; }
        public string Titulo { get; set; }
    }
}
