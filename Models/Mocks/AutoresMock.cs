using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class AutoresMock : AutorEntradaI
    {
        List<AUTORENTRADA> listaAutores = new List<AUTORENTRADA>();

        public AutoresMock() {
            listaAutores.Add(new AUTORENTRADA
            {
                Carnet = 2017075875,
                IdEntrada = 1,
                IdAutorEntrada = 1
            }) ;
            listaAutores.Add(new AUTORENTRADA
            {
                Carnet = 2017075876,
                IdEntrada = 1,
                IdAutorEntrada = 2
            });
            listaAutores.Add(new AUTORENTRADA
            {
                Carnet = 2017075877,
                IdEntrada = 2,
                IdAutorEntrada = 3
            });
        }

        public bool deleteAutoresEntrada(int IdAutorEntrada)
        {
            AUTORENTRADA aux = null;
            foreach (AUTORENTRADA aUTORENTRADA in listaAutores) {
                if (aUTORENTRADA.IdAutorEntrada == IdAutorEntrada) {
                    aux = aUTORENTRADA;
                    break;
                }
            }
            return listaAutores.Remove(aux);
        }

        public List<AUTORENTRADA> getAllAutoresEntrada()
        {
            return listaAutores;
        }

        public AUTORENTRADA getAutorEntrada(int IdAutorEntrada)
        {
            AUTORENTRADA aux = null;
            foreach (AUTORENTRADA aUTORENTRADA in listaAutores)
            {
                if (aUTORENTRADA.IdAutorEntrada == IdAutorEntrada)
                {
                    aux = aUTORENTRADA;
                    break;
                }
            }
            return aux;
        }

        public bool setAutorEntrada(AUTORENTRADA nuevo)
        {
            listaAutores.Add(nuevo);
            return true;
        }
    }
}