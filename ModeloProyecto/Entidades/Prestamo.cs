using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloProyecto.Entidades
{
    public enum PrestamoEstado { Pendiente, Aprobado, Rechazado}
    public class Prestamo 
    {
        public int PrestamoId { get; set; }
        public double Cantidad { get; set; }
        public int Plazo { get; set; }
        public int Interes { get; set; }
        public double CuotaMensual { get; set; }
        public double TotalDeuda { get; set; }
        public  PrestamoEstado Estado { get; set; }
        public int BancoId { get; set; }
        public Banco BancoPres { get; set; }
        public int MicroempresarioId { get; set; }
        public Microempresario MicroempresarioPres { get; set; }
    }
}
