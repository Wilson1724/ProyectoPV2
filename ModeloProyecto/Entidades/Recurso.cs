using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloProyecto.Entidades
{
    public class Recurso
    {
        public int MontoMinimo { get; set; }
        public int MontoMaximo { get; set; }
        public Prestamo PrestamoActual { get; set; }
        public int PrestamoActualId {get;set;}


    }
}
