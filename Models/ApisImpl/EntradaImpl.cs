using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class EntradaImpl : EntradaI
    {

        public bool deleteEntrada(int Carnet)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ENTRADA eNTRADA = context.ENTRADAs.Find(Carnet);
                if (eNTRADA != null)
                {
                    context.ENTRADAs.Remove(eNTRADA);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<ENTRADA> getAllEntradas()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.ENTRADAs.ToList();
            }
        }

        public ENTRADA getEntrada(int IdEntrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ENTRADA eNTRADA = context.ENTRADAs.Find(IdEntrada);
                if (eNTRADA != null)
                {
                    return eNTRADA;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setEntrada(ENTRADA entrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.ENTRADAs.Add(entrada) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}