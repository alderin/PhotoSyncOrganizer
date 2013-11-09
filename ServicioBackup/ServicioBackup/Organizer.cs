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

        public List<DateTime> ListarFechas()
        {
            var lista = Directory.EnumerateFiles(CarpetaOrigenImagenes);
            List<DateTime> listaFechas = new List<DateTime>();
            foreach (var archivo in lista)
            {
                listaFechas.Add(File.GetCreationTime(archivo));
            }
            return listaFechas;
        }

        public void CrearCarpeta(DateTime fecha, string actual)
        {
            string path = actual + "\\" + fecha.Year + "-" + fecha.Month;
        }
    }
}