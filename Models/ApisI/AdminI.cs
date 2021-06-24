using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface AdminI
    {
        ADMIN getAdmin(int Carnet);
        bool setAdmin(ADMIN nuevo);
        List<ADMIN> getAllAdmins();
        bool deleteAdmin(int Carnet);
    }
}
