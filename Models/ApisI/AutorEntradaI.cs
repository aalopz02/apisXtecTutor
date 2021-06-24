using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface AutorEntradaI
    {
        AUTORENTRADA getAutorEntrada(int IdAutorEntrada);
        bool setAutorEntrada(AUTORENTRADA nuevo);
        List<AUTORENTRADA> getAllAutoresEntrada();
        bool deleteAutoresEntrada(int IdAutorEntrada);
    }
}
