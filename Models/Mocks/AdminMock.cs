using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class AdminMock : AdminI
    {
        List<ADMIN> listaAdmins = new List<ADMIN>();

        public AdminMock() {
            listaAdmins.Add(new ADMIN {
                Carnet = 123,
                Nombre = "admin1",
                Apellido = "apellido",
                ClavePublica = "6d5074b4bf2b913866157d7674f1eda042c5c614876de876f7512702d2572a06"
            });
            listaAdmins.Add(new ADMIN
            {
                Carnet = 1234,
                Nombre = "admin2",
                Apellido = "apellido",
                ClavePublica = "6d5074b4bf2b913866157d7674f1eda042c5c614876de876f7512702d2572a06"
            });
        }

        public bool deleteAdmin(int Carnet)
        {
            throw new NotImplementedException();
        }

        public ADMIN getAdmin(int Carnet)
        {
            foreach (ADMIN aDMIN in listaAdmins) {
                if (aDMIN.Carnet == Carnet) {
                    return aDMIN;
                }
            }
            return null;
        }

        public List<ADMIN> getAllAdmins()
        {
            return listaAdmins;
        }

        public bool setAdmin(ADMIN nuevo)
        {
            throw new NotImplementedException();
        }
    }
}