﻿using System;
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
            String carpeta = @"C:\Pruebas";
            var lista = Directory.EnumerateFiles(carpeta);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            foreach (var archivo in lista)
            {
                Console.WriteLine(File.GetCreationTime(archivo));
                
            }
            Console.Read();
        }

      
    }
}
