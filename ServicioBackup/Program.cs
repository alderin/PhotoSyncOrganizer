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
        /// <summary>
        /// Aplicación que se encarga de mover las fotos más viejas de un mes de una carpeta a otra.
        /// </summary>
        /// <param name="args">Acepta como argumentos la carpeta origen y la destino</param>
        static void Main(string[] args)
        {
         //   Organizer org = new Organizer { CarpetaOrigenImagenes = @"C:\Users\Alejandro\Pictures\Movil", CarpetaDestinoImagenes = @"C:\Prueba2" };
            OrganizadorImagenes org = new OrganizadorImagenes { CarpetaOrigenImagenes = args[0], CarpetaDestinoImagenes = args[1] };
      
            org.Ejecutar();
            //org.MoverArchivos();
        }


    }
}
