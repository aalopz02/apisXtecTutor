using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface CarreraI
    {
        CARRERA getCarrera(int IdCarrera);
        bool setCarrera(CARRERA nuevo);
        List<CARRERA> getAllCarreras();
        bool deleteCarrera(int IdCarrera);
    }
}
