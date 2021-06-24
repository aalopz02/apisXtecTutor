using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class EstudianteImpl : EstudianteI
    {
        public bool deleteEstudiante(int Carnet)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ESTUDIANTE eSTUDIANTE = context.ESTUDIANTEs.Find(Carnet);
                if (eSTUDIANTE != null)
                {
                    context.ESTUDIANTEs.Remove(eSTUDIANTE);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<ESTUDIANTE> getAllEstudiantes()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.ESTUDIANTEs.ToList();
            }
        }

        public ESTUDIANTE getEstudiante(int Carnet)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ESTUDIANTE eSTUDIANTE = context.ESTUDIANTEs.Find(Carnet);
                if (eSTUDIANTE != null)
                {
                    return eSTUDIANTE;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setEstudiante(ESTUDIANTE nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.ESTUDIANTEs.Add(nuevo) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}