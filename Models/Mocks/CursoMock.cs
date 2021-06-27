using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class CursoMock : CursoI
    {
        List<CURSO> listaCursos = new List<CURSO>();

        public CursoMock() {
            listaCursos.Add(new CURSO
            {
                IdCarrera = 1,
                IdCurso = "CE-01",
                Nombre = "curso1"
            }) ;
            listaCursos.Add(new CURSO
            {
                IdCarrera = 1,
                IdCurso = "CE-02",
                Nombre = "curso2"
            });
            listaCursos.Add(new CURSO
            {
                IdCarrera = 2,
                IdCurso = "YE-01",
                Nombre = "cursoY1"
            });
            listaCursos.Add(new CURSO
            {
                IdCarrera = 3,
                IdCurso = "XE-01",
                Nombre = "cursoX1"
            });
        }

        public bool deleteCurso(int IdCurso)
        {
            throw new NotImplementedException();
        }

        public List<CURSO> getAllCursos()
        {
            return listaCursos;
        }

        public CURSO getCurso(String IdCurso)
        {
            foreach (CURSO cURSO in listaCursos) {
                if (cURSO.IdCurso == IdCurso) {
                    return cURSO;
                }
            }
            return null;
        }

        public bool setCurso(CURSO nuevo)
        {
            throw new NotImplementedException();
        }
    }
}