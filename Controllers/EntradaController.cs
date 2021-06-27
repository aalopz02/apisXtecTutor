using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apisBlog.Controllers
{
    [TestClass]
    public class EntradaController : ApiController
    {
        //EntradaI apiEntrada = new EntradaImpl();
        //EstudianteI apiEstudiante = new EstudianteImpl();
        //AutorEntradaI apiAutores = new AutorEntradaImpl();
        EntradaI apiEntrada = new EntradasMock();
        EstudianteI apiEstudiante = new EstudiantesMock();
        AutorEntradaI apiAutores = new AutoresMock();

        [TestMethod]
        public void set() {
            apiEntrada = new EntradasMock();
            apiEstudiante = new EstudiantesMock();
            apiAutores = new AutoresMock();
        }

        [System.Web.Mvc.HttpGet]
        //https://localhost:44395/api/Entrada?idEntrada=123
        public ENTRADA getById(int idEntrada) {
            return apiEntrada.getEntrada(idEntrada);
        }

        [System.Web.Mvc.HttpGet]
        //https://localhost:44395/api/Entrada?carnet=123
        public IEnumerable<ENTRADA> getByAutor(int carnet)
        {
            ESTUDIANTE autor = apiEstudiante.getEstudiante(carnet);
            if (autor != null)
            {
                IEnumerable<int> entradasHechas = apiAutores.getAllAutoresEntrada().Where(c => c.Carnet == carnet).Select(c => c.IdEntrada);
                IEnumerable<ENTRADA> listaRetorno = apiEntrada.getAllEntradas().Where(e => entradasHechas.Contains(e.IdEntrada));
                List<ENTRADA> aux = new List<ENTRADA>();
                foreach (ENTRADA entrada in listaRetorno) {
                    aux.Add(new ENTRADA
                    {
                        Visible = entrada.Visible,
                        Vistas = entrada.Vistas,
                        Abstract = entrada.Abstract,
                        Body = entrada.Body,
                        Carrera = entrada.Carrera,
                        Curso = entrada.Curso,
                        Tema = entrada.Tema,
                        FechaCrear = entrada.FechaCrear,
                        FechaMod = entrada.FechaMod,
                        IdEntrada = entrada.IdEntrada
                    }) ;
                    
                }
                return aux;
            }
            else {
                return null;
            }
        }

        //https://localhost:44395/api/Entrada?Abstract=cacaca&Body=cacacacaca&autores=carnet1,carnet2&IdCarrera=1&Curso=0&IdTema=0
        //Si no hay curso tirar "0"
        //Si no hay tema tirar 0
        [System.Web.Mvc.HttpPost]
        public ENTRADA Post(string Abstract, string Body, string autores,int IdCarrera, String curso, int idTema) {
            DateTime fechaActual = DateTime.Today;
            ENTRADA nueva = new ENTRADA
            {
                Abstract = Abstract,
                Body = Body,
                Visible = true,
                Vistas = 0,
                FechaCrear = fechaActual,
                FechaMod = fechaActual,
                Carrera = IdCarrera,
                Curso = (curso == "0") ? null : curso
            };
            if (idTema != 0) {
                nueva.Tema = idTema;
            }
            apiEntrada.setEntrada(nueva);
            int id = apiEntrada.getAllEntradas().Last().IdEntrada;
            foreach (string carnetAutor in autores.Split(',')) {
                AUTORENTRADA nuevoAutor = new AUTORENTRADA
                {
                    Carnet = int.Parse(carnetAutor),
                    IdEntrada = id
                };
                apiAutores.setAutorEntrada(nuevoAutor);
            }
            nueva.IdEntrada = id;
            return nueva;
        }

        //https://localhost:44395/api/Entrada?IdEntrada=id&Abstract=cacaca&Body=cacacacaca&autores=carnet1,carnet2&IdCarrera=1&Curso=0&IdTema=0&visible=true
        //usar true y false, para valor
        //Si no hay curso tirar "0"
        //Si no hay tema tirar 0
        //incluir en autores los que hay al final
        [System.Web.Mvc.HttpPatch]
        public void Patch(int IdEntrada, string Abstract, string Body, string autores, int IdCarrera, String curso, int idTema, bool visible)
        {
            DateTime fechaActual = DateTime.Today;
            ENTRADA nueva = new ENTRADA
            {
                IdEntrada = IdEntrada,
                Abstract = Abstract,
                Body = Body,
                Visible = visible,
                FechaMod = fechaActual,
                Carrera = IdCarrera,
                Curso = (curso == "0") ? null : curso
            };
            if (idTema != 0)
            {
                nueva.Tema = idTema;
            }
            apiEntrada.modEntrada(nueva);
            List<AUTORENTRADA> autoresViejos = apiAutores.getAllAutoresEntrada().Where(a => a.IdEntrada == IdEntrada).ToList();
            String[] autoresNuevos = autores.Split(',');
            foreach (AUTORENTRADA aUTORENTRADA in autoresViejos) {
                if (!autoresNuevos.Contains(aUTORENTRADA.Carnet.ToString())) {
                    apiAutores.deleteAutoresEntrada(aUTORENTRADA.IdAutorEntrada);
                }
            }
            List<int> carnetsViejos = autoresViejos.Select(c => c.Carnet).ToList();

            foreach (string autorNuevo in autoresNuevos) {
                if (!carnetsViejos.Contains(int.Parse(autorNuevo)))
                {
                    apiAutores.setAutorEntrada(new AUTORENTRADA
                    {
                        Carnet = int.Parse(autorNuevo),
                        IdEntrada = IdEntrada
                    });
                }
            }
        }
    }
}