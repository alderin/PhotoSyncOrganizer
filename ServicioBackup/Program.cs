using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioBackup
{
    internal class Program
    {
        /// <summary>
        /// Aplicación que se encarga de mover las fotos más viejas de un mes de una carpeta a otra.
        /// </summary>
        /// <param name="args">Acepta como argumentos la carpeta origen y la destino</param>
        private static void Main(string[] args)
        {
            int dias;
            // Organizer org = new Organizer { CarpetaOrigenImagenes =
            // @"C:\Users\Alejandro\Pictures\Movil", CarpetaDestinoImagenes = @"C:\Prueba2" };
            if (args.Length == 3)
            {
                if (int.TryParse(args[2], out dias))
                {
                    OrganizadorImagenes org = new OrganizadorImagenes { CarpetaOrigenImagenes = args[0], CarpetaDestinoImagenes = args[1], IntervaloImagenes = new TimeSpan(dias, 0, 0, 0) };
                    org.Ejecutar();
                }
            }
            else if (args.Length == 2)
            {
                OrganizadorImagenes org = new OrganizadorImagenes { CarpetaOrigenImagenes = args[0], CarpetaDestinoImagenes = args[1], IntervaloImagenes = new TimeSpan(30, 0, 0, 0) };
                org.Ejecutar();
            }
            //org.MoverArchivos();
        }
    }
}
