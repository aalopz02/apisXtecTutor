using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using apisBlog.Models.ApisModel;
using System.Web.Http;

namespace apisBlog.Controllers
{
    public class BusquedasFechaController : ApiController
    {
        AutorEntradaI apiAutor = new AutorEntradaImpl();
        EntradaI apiEntradas= new EntradaImpl();
        CarreraI apiCarreras = new CarreraImpl();
        EstudianteI apiEstudiante = new EstudianteImpl();
        ComentarioEntradaI apiComentarios = new ComentariosEntradaImpl();
        CalificacionEntradaI apiCalificacion = new CalificacionEntradaImpl();

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
                aux.Add(new BusquedaFechaModel
                {
                  
                    Vistas = entrada.Vistas,
                    Carrera = entrada.Carrera,
                    Curso = entrada.Curso,
                    Tema = entrada.Tema,
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
                aux.Add(new BusquedaFechaModel
                {

                    Vistas = entrada.Vistas,
                    Carrera = entrada.Carrera,
                    Curso = entrada.Curso,
                    Tema = entrada.Tema,
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

        public IEnumerable<BusquedaFechaModel> Get(string fecha, int carrera, string curso, int tema)
        {
            IEnumerable<ENTRADA> entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera== carrera & e.Curso == curso & e.Tema==tema).Where(e => e.FechaCrear <= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            List<BusquedaFechaModel> aux = new List<BusquedaFechaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets = apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
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
                aux.Add(new BusquedaFechaModel
                {

                    Vistas = entrada.Vistas,
                    Carrera = entrada.Carrera,
                    Curso = entrada.Curso,
                    Tema = entrada.Tema,
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