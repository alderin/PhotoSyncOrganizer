using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServicioBackup
{
    internal class Organizer
    {
        public String CarpetaOrigenImagenes { get; set; }

        public String CarpetaDestinoImagenes { get; set; }



        public String CrearCarpeta(DateTime fecha)
        {
            string path = CarpetaDestinoImagenes + "\\" + fecha.Year + "-" + fecha.Month.ToString("D2") + "\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        public void Renombrar()
        {
            var lista = Directory.EnumerateFiles(CarpetaOrigenImagenes, "*.*", SearchOption.AllDirectories);
            foreach (var archivo in lista)
            {
                var destino = ComprobarExistencia(archivo);
                Console.WriteLine("Path: " + Path.GetDirectoryName(archivo) + " Archivo: " + Path.GetFileName(archivo) + "NuevoNombre= " + destino);
            }
        }
        private String ComprobarExistencia(string file)
        {
            var archivoExiste = CrearCarpeta(Directory.GetLastWriteTime(file)) + File.GetCreationTime(file).ToString("yyyy-MM-dd hh.mm.ss") + Path.GetExtension(file);
            if (File.Exists(archivoExiste))
            {
                archivoExiste = ComprobarExistencia(CrearCarpeta(Directory.GetLastWriteTime(file)) + File.GetCreationTime(file).ToString("yyyy-MM-dd hh.mm.ss") + "-"+Path.GetExtension(file));
            }
            return archivoExiste;
        }
        public void MoverACarpeta(string file)
        {
            String destino = CrearCarpeta(Directory.GetLastWriteTime(file)) + "\\";// +"\\" + File.GetCreationTime(file).ToString("yyyy-mm-dd hh.mm.ss");
            string path = destino + Path.GetFileName(file);

            File.Move(file, path);
        }
        public void MoverArchivos()
        {
            var lista = Directory.EnumerateFiles(CarpetaOrigenImagenes);
            foreach (string archivo in lista)
            {
                MoverACarpeta(archivo);
            }
        }
    }
}