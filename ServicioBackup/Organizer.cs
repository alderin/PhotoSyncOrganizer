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



        private String CrearCarpeta(DateTime date)
        {
            string path = CarpetaDestinoImagenes + "\\" + date.Year + "-" + date.Month.ToString("D2") + "\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        public void Ejecutar()
        {
            var lista = Directory.EnumerateFiles(CarpetaOrigenImagenes, "*.*", SearchOption.AllDirectories);
            foreach (var archivo in lista)
            {
                if (MasViejaDeUnMes(archivo))
                {
                    var destino = CalcularPathDestino(archivo);
                    CopiarFichero(archivo, destino);
                    Console.WriteLine( destino);
                }
            }
            //File.CreateText(CarpetaDestinoImagenes + DateTime.Now.ToString() + ".txt");
        }
        private string CalcularPathDestino(string file)
        {
            string fechaArchivo = File.GetLastWriteTime(file).ToString("yyyy-MM-dd HH.mm.ss");
            return CrearCarpeta(Directory.GetLastWriteTime(file)) + fechaArchivo + Path.GetExtension(file);
        }
        private void CopiarFichero(string source, string destinationPath)
        {
            string destinationPathRenamed = ComprobarExistenciaFichero(destinationPath);
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

        private String ComprobarExistenciaFichero(string file)
        {
            if (File.Exists(file))
            {
                file = ComprobarExistenciaFichero(Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + "-" + Path.GetExtension(file));
            }
            return file;
        }
        private bool MasViejaDeUnMes(string file)
        {
            DateTime fechaArchivo = File.GetLastWriteTime(file);
            TimeSpan diferencia = DateTime.Now - fechaArchivo;
            return diferencia > new TimeSpan(31, 0, 0, 0, 0);
        }
    }
}