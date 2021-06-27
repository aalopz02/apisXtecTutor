﻿using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class ArchivoEntradaMock : ArchivoEntradaI
    {
        List<ARCHIVOENTRADA> listaArchivos = new List<ARCHIVOENTRADA>();

        public ArchivoEntradaMock() {
            listaArchivos.Add(new ARCHIVOENTRADA {
                IdArchivoEntrada = 1,
                IdEntrada = 1,
                Path = "elpath1"
            });
            listaArchivos.Add(new ARCHIVOENTRADA
            {
                IdArchivoEntrada = 2,
                IdEntrada = 1,
                Path = "elpath2"
            });
            listaArchivos.Add(new ARCHIVOENTRADA
            {
                IdArchivoEntrada = 3,
                IdEntrada = 2,
                Path = "elpath1"
            });
        }

        public bool deleteArchivoEntrada(int IdArchivoEntrada)
        {
            throw new NotImplementedException();
        }

        public List<ARCHIVOENTRADA> getAllArchivosEntrada()
        {
            return listaArchivos;
        }

        public ARCHIVOENTRADA getArchivoEntrada(int IdArchivoEntrada)
        {
            foreach (ARCHIVOENTRADA aRCHIVOENTRADA in listaArchivos) {
                if (aRCHIVOENTRADA.IdArchivoEntrada == IdArchivoEntrada) {
                    return aRCHIVOENTRADA;
                }
            }
            return null;
        }

        public bool setArchivoEntrada(ARCHIVOENTRADA nuevo)
        {
            throw new NotImplementedException();
        }
    }
}