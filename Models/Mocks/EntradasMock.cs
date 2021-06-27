using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class EntradasMock : EntradaI
    {
        List<ENTRADA> listaEntradas = new List<ENTRADA>();

        public EntradasMock() {
            listaEntradas.Add(new ENTRADA {
                Visible = true,
                Vistas = 1,
                Abstract = "el abstract",
                Body = "el body",
                Carrera = 1,
                Curso = "CE-01",
                Tema = 1,
                FechaCrear = DateTime.Today,
                FechaMod = DateTime.Today,
                IdEntrada = 1
            });
            listaEntradas.Add(new ENTRADA
            {
                Visible = true,
                Vistas = 14,
                Abstract = "el abstract",
                Body = "el body",
                Carrera = 2,
                Curso = "XE-01",
                Tema = 2,
                FechaCrear = DateTime.Today,
                FechaMod = DateTime.Today,
                IdEntrada = 2
            });
        }

        public bool deleteEntrada(int IdEntrada)
        {
            throw new NotImplementedException();
        }

        public List<ENTRADA> getAllEntradas()
        {
            return listaEntradas;
        }

        public ENTRADA getEntrada(int IdEntrada)
        {
            foreach (ENTRADA entrada in listaEntradas) {
                if (entrada.IdEntrada == IdEntrada) {
                    return entrada;
                }
            }
            return null;
        }

        public bool setEntrada(ENTRADA entrada)
        {
            throw new NotImplementedException();
        }
    }
}