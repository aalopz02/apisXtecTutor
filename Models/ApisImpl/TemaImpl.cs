using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class TemaImpl : TemaI
    {
        public bool deleteTema(int IdTema)
        {
            using (var context = new XTecTutorDBEntities())
            {
                TEMA tEMA = context.TEMAs.Find(IdTema);
                if (tEMA != null)
                {
                    context.TEMAs.Remove(tEMA);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<TEMA> getAllTemas()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.TEMAs.ToList();
            }
        }

        public TEMA getTema(int IdTema)
        {
            using (var context = new XTecTutorDBEntities())
            {
                TEMA tEMA = context.TEMAs.Find(IdTema);
                if (tEMA != null)
                {
                    return tEMA;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setTema(TEMA tema)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.TEMAs.Add(tema) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}