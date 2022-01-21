using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloProyecto.Entidades
{
    public class Solicitud
    {
        public MicroEmprendimiento MicroEmprendimientoSoli { get; set; }
        public int MicroEmprendimientoId { get; set; }

        public Prestamo PrestamoSoli;
        public int PrestamoId { get; set; }
    }
}
