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
    public class BusquedasRelevanciaController : ApiController
    {
        AutorEntradaI apiAutor = new AutorEntradaImpl();
        EntradaI apiEntradas= new EntradaImpl();
        CarreraI apiCarreras = new CarreraImpl();
        EstudianteI apiEstudiante = new EstudianteImpl();
        ComentarioEntradaI apiComentarios = new ComentariosEntradaImpl();
        CalificacionEntradaI apiCalificacion = new CalificacionEntradaImpl();
        // GET: Busquedas
        //api/BusquedasRelevancia?fecha=03/12/22&carrera=1
        public IEnumerable<BusquedaRelevanciaModel> Get(string fecha, int carrera)
        {
            
            IEnumerable<ENTRADA> entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera).Where(e => e.FechaCrear<= Convert.ToDateTime(fecha)).Where(e => e.Visible==true).OrderByDescending(e => e.FechaCrear);
            List<BusquedaRelevanciaModel> aux = new List<BusquedaRelevanciaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets= apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
                var cantidadcomentarios = apiComentarios.getAllComentarios().GroupBy(e => e.IdEntrada).Select(group => Tuple.Create(group.Key, group.Count())) ;
                int ccomentarios = cantidadcomentarios.Select(e => e.Item2).Max();
                int Numcomentarios = apiComentarios.getAllComentarios().Where(e => e.IdEntrada == entrada.IdEntrada).Count();


                try
                {
                    calificacion = apiCalificacion.getAllCalificaciones().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Calificacion).Average();
                }
                catch {
                    calificacion = 0.0;
                }

                int relevancia = (int ) (30 * (calificacion / 10) + 20* (Numcomentarios / ccomentarios));
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
                aux.Add(new BusquedaRelevanciaModel
                {
                  
                    Vistas = entrada.Vistas,
                    Carrera = entrada.Carrera,
                    Curso = entrada.Curso,
                    Tema = entrada.Tema,
                    FechaCrear = entrada.FechaCrear,
                    FechaMod = entrada.FechaMod,
                    IdEntrada = entrada.IdEntrada,
                    Autores = autoreslist,
                    NumComentarios = Numcomentarios,
                    CalificacionProm = calificacion,
                    Relevancia = relevancia
                });

            }
            return aux.OrderByDescending(e => e.Relevancia);
        }

        public IEnumerable<BusquedaRelevanciaModel> Get(string fecha, int carrera, string curso)
        {
            IEnumerable<ENTRADA> entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera == carrera & e.Curso == curso).Where(e => e.FechaCrear <= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            List<BusquedaRelevanciaModel> aux = new List<BusquedaRelevanciaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets = apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
                var cantidadcomentarios = apiComentarios.getAllComentarios().GroupBy(e => e.IdEntrada).Select(group => Tuple.Create(group.Key, group.Count()));
                int ccomentarios = cantidadcomentarios.Select(e => e.Item2).Max();
                int Numcomentarios = apiComentarios.getAllComentarios().Where(e => e.IdEntrada == entrada.IdEntrada).Count();


                try
                {
                    calificacion = apiCalificacion.getAllCalificaciones().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Calificacion).Average();
                }
                catch
                {
                    calificacion = 0.0;
                }

                int relevancia = (int)(30 * (calificacion / 10) + 20 * (Numcomentarios / ccomentarios));
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
                aux.Add(new BusquedaRelevanciaModel
                {

                    Vistas = entrada.Vistas,
                    Carrera = entrada.Carrera,
                    Curso = entrada.Curso,
                    Tema = entrada.Tema,
                    FechaCrear = entrada.FechaCrear,
                    FechaMod = entrada.FechaMod,
                    IdEntrada = entrada.IdEntrada,
                    Autores = autoreslist,
                    NumComentarios = Numcomentarios,
                    CalificacionProm = calificacion,
                    Relevancia = relevancia
                });

            }
            return aux.OrderByDescending(e => e.Relevancia);
        }

        public IEnumerable<BusquedaRelevanciaModel> Get(string fecha, int carrera, string curso, int tema)
        {
            IEnumerable<ENTRADA> entradas = apiEntradas.getAllEntradas().Where(e => e.Carrera== carrera & e.Curso == curso & e.Tema==tema).Where(e => e.FechaCrear <= Convert.ToDateTime(fecha)).Where(e => e.Visible == true).OrderByDescending(e => e.FechaCrear);
            List<BusquedaRelevanciaModel> aux = new List<BusquedaRelevanciaModel>();
            foreach (ENTRADA entrada in entradas)
            {
                IEnumerable<int> carnets = apiAutor.getAllAutoresEntrada().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Carnet);
                IEnumerable<ESTUDIANTE> autores = apiEstudiante.getAllEstudiantes().Where(e => carnets.Contains(e.Carnet));
                List<ESTUDIANTE> autoreslist = new List<ESTUDIANTE>();
                double calificacion;
                var cantidadcomentarios = apiComentarios.getAllComentarios().GroupBy(e => e.IdEntrada).Select(group => Tuple.Create(group.Key, group.Count()));
                int ccomentarios = cantidadcomentarios.Select(e => e.Item2).Max();
                int Numcomentarios = apiComentarios.getAllComentarios().Where(e => e.IdEntrada == entrada.IdEntrada).Count();


                try
                {
                    calificacion = apiCalificacion.getAllCalificaciones().Where(e => e.IdEntrada == entrada.IdEntrada).Select(e => e.Calificacion).Average();
                }
                catch
                {
                    calificacion = 0.0;
                }

                int relevancia = (int)(30 * (calificacion / 10) + 20 * (Numcomentarios / ccomentarios));
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
                aux.Add(new BusquedaRelevanciaModel
                {

                    Vistas = entrada.Vistas,
                    Carrera = entrada.Carrera,
                    Curso = entrada.Curso,
                    Tema = entrada.Tema,
                    FechaCrear = entrada.FechaCrear,
                    FechaMod = entrada.FechaMod,
                    IdEntrada = entrada.IdEntrada,
                    Autores = autoreslist,
                    NumComentarios = Numcomentarios,
                    CalificacionProm = calificacion,
                    Relevancia = relevancia
                });

            }
            return aux.OrderByDescending(e => e.Relevancia);
        }
    }
}