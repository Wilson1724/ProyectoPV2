using ModeloProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDatos
{
    public class DatosIniciales
    {
        public enum ListasTipo{
            Prestamos, Bancos, Garantes,
            MicroEmpresarios, MicroEmprendimientos,
            Configuracion
        }
        public Dictionary<ListasTipo,object> Carga()
        {

            //-------------------------------------------------
            //Lista de Prestamos
            //-------------------------------------------------
            #region
            Prestamo Tipo1 = new Prestamo()
            {
                Cantidad = 1296,
                Plazo = 12,
                Interes = 5,
                CuotaMensual = 162,
                TotalDeuda = 1944,
                Estado = PrestamoEstado.Aprobado
                

            };
            Prestamo Tipo2 = new Prestamo()
            {
                Cantidad = 1700,
                Plazo = 24,
                Interes = 4,
                CuotaMensual = 103.12,
                TotalDeuda = 2475,
                Estado = PrestamoEstado.Pendiente
                

            };
            Prestamo Tipo3 = new Prestamo()
            {
                Cantidad = 5000,
                Plazo = 36,
                Interes = 3,
                CuotaMensual = 187.50,
                TotalDeuda = 6.750,
                Estado = PrestamoEstado.Rechazado
                
            };

            List<Prestamo> listaPrestamos = new List<Prestamo>()
            {
                Tipo1,Tipo2,Tipo3
            };
            #endregion
            
            //-------------------------------------------------
            //Configuración
            //-------------------------------------------------
            #region
            Configuracion config = new Configuracion()
            {
                MontoMaximo = 15000,
                BancoNombre = "Banco Pichincha"

            };
            //Actualiza Configuración
            config.PrestamoActual = Tipo1;
            #endregion

            //-------------------------------------------------
            //Lista de Bancos
            //------------------------------------------------- 
            #region
            Banco banQuito = new Banco()
            {
                Sucursal = "Quito Norte",
                Encargado = "Diego Martinez"
            };
            Banco banGuayaquil = new Banco()
            {
                Sucursal = "Malecon 2000",
                Encargado = "María Ferandez"
            };
            Banco banCuenca = new Banco()
            {
                Sucursal = "Cuenca Sur",
                Encargado = "Pamela Mercedes"
            };

            List<Banco> listaBancos = new List<Banco>()
            {
                banQuito,banGuayaquil,banCuenca
            };
            #endregion

            //-------------------------------------------------
            //Lista de Garantes
            //-------------------------------------------------
            #region
            Garante garJuan = new Garante()
            {
                NombreG = "Dario",
                ApellidoG = "Rodriguez",
                CedulaG = 1738723161,
                EdadG = 24,
                DireccionG = "San Sebastian",
                IngresosAnualesG = 3000

            };
            Garante garPedro = new Garante()
            {
                NombreG = "Pedro",
                ApellidoG = "Fernandez",
                CedulaG = 1738723162,
                EdadG = 27,
                DireccionG = "San Marcos",
                IngresosAnualesG = 5000

            };
            Garante garPablo = new Garante()
            {
                NombreG = "Pablo",
                ApellidoG = "Marmol",
                CedulaG = 1738723163,
                EdadG = 29,
                DireccionG = "La Colón",
                IngresosAnualesG = 6000

            };

            List<Garante> listaGarantes = new List<Garante>()
            {
                garJuan,garPablo,garPedro
            };
            #endregion

            //-------------------------------------------------
            //Lista de MicroEmpresarios
            //-------------------------------------------------
            #region
            Microempresario micRamiro = new Microempresario()
            {
                Nombre = "Ramiro",
                Apellido = "Perez",
                Cedula = 1748722162,
                Edad = 27,
                Direccion = "San Marcos",
                IngresosAnuales = 2000

            };
            Microempresario micRodrigo = new Microempresario()
            {
                Nombre = "Rodrigo",
                Apellido = "Reyes",
                Cedula = 1748722153,
                Edad = 29,
                Direccion = "San Juan",
                IngresosAnuales = 4000

            };
            Microempresario micRaquel = new Microempresario()
            {
                Nombre = "Raquel",
                Apellido = "Gomez",
                Cedula = 1748723164,
                Edad = 27,
                Direccion = "Mañosca",
                IngresosAnuales = 6000



            };

            List<Microempresario> listaMicroempresarios = new List<Microempresario>()
            {
                micRamiro,micRaquel,micRodrigo
            };
            #endregion

            //-------------------------------------------------
            //Lista de MicroEmprendimientos
            //-------------------------------------------------
            #region
            MicroEmprendimiento emprLocalRopa = new MicroEmprendimiento()
            {
                NombreE = "Ropa Rodriguez",
                Tipo = "Comercial",
                Descripcion = "Local Comercial de camisetas, pantalones y chompas para hombre y mujer",
                Ciudad = "Quito",
                CreditoNecesario = 2000,
                Ganancias = 5000


            };
            MicroEmprendimiento emprRestaurante = new MicroEmprendimiento()
            {
                NombreE = "Hot Dogs Reyes",
                Tipo = "Comercial",
                Descripcion = "Restaurante de comida rápida",
                Ciudad = "Quito",
                CreditoNecesario = 4000,
                Ganancias = 8000


            };
            MicroEmprendimiento emprServicioTecnico = new MicroEmprendimiento()
            {
                NombreE = "Tecnicos Gomez",
                Tipo = "Comercial",
                Descripcion = "Servicio técnico para computadoras y celulares",
                Ciudad = "Quito",
                CreditoNecesario = 3000,
                Ganancias = 6200
 

            };

            List<MicroEmprendimiento> listaMicroEmprendimientos = new List<MicroEmprendimiento>()
            {
                emprLocalRopa,emprRestaurante,emprServicioTecnico
            };
            #endregion

            //-------------------------------------------------
            //Diccionario contiene todas las listas
            //-------------------------------------------------
            Dictionary<ListasTipo, object > dicListaDatos = new Dictionary<ListasTipo, object >()
            {
                { ListasTipo.MicroEmprendimientos, listaMicroEmprendimientos },
                { ListasTipo.Prestamos, listaPrestamos }, 
                { ListasTipo.Bancos, listaBancos },
                { ListasTipo.Garantes, listaGarantes },
                { ListasTipo.MicroEmpresarios, listaMicroempresarios }
                
            };

            return dicListaDatos;
        }
    }
}
