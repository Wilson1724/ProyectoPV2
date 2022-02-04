﻿using CargaDatos;
using ModeloDB;
using ModeloProyecto.Entidades;
using System;
using System.Collections.Generic;
using static CargaDatos.DatosIniciales;

namespace Consola
{
    public class Grabar
    {
        public void DatosIni()
        {
            DatosIniciales datos = new DatosIniciales();
            var listas = datos.Carga();

            // Extraer el diccionario de las listas

            var listaPrestamos = (List<Prestamo>)listas[ListasTipo.Prestamos];
            var listaBancos = (List<Banco>)listas[ListasTipo.Bancos];
            var listaGarantes = (List<Garante>)listas[ListasTipo.Garantes];
            var listaMicoEmpresarios = (List<Microempresario>)listas[ListasTipo.MicroEmpresarios];
            var listaMicroEmprendimientos = (List<MicroEmprendimiento>)listas[ListasTipo.MicroEmprendimientos];

            using (PrestamoDB db = PrestamoDBBuilder.Crear())
            {
                //Grabar
                db.PreparaDB();
                db.Prestamos.AddRange(listaPrestamos);
                db.Bancos.AddRange(listaBancos);
                db.Garantes.AddRange(listaGarantes);
                db.Microempresarios.AddRange(listaMicoEmpresarios);
                db.Microemprendimientos.AddRange(listaMicroEmprendimientos);
                db.SaveChanges();
            }
        }
    }
}
