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
                ClavePublica = "6D5074B4BF2B913866157D7674F1EDA042C5C614876DE876F7512702D2572A06",
                Correo = "correo1"

            });
            listaEstudiantes.Add(new ESTUDIANTE
            {
                Carnet = 2017075876,
                Nombre = "nombre2",
                Apellido = "apellido2",
                Apellido2 = "apellido2.2",
                ClavePublica = "6D5074B4BF2B913866157D7674F1EDA042C5C614876DE876F7512702D2572A06",
                Correo = "correo2"

            });
            listaEstudiantes.Add(new ESTUDIANTE
            {
                Carnet = 2017075877,
                Nombre = "nombre3",
                Apellido = "apellido3",
                Apellido2 = "apellid3.2",
                ClavePublica = "6D5074B4BF2B913866157D7674F1EDA042C5C614876DE876F7512702D2572A06",
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

        public void modEstudiante(ESTUDIANTE viejo)
        {
            for (int i = 0; i < listaEstudiantes.Count; i++)
            {
                if (listaEstudiantes[i].Carnet == viejo.Carnet)
                {
                    listaEstudiantes[i].ClavePublica = viejo.ClavePublica;
                }
            }
        }

        public bool setEstudiante(ESTUDIANTE nuevo)
        {
            listaEstudiantes.Add(nuevo);
            return true;
        }
    }
}