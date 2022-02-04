using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSGA.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly PrestamoDB db;

        public PrestamosController(PrestamoDB db)
        {
            this.db = db;
        }
        //Listar los prestamos-----------------------------
        public IActionResult Index()
        {
            IEnumerable<Prestamo> listaPrestamos = db.Prestamos;
            return View(listaPrestamos);
        }
        //Creación de prestamos-----------------------------
        //Presenta el formulario vacio listo para crear una entidad
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Guarda un prestamo
        [HttpPost]
        public IActionResult Create(Prestamo prestamo)
        {
            db.Prestamos.Add(prestamo);
            db.SaveChanges();

            TempData["mensaje"] = $"El prestamo {prestamo.PrestamoId} ha sido creado exitosamnete";

            return RedirectToAction("Index");
        }

        //Edición de prestamo
        // Presenta el formulario lleno con el prestamo seleccionado
         [HttpGet]
        public IActionResult Edit(int id)
        {
            //Consultar el prestamo por medio de Id
            Prestamo prestamo = db.Prestamos.Find(id);

            return View(prestamo);
        }

        // Actualiza un garante
        [HttpPost]
        public IActionResult Edit(Garante garante)
        {
            db.Garantes.Update(garante);
            db.SaveChanges();

            TempData["mensaje"] = $"El garante {garante.NombreG} ha sido actualizado exitosamnete";

            return RedirectToAction("Index");
        }


        //Borrado de Garante
        // Presenta el formulario lleno con el garante seleccionado
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Consultar el garante por medio de Id
            Garante garante = db.Garantes.Find(id);

            return View(garante);
        }

        // Borra un garante
        [HttpPost]
        public IActionResult Delete(Garante garante)
        {
            db.Garantes.Remove(garante);
            db.SaveChanges();

            TempData["mensaje"] = $"El garante {garante.NombreG} ha sido borrada exitosamnete";

            return RedirectToAction("Index");
        }
    }
}
