using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace apisBlog.Models
{
    public class FileHandler
    {
        private static string urlDB = "D://OneDrive//Escritorio//fileDB";

        public static string SaveFile(FileModel inFile, int IdArchivoEntrada)
        {
            string content = inFile.file;
            byte[] data = Encoding.ASCII.GetBytes(content);
            string name = IdArchivoEntrada.ToString() + ".jpg";
            try
            {
                using (var fs = new FileStream(urlDB + name, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                    return name;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return null;
            }
        }

    }
}