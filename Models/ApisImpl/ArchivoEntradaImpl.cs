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

        public bool setArchivoEntrada(ARCHIVOENTRADA nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                return (context.ARCHIVOENTRADAs.Add(nuevo) != null ? true : false);
            }
        }
    }
}