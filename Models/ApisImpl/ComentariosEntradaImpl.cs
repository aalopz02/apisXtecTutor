using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class ComentariosEntradaImpl : ComentarioEntradaI
    {
        public bool deleteComentario(int IdComentario)
        {
            using (var context = new XTecTutorDBEntities())
            {
                COMENTARIOENTRADA cOMENTARIOENTRADA = context.COMENTARIOENTRADAs.Find(IdComentario);
                if (cOMENTARIOENTRADA != null)
                {
                    context.COMENTARIOENTRADAs.Remove(cOMENTARIOENTRADA);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<COMENTARIOENTRADA> getAllComentarios()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.COMENTARIOENTRADAs.ToList();
            }
        }

        public COMENTARIOENTRADA getComentario(int IdComentario)
        {
            using (var context = new XTecTutorDBEntities())
            {
                COMENTARIOENTRADA cOMENTARIOENTRAD = context.COMENTARIOENTRADAs.Find(IdComentario);
                if (cOMENTARIOENTRAD != null)
                {
                    return cOMENTARIOENTRAD;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setComentario(COMENTARIOENTRADA nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                return (context.COMENTARIOENTRADAs.Add(nuevo) != null ? true : false);
            }
        }
    }
}