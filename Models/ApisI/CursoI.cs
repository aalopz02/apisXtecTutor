using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface CursoI
    {
        CURSO getCurso(string IdCurso);
        bool setCurso(CURSO nuevo);
        List<CURSO> getAllCursos();
        bool deleteCurso(int IdCurso);
    }
}
