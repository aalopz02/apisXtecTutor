using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.Mocks
{
    public class EstudiantesMock : EstudianteI
    {
        List<ESTUDIANTE> listaEstudiantes = new List<ESTUDIANTE>();

        public EstudiantesMock() {
            listaEstudiantes.Add(new ESTUDIANTE {
                Carnet = 2017075875,
                Nombre = "nombre1",
                Apellido = "apellido1",
                Apellido2 = "apellido1.2",
                ClavePublica = "6d5074b4bf2b913866157d7674f1eda042c5c614876de876f7512702d2572a06",
                Correo = "correo1"

            });
            listaEstudiantes.Add(new ESTUDIANTE
            {
                Carnet = 2017075876,
                Nombre = "nombre2",
                Apellido = "apellido2",
                Apellido2 = "apellido2.2",
                ClavePublica = "6d5074b4bf2b913866157d7674f1eda042c5c614876de876f7512702d2572a06",
                Correo = "correo2"

            });
            listaEstudiantes.Add(new ESTUDIANTE
            {
                Carnet = 2017075877,
                Nombre = "nombre3",
                Apellido = "apellido3",
                Apellido2 = "apellid3.2",
                ClavePublica = "6d5074b4bf2b913866157d7674f1eda042c5c614876de876f7512702d2572a06",
                Correo = "correo3"

            });
        }

        public bool deleteEstudiante(int Carnet)
        {
            throw new NotImplementedException();
        }

        public List<ESTUDIANTE> getAllEstudiantes()
        {
            return listaEstudiantes;
        }

        public ESTUDIANTE getEstudiante(int Carnet)
        {
            foreach (ESTUDIANTE eSTUDIANTE in listaEstudiantes) {
                if (eSTUDIANTE.Carnet == Carnet) {
                    return eSTUDIANTE;
                }
            }
            return null;
        }

        public bool setEstudiante(ESTUDIANTE nuevo)
        {
            throw new NotImplementedException();
        }
    }
}