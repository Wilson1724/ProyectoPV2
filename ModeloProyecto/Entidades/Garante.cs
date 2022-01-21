using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloProyecto.Entidades
{
    public class Garante
    {
        public int GaranteId { get; set; }
        public string NombreG { get; set; }
        public string ApellidoG { get; set; }

        public int CedulaG { get; set; }
        public int EdadG { get; set; }
        public string DireccionG { get; set; }
        public int IngresosAnualesG { get; set; }
        
        
        public MicroEmprendimiento MicroEmprendimientoG { get; set; }
        public int MicroEmprendimientoId{ get; set; }
    }
}
