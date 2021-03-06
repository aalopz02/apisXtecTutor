using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using apisBlog.Models.ApisModel;
using apisBlog.Models.Mocks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apisBlog.Controllers
{
    [TestClass]
    public class BusquedasFechaController : ApiController
    {
        AutorEntradaI apiAutor = new AutorEntradaImpl();
        EntradaI apiEntradas= new EntradaImpl();
        CarreraI apiCarreras = new CarreraImpl();
        CursoI apiCursos = new CursoImpl();
        TemaI apiTemas = new TemaImpl();
        EstudianteI apiEstudiante = new EstudianteImpl();
        ComentarioEntradaI apiComentarios = new ComentariosEntradaImpl();
        CalificacionEntradaI apiCalificacion = new CalificacionEntradaImpl();

        /// <summary>
        /// Test method for BusquedaFecha
        /// </summary>
        [TestMethod]
        public void test()
        {
            apiAutor = new AutoresMock();
            apiEntradas = new EntradasMock();
            apiCarreras = new CarreraMock();
            apiCursos = new CursoMock();
            apiTemas = new TemaMock();
            apiEstudiante = new EstudiantesMock();
            apiComentarios = new ComentarioEntradaMock();
            apiCalificacion = new CalificacionEntradaMock();
            IEnumerable<BusquedaFechaModel> prueba1GET1 = Get("03/12/22", 1);
            Assert.AreEqual(1, prueba1GET1.First().Vistas, "Problema busquedas Get1");
            Assert.AreEqual("CE-01 curso1", prueba1GET1.First().Curso, "Problema busquedas Get1");
            Assert.AreEqual("tema1", prueba1GET1.First().Tema, "Problema busquedas Get1");
            Assert.AreEqual(3, prueba1GET1.First().NumComentarios, "Problema busquedas Get1");
            Assert.AreEqual(5, prueba1GET1.First().CalificacionProm, "Problema busquedas Get1");

            IEnumerable<BusquedaFechaModel> prueba1GET2 = Get("05/12/24", 2, "XE-01");
            Assert.AreEqual(14, prueba1GET2.First().Vistas, "Problema busquedas Get2");
            Assert.AreEqual("XE-01 cursoX1", prueba1GET2.First().Curso, "Problema busquedas Get2");
            Assert.AreEqual("tema1", prueba1GET2.First().Tema, "Problema busquedas Get2");
            Assert.AreEqual(2, prueba1GET2.First().NumComentarios, "Problema busquedas Get1");
            Assert.AreEqual(7, prueba1GET2.First().CalificacionProm, "Problema busquedas Get1");


            IEnumerable<BusquedaFechaModel> prueba1GET3 = Get("03/12/22", 1, "CE-01",1);
            Assert.AreEqual(1, prueba1GET3.First().Vistas, "Problema busquedas Get2");
            Assert.AreEqual("CE-01 curso1", prueba1GET3.First().Curso, "Problema busquedas Get2");
            Assert.AreEqual("tema1", prueba1GET3.First().Tema, "Problema busquedas Get2");
            Assert.AreEqual(3, prueba1GET3.First().NumComentarios, "Problema busquedas Get1");
            Assert.AreEqual(5, prueba1GET3.First().CalificacionProm, "Problema busquedas Get1");

            IEnumerable<BusquedaFechaModel> nulo = Get("03/12/19", 1, "CE-01");
            Assert.AreEqual(0, nulo.Count(), "Problema busquedas");

            IEnumerable<BusquedaFechaModel> nulo2 = Get("03/12/22", 1, "E-01");
            Assert.AreEqual(0, nulo.Count(), "Problema busquedas");

        }


        /// <summary>
        /// Metodo para buscar por fecha con solo carrera
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="carrera"></param>
        /// <returns>Busqueda Fecha Model</returns>
        // GET: Busquedas
        //api/BusquedasFecha?fecha=03/12/22&carrera=1
        public IEnumerable<BusquedaFechaModel> Get(string fecha, int carrera)
        {
            IEnumerable<ENTRADA> entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera).Where(e => e.FechaCrear<= Convert.ToDateTime(fecha)).Where(e => e.Visible==true).OrderByDescending(e => e.FechaCrear);
            List<BusquedaFechaModel> aux = new List<BusquedaFechaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets= apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
                string Tema;
                try
                {
                    calificacion = apiCalificacion.getAllCalificaciones().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Calificacion).Average();
                }
                catch {
                    calificacion = 0.0;
                }
                foreach (ESTUDIANTE aut in autores)
                {
                    autoreslist.Add(new ESTUDIANTE
                    {
                        Carnet = aut.Carnet,
                        Apellido = aut.Apellido,
                        Nombre = aut.Nombre,
                        Apellido2 = aut.Apellido2,
                        Correo = aut.Correo
                    });

                }
                try
                {
                    Tema = apiTemas.getTema((int)entrada.Tema).Nombre;
                }
                catch
                {
                    Tema = "";
                }
                aux.Add(new BusquedaFechaModel
                {
                  
                    Vistas = entrada.Vistas,
                    Carrera = apiCarreras.getCarrera(entrada.Carrera).Nombre,
                    Curso = entrada.Curso + " " + apiCursos.getCurso(entrada.Curso).Nombre,
                    Tema = Tema,
                    FechaCrear = entrada.FechaCrear,
                    FechaMod = entrada.FechaMod,
                    IdEntrada = entrada.IdEntrada,
                    Autores = autoreslist,
                    NumComentarios = apiComentarios.getAllComentarios().Where(e=> e.IdEntrada == entrada.IdEntrada).Count(),
                    CalificacionProm = calificacion
                });

            }
            return aux;
        }
        /// <summary>
        /// Metodo para buscar por fecha con carrera y curso
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="carrera"></param>
        /// <param name="curso"></param>
        /// <returns>Busqueda Fecha Model</returns>
        // GET: Busquedas
        //api/BusquedasFecha?fecha=03/12/22&carrera=1&curso=1
        public IEnumerable<BusquedaFechaModel> Get(string fecha, int carrera, string curso)
        {
            IEnumerable<ENTRADA> entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera & e.Curso == curso).Where(e => e.FechaCrear <= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            List<BusquedaFechaModel> aux = new List<BusquedaFechaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets = apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
                string Tema;
                try
                {
                    calificacion = apiCalificacion.getAllCalificaciones().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Calificacion).Average();
                }
                catch
                {
                    calificacion = 0.0;
                }
                foreach (ESTUDIANTE aut in autores)
                {
                    autoreslist.Add(new ESTUDIANTE
                    {
                        Carnet = aut.Carnet,
                        Apellido = aut.Apellido,
                        Nombre = aut.Nombre,
                        Apellido2 = aut.Apellido2,
                        Correo = aut.Correo
                    });

                }
                try
                {
                    Tema = apiTemas.getTema((int)entrada.Tema).Nombre;
                }
                catch
                {
                    Tema = "";
                }
                aux.Add(new BusquedaFechaModel
                {

                    Vistas = entrada.Vistas,
                    Carrera = apiCarreras.getCarrera(entrada.Carrera).Nombre,
                    Curso = entrada.Curso + " " + apiCursos.getCurso(entrada.Curso).Nombre,
                    Tema = Tema,
                    FechaCrear = entrada.FechaCrear,
                    FechaMod = entrada.FechaMod,
                    IdEntrada = entrada.IdEntrada,
                    Autores = autoreslist,
                    NumComentarios = apiComentarios.getAllComentarios().Where(e => e.IdEntrada == entrada.IdEntrada).Count(),
                    CalificacionProm = calificacion
                });

            }
            return aux;
        }
        /// <summary>
        /// Metodo para buscar por fecha con carrera,curso y tema
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="carrera"></param>
        /// <param name="curso"></param>
        /// <param name="tema"></param>
        /// <returns>Busqueda Fecha Model</returns>
        // GET: Busquedas
        //api/BusquedasFecha?fecha=03/12/22&carrera=1&curso=1&tema=1
        public IEnumerable<BusquedaFechaModel> Get(string fecha, int carrera, string curso, int tema)
        {
            IEnumerable<ENTRADA> entradas;
            if (curso=="0" || curso == null) {
                entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera).Where(e => e.FechaCrear >= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            }
            else if (tema==0 & curso != "0")
            {
                entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera & e.Curso == curso).Where(e => e.FechaCrear >= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            }
            else {
                entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera & e.Curso == curso & e.Tema == tema).Where(e => e.FechaCrear >= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            }
            List<BusquedaFechaModel> aux = new List<BusquedaFechaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets = apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
                string Tema;
                try
                {
                    calificacion = apiCalificacion.getAllCalificaciones().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Calificacion).Average();
                }
                catch
                {
                    calificacion = 0.0;
                }
                foreach (ESTUDIANTE aut in autores)
                {
                    autoreslist.Add(new ESTUDIANTE
                    {
                        Carnet = aut.Carnet,
                        Apellido = aut.Apellido,
                        Nombre = aut.Nombre,
                        Apellido2 = aut.Apellido2,
                        Correo = aut.Correo
                    });

                }
                try
                {
                    Tema = apiTemas.getTema((int)entrada.Tema).Nombre;
                }
                catch
                {
                    Tema = "";
                }
                aux.Add(new BusquedaFechaModel
                {
                    Titulo = entrada.Titulo,
                    Vistas = entrada.Vistas,
                    Carrera = apiCarreras.getCarrera(entrada.Carrera).Nombre,
                    Curso = entrada.Curso + " " + apiCursos.getCurso(entrada.Curso).Nombre,
                    Tema = Tema,
                    FechaCrear = entrada.FechaCrear,
                    FechaMod = entrada.FechaMod,
                    IdEntrada = entrada.IdEntrada,
                    Autores = autoreslist,
                    NumComentarios = apiComentarios.getAllComentarios().Where(e => e.IdEntrada == entrada.IdEntrada).Count(),
                    CalificacionProm = calificacion
                });

            }
            return aux;
        }
    }
}