using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class ComentarioEntradaMock : ComentarioEntradaI
    {
        List<COMENTARIOENTRADA> listaComentarios = new List<COMENTARIOENTRADA>();

        public ComentarioEntradaMock() {
            listaComentarios.Add(new COMENTARIOENTRADA {
                IdComentario = 1,
                IdEntrada = 1,
                Carnet = 2017075875,
                Contenido = "contenidoX",
                Fecha = System.DateTime.Today
            });
            listaComentarios.Add(new COMENTARIOENTRADA
            {
                IdComentario = 2,
                IdEntrada = 1,
                Carnet = 2017075875,
                Contenido = "contenidoX2.0",
                Fecha = System.DateTime.Today

            });
            listaComentarios.Add(new COMENTARIOENTRADA
            {
                IdComentario = 3,
                IdEntrada = 1,
                Carnet = 2017075876,
                Contenido = "contenidoX",
                Fecha = System.DateTime.Today
            });
            listaComentarios.Add(new COMENTARIOENTRADA
            {
                IdComentario = 4,
                IdEntrada = 2,
                Carnet = 2017075875,
                Contenido = "contenidoX",
                Fecha = System.DateTime.Today
            });
            listaComentarios.Add(new COMENTARIOENTRADA
            {
                IdComentario = 5,
                IdEntrada = 2,
                Carnet = 2017075875,
                Contenido = "contenidoX2.0",
                Fecha = System.DateTime.Today
            });
        }

        public bool deleteComentario(int IdComentario)
        {
            COMENTARIOENTRADA aux = getComentario(IdComentario);
            if (aux != null) {
                return listaComentarios.Remove(aux);
            }
            return false;
        }

        public List<COMENTARIOENTRADA> getAllComentarios()
        {
            return listaComentarios;
        }

        public COMENTARIOENTRADA getComentario(int IdComentario)
        {
            foreach (COMENTARIOENTRADA cOMENTARIOENTRADA in listaComentarios) {
                if (cOMENTARIOENTRADA.IdComentario == IdComentario) {
                    return cOMENTARIOENTRADA;
                }
            }
            return null;
        }

        public bool setComentario(COMENTARIOENTRADA nuevo)
        {
            throw new NotImplementedException();
        }
    }
}