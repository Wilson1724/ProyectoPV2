using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace WebAppSG.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly PrestamoDB db;

        public PrestamosController (PrestamoDB db)
        {
            this.db = db;
        }
        //Listar los prestamos----------------------------------
        public IActionResult Index()
        {
            IEnumerable<Prestamo> listaPrestamos = db.Prestamos;

            return View(listaPrestamos);
        }

        //Creación de prestamos-----------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Prestamo prestamo)
        {
            //Grabar el garante
            db.Prestamos.Add(prestamo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
