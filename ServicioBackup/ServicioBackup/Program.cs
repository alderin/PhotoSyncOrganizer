using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ServicioBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            Organizer org = new Organizer { CarpetaOrigenImagenes = @"C:\Pruebas" };
            org.ListarFechas();
            org.CrearCarpeta(DateTime.Now, org.CarpetaOrigenImagenes);
        }

      
    }
}
