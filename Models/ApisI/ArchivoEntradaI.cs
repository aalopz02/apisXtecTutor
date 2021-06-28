using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface ArchivoEntradaI
    {
        ARCHIVOENTRADA getArchivoEntrada(int IdArchivoEntrada);
        bool setArchivoEntrada(ARCHIVOENTRADA nuevo);
        List<ARCHIVOENTRADA> getAllArchivosEntrada();
        bool deleteArchivoEntrada(int IdArchivoEntrada);
        void modEntrada(ARCHIVOENTRADA mod);
    }
}
