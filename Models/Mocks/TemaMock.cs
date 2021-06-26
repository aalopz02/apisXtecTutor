using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class TemaMock : TemaI
    {
        List<TEMA> listaTemas = new List<TEMA>();

        public TemaMock() {
            listaTemas.Add(new TEMA
            {
                IdTema = 1,
                IdCurso = "CE-01",
                Nombre = "tema1"
            });
            listaTemas.Add(new TEMA
            {
                IdTema = 2,
                IdCurso = "CE-02",
                Nombre = "tema1"
            });
            listaTemas.Add(new TEMA
            {
                IdTema = 3,
                IdCurso = "YE-01",
                Nombre = "tema3"
            });
            listaTemas.Add(new TEMA
            {
                IdTema = 4,
                IdCurso = "XE-01",
                Nombre = "tema4"
            });
        }

        public bool deleteTema(int IdTema)
        {
            throw new NotImplementedException();
        }

        public List<TEMA> getAllTemas()
        {
            return listaTemas;
        }

        public TEMA getTema(int IdTema)
        {
            foreach (TEMA tEMA in listaTemas) {
                if (tEMA.IdTema == IdTema) {
                    return tEMA;
                }
            }
            return null;
        }

        public bool setTema(TEMA tema)
        {
            throw new NotImplementedException();
        }
    }
}