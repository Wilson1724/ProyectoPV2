using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloProyecto.Entidades
{
    public class Banco : IEntidad
    {
        public int BancoId { get; set; }
        public string Sucursal { get; set; }
        public string Encargado { get; set; }
        public List<Prestamo> Prestamos { get; set; }
        public List<Microempresario> Microempresarios { get; set; }
    }
}
