using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServicioBackup
{
    internal class OrganizadorImagenes
    {
        public String CarpetaOrigenImagenes { get; set; }

        public String CarpetaDestinoImagenes { get; set; }



        public String CrearCarpeta(DateTime date)
        {
            string path = CarpetaDestinoImagenes + "\\" + date.Year + "-" + date.Month.ToString("D2") + "\\";
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
                if (MasDeUnMes(archivo))
                {
                    var destino = CalcularPathDestino(archivo);
                    CopiarFichero(archivo, destino);
                    Console.WriteLine("Path: " + Path.GetDirectoryName(archivo) + " Archivo: " + Path.GetFileName(archivo) + "NuevoNombre= " + destino);
                }
            }
        }
        private string CalcularPathDestino(string file)
        {
            string fechaArchivo = File.GetLastWriteTime(file).ToString("yyyy-MM-dd HH.mm.ss");
            return CrearCarpeta(Directory.GetLastWriteTime(file)) + fechaArchivo + Path.GetExtension(file);
        }
        private void CopiarFichero(string source, string destinationPath)
        {
            string destinationPathRenamed = ComprobarExistencia(destinationPath);
            if (File.Exists(destinationPath))
            {
                File.Move(source, destinationPathRenamed);
            }
            else
            {
                try
                {
                    File.Move(source, destinationPath);
                }
                catch (IOException ex)
                {
                    // destinationPath file already exists
                    File.Move(source, destinationPathRenamed);
                }
            }
        }

        private String ComprobarExistencia(string file)
        {
            if (File.Exists(file))
            {
                file = ComprobarExistencia(Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + "-" + Path.GetExtension(file));
            }
            return file;
        }
        public bool MasDeUnMes(string file)
        {
            DateTime fechaArchivo = File.GetLastWriteTime(file);
            TimeSpan diferencia = DateTime.Now - fechaArchivo;
            return diferencia > new TimeSpan(31, 0, 0, 0, 0);
        }
    }
}