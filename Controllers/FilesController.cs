using apisBlog.Models;
using apisBlog.Models.ApisI;
using apisBlog.Models.ApisImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace apisBlog.Controllers
{
    public class FilesController : ApiController
    {
        ArchivoEntradaI apiArchivos = new ArchivoEntradaImpl();
        /// <summary>
        /// /Metodo para manejo de archivos
        /// </summary>
        /// <param name="IdEntrada"></param>
        /// <param name="file"></param>
        // GET: Files
        public void setFile(int IdEntrada,[FromBody] FileModel file)
        {
            ARCHIVOENTRADA nuevo = new ARCHIVOENTRADA{IdEntrada = IdEntrada };
            apiArchivos.setArchivoEntrada(nuevo);
            nuevo = apiArchivos.getAllArchivosEntrada().Last();
            string fileName = FileHandler.SaveFile(file, nuevo.IdArchivoEntrada);
            nuevo.Path = fileName;
            apiArchivos.modEntrada(nuevo);
        }
    }
}