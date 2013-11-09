using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioBackup
{
    class Organizer
    {
        public void CrearCarpeta(DateTime fecha, string actual)
        {
            string path = actual + "\\" + fecha.Year + "-" + fecha.Month;
        }
    }
}
