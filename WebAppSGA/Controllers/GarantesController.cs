using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSGA.Controllers
{
    public class GarantesController : Controller
    {
        private readonly PrestamoDB db;

        public GarantesController(PrestamoDB db)
        {
            this.db = db;
        }
        //Listar los garantes-----------------------------
        public IActionResult Index()
        {
            IEnumerable<Garante> listaGarantes = db.Garantes;
            return View(listaGarantes);
        }
        //Creación de garantes-----------------------------
        //Presenta el formulario vacio listo para crear una entidad
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Guarda un garante
        [HttpPost]
        public IActionResult Create(Garante garante)
        {
            db.Garantes.Add(garante);
            db.SaveChanges();

            TempData["mensaje"] = $"El garante {garante.NombreG} ha sido creado exitosamnete";

            return RedirectToAction("Index");
        }

        //Edición de garante
        // Presenta el formulario lleno con el garante seleccionado
         [HttpGet]
        public IActionResult Edit(int id)
        {
            //Consultar el garante por medio de Id
            Garante garante = db.Garantes.Find(id);

            return View(garante);
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
