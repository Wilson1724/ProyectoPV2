using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace WebAppSG.Controllers
{
    public class MicroemprendimientosController : Controller
    {
        private readonly PrestamoDB db;

        public MicroemprendimientosController (PrestamoDB db)
        {
            this.db = db;
        }
        //Listar los garantes---------------------------
        public IActionResult Index()
        {
            IEnumerable<MicroEmprendimiento> listaMicroemprendimientos = db.Microemprendimientos;

            return View(listaMicroemprendimientos);
        }

        //Creación de microemprendimientos-----------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MicroEmprendimiento microemprendimiento)
        {
            //Grabar el garante
            db.Microemprendimientos.Add(microemprendimiento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
