using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class CalificacionEntradaImpl : CalificacionEntradaI
    {
        public bool deleteCalificacion(int IdCalificacion)
        {
            using (var context = new XTecTutorDBEntities())
            {
                CALIFICACIONENTRADA cALIFICACIONENTRADA = context.CALIFICACIONENTRADAs.Find(IdCalificacion);
                if (cALIFICACIONENTRADA != null)
                {
                    context.CALIFICACIONENTRADAs.Remove(cALIFICACIONENTRADA);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<CALIFICACIONENTRADA> getAllCalificaciones()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.CALIFICACIONENTRADAs.ToList();
            }
        }

        public CALIFICACIONENTRADA getCalificacion(int IdCalificacion)
        {
            using (var context = new XTecTutorDBEntities())
            {
                CALIFICACIONENTRADA calificacion = context.CALIFICACIONENTRADAs.Find(IdCalificacion);
                if (calificacion != null)
                {
                    return calificacion;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setCalificacion(CALIFICACIONENTRADA nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                return (context.CALIFICACIONENTRADAs.Add(nuevo) != null ? true : false);
            }
        }
    }
}