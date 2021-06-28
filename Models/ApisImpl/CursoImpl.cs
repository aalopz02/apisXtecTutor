using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class CursoImpl : CursoI
    {
        public bool deleteCurso(int IdCurso)
        {
            using (var context = new XTecTutorDBEntities())
            {
                CURSO cURSO = context.CURSOes.Find(IdCurso);
                if (cURSO != null)
                {
                    context.CURSOes.Remove(cURSO);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<CURSO> getAllCursos()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.CURSOes.ToList();
            }
        }

        public CURSO getCurso(string IdCurso)
        {
            using (var context = new XTecTutorDBEntities())
            {
                CURSO cURSO = context.CURSOes.Find(IdCurso);
                if (cURSO != null)
                {
                    return cURSO;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool setCurso(CURSO nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.CURSOes.Add(nuevo) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}