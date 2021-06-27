using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class ArchivoEntradaImpl : ArchivoEntradaI
    {
        public bool deleteArchivoEntrada(int IdArchivoEntrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ARCHIVOENTRADA aRCHIVOENTRADA = context.ARCHIVOENTRADAs.Find(IdArchivoEntrada);
                if (aRCHIVOENTRADA != null)
                {
                    context.ARCHIVOENTRADAs.Remove(aRCHIVOENTRADA);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<ARCHIVOENTRADA> getAllArchivosEntrada()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.ARCHIVOENTRADAs.ToList();
            }
        }

        public ARCHIVOENTRADA getArchivoEntrada(int IdArchivoEntrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ARCHIVOENTRADA aRCHIVOENTRADA = context.ARCHIVOENTRADAs.Find(IdArchivoEntrada);
                if (aRCHIVOENTRADA != null)
                {
                    return aRCHIVOENTRADA;
                }
                else
                {
                    return null;
                }
            }
        }

        public void modEntrada(ARCHIVOENTRADA mod)
        {
            using (var context = new XTecTutorDBEntities())
            {
                context.ARCHIVOENTRADAs.FirstOrDefault(z => z.IdArchivoEntrada == mod.IdArchivoEntrada).Path = mod.Path;
                context.SaveChanges();
            }
        }

        public bool setArchivoEntrada(ARCHIVOENTRADA nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.ARCHIVOENTRADAs.Add(nuevo) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}