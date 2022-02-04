using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grabar grabar = new Grabar();
            grabar.DatosIni();

            using (var db = PrestamoDBBuilder.Crear())
            {
                //Operación de proyección
                var listaGarantes = db.Garantes
                    .Select(garante =>
                    new
                    {
                        garante.GaranteId,
                        garante.NombreG
                    });
                foreach(var garante in listaGarantes)
                {
                    Console.WriteLine(garante.GaranteId + " " + garante.NombreG);
                }
            }
        }
    }
}
