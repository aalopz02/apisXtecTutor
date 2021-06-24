using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface TemaI
    {
        TEMA getTema(int IdTema);
        bool setTema(TEMA tema);
        List<TEMA> getAllTemas();
        bool deleteTema(int IdTema);
    }
}
