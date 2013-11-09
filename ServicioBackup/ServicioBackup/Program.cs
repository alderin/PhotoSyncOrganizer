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
         //   Organizer org = new Organizer { CarpetaOrigenImagenes = @"C:\Users\Alejandro\Pictures\Movil", CarpetaDestinoImagenes = @"C:\Prueba2" };
            OrganizadorImagenes org = new OrganizadorImagenes { CarpetaOrigenImagenes = args[0], CarpetaDestinoImagenes = args[1] };
      
            org.Renombrar();
            //org.MoverArchivos();
        }


    }
}
