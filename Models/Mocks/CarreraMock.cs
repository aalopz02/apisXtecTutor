using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{

    public class CarreraMock : CarreraI
    {
        List<CARRERA> listaCarreras = new List<CARRERA>();

        public CarreraMock() {
            listaCarreras.Add(new CARRERA {
                IdCarrera = 1,
                Nombre = "carrera1"
            }) ;
            listaCarreras.Add(new CARRERA
            {
                IdCarrera = 2,
                Nombre = "carrera2"
            });
            listaCarreras.Add(new CARRERA
            {
                IdCarrera = 3,
                Nombre = "carrera3"
            });
        }

        public bool deleteCarrera(int IdCarrera)
        {
            throw new NotImplementedException();
        }

        public List<CARRERA> getAllCarreras()
        {
            return listaCarreras;
        }

        public CARRERA getCarrera(int IdCarrera)
        {
            foreach (CARRERA cARRERA in listaCarreras) {
                if (cARRERA.IdCarrera == IdCarrera) {
                    return cARRERA;
                }
            }
            return null;
        }

        public bool setCarrera(CARRERA nuevo)
        {
            throw new NotImplementedException();
        }
    }
}