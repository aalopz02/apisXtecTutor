using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class CarreraImpl : CarreraI
    {
        public bool deleteCarrera(int IdCarrera)
        {
            using (var context = new XTecTutorDBEntities())
            {
                CARRERA cARRERA = context.CARRERAs.Find(IdCarrera);
                if (cARRERA != null)
                {
                    context.CARRERAs.Remove(cARRERA);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<CARRERA> getAllCarreras()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.CARRERAs.ToList();
            }
        }

        public CARRERA getCarrera(int IdCarrera)
        {
            using (var context = new XTecTutorDBEntities())
            {
                CARRERA cARRERA = context.CARRERAs.Find(IdCarrera);
                if (cARRERA != null)
                {
                    return cARRERA;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setCarrera(CARRERA nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {bool result = context.CARRERAs.Add(nuevo) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}