using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class AdminImpl : AdminI
    {
        public bool deleteAdmin(int Carnet)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ADMIN admin = context.ADMINs.Find(Carnet);
                if (admin != null)
                {
                    context.ADMINs.Remove(admin);
                    context.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        public ADMIN getAdmin(int Carnet)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ADMIN admin = context.ADMINs.Find(Carnet);
                if (admin != null)
                {
                    return admin;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ADMIN> getAllAdmins()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.ADMINs.ToList();
            }
        }

        public bool setAdmin(ADMIN nuevo)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = (context.ADMINs.Add(nuevo) != null);
                context.SaveChanges();
                return result;
            }
        }
    }
}