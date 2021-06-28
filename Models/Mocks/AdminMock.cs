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
                ClavePublica = "6D5074B4BF2B913866157D7674F1EDA042C5C614876DE876F7512702D2572A06"
            });
            listaAdmins.Add(new ADMIN
            {
                Carnet = 1234,
                Nombre = "admin2",
                Apellido = "apellido",
                ClavePublica = "6D5074B4BF2B913866157D7674F1EDA042C5C614876DE876F7512702D2572A06"
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