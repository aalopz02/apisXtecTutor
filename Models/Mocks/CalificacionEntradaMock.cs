using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class CalificacionEntradaMock : CalificacionEntradaI
    {
        List<CALIFICACIONENTRADA> listaCalifiaciones = new List<CALIFICACIONENTRADA>();

        public CalificacionEntradaMock() {
            listaCalifiaciones.Add(new CALIFICACIONENTRADA {
                IdCalificacion = 1,
                IdEntrada = 1,
                Carnet = 2017075875,
                Calificacion = 4
            });
            listaCalifiaciones.Add(new CALIFICACIONENTRADA
            {
                IdCalificacion = 2,
                IdEntrada = 1,
                Carnet = 2017075876,
                Calificacion = 3
            });
            listaCalifiaciones.Add(new CALIFICACIONENTRADA
            {
                IdCalificacion = 3,
                IdEntrada = 1,
                Carnet = 2017075877,
                Calificacion = 8
            });
            listaCalifiaciones.Add(new CALIFICACIONENTRADA
            {
                IdCalificacion = 4,
                IdEntrada = 2,
                Carnet = 2017075875,
                Calificacion = 4
            });
            listaCalifiaciones.Add(new CALIFICACIONENTRADA
            {
                IdCalificacion = 5,
                IdEntrada = 2,
                Carnet = 2017075876,
                Calificacion = 10
            });
        }

        public bool deleteCalificacion(int IdCalificacion)
        {
            throw new NotImplementedException();
        }

        public List<CALIFICACIONENTRADA> getAllCalificaciones()
        {
            return listaCalifiaciones;
        }

        public CALIFICACIONENTRADA getCalificacion(int IdCalificacion)
        {
            foreach (CALIFICACIONENTRADA cALIFICACIONENTRADA in listaCalifiaciones) {
                if (cALIFICACIONENTRADA.IdCalificacion == IdCalificacion) {
                    return cALIFICACIONENTRADA;
                }
            }
            return null;
        }

        public bool setCalificacion(CALIFICACIONENTRADA nuevo)
        {
            listaCalifiaciones.Add(nuevo);
            return true;
        }
    }
}