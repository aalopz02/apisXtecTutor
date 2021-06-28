using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface EntradaI
    {
        ENTRADA getEntrada(int IdEntrada);
        bool setEntrada(ENTRADA entrada);
        List<ENTRADA> getAllEntradas();
        bool deleteEntrada(int IdEntrada);
        void modEntrada(ENTRADA nueva);
    }
}
