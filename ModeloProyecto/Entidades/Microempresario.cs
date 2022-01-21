using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloProyecto.Entidades
{
    public class Microempresario
    {
        public int MicroempresarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int Cedula { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int IngresosAnuales { get; set; }
        public int BancoId { get; set; }
        public Banco BancoM { get; set; }
        
        public MicroEmprendimiento MicroemprendimientoM { get; set; }
        public int MicroEmprendimientoId { get; set; }

        public Prestamo PrestamoM { get; set; }
    }
}
