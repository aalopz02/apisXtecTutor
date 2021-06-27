using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using apisBlog.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace apisBlog.Controllers
{
    public class EntradaController : ApiController
    {
        //EntradaI apiEntrada = new EntradaImpl();
        //EstudianteI apiEstudiante = new EstudianteImpl();
        //AutorEntradaI apiAutores = new AutorEntradaImpl();
        EntradaI apiEntrada = new EntradasMock();
        EstudianteI apiEstudiante = new EstudiantesMock();
        AutorEntradaI apiAutores = new AutoresMock();

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

        //[FromBody] ENTRADA nueva
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
    }
}