using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface EstudianteI
    {
        ESTUDIANTE getEstudiante(int Carnet);
        bool setEstudiante(ESTUDIANTE nuevo);
        List<ESTUDIANTE> getAllEstudiantes();
        bool deleteEstudiante(int Carnet);
    }
}
