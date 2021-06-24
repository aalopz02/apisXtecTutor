using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface CalificacionEntradaI
    {
        CALIFICACIONENTRADA getCalificacion(int IdCalificacion);
        bool setCalificacion(CALIFICACIONENTRADA nuevo);
        List<CALIFICACIONENTRADA> getAllCalificaciones();
        bool deleteCalificacion(int IdCalificacion);
    }
}
