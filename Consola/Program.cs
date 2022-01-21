using ModeloProyecto.Entidades;
using System;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco Quito = new Banco()
            {
                Sucursal = "Quito Norte",
                Encargado = "Diego Martinez",
                Prestamos = new List<Prestamo> () { new Prestamo() { } }
            };
            Garante Juan = new Garante()
            {
                NombreG = "Dario",
                ApellidoG = "Rodriguez",
                CedulaG = 1738723161,
                EdadG = 24,
                DireccionG = "San Sebastian",
                IngresosAnualesG = 3000,
                
            };
            Microempresario Ramiro = new Microempresario()
            {
                Nombre = "Ramiro",
                Apellido = "Perez",
                Cedula = 1748722162,
                Edad = 27,
                Direccion = "San Marcos",
                IngresosAnuales = 2000,
                BancoM = new Banco(),
                MicroemprendimientoM = new MicroEmprendimiento(),
                PrestamoM = new Prestamo()
            };
            MicroEmprendimiento LocalRopa = new MicroEmprendimiento()
            {
                NombreE = "Ropa Rodriguez",
                Tipo = "Comercial",
                Descripcion = "Local Comercial de camisetas, pantalones y chompas para hombre y mujer",
                Ciudad = "Quito",
                CreditoNecesario = 2000,
                Ganancias = 5000,
                MicroempresarioEmpr = new Microempresario()

            };
            Prestamo Tipo1 = new Prestamo()
            {
                Cantidad= 1296 ,
                Plazo = 12,
                Interes = 5,
                CuotaMensual = 162,
                TotalDeuda = 1944,
                BancoPres = new Banco(),
                MicroempresarioPres = new Microempresario ()

            };
        }
    }
}
