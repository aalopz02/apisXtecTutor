using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class AutorEntradaImpl : AutorEntradaI
    {
        public bool deleteAutoresEntrada(int IdAutorEntrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                AUTORENTRADA aUTORENTRADA = context.AUTORENTRADAs.Find(IdAutorEntrada);
                if (aUTORENTRADA != null)
                {
                    context.AUTORENTRADAs.Remove(aUTORENTRADA);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<AUTORENTRADA> getAllAutoresEntrada()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.AUTORENTRADAs.ToList();
            }
        }

        public AUTORENTRADA getAutorEntrada(int IdAutorEntrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                AUTORENTRADA aUTORENTRADA = context.AUTORENTRADAs.Find(IdAutorEntrada);
                if (aUTORENTRADA != null)
                {
                    return aUTORENTRADA;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setAutorEntrada(AUTORENTRADA nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.AUTORENTRADAs.Add(nuevo) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}