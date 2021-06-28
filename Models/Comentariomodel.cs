using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models
{
    public class ComentarioModel
    {
        public int carnet { get; set; }
        public string nombre { get; set; }
        public string body { get; set; }
        public System.DateTime fecha { get; set; }
    }
}