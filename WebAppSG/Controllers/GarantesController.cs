using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace WebAppSG.Controllers
{
    public class GarantesController : Controller
    {
        private readonly PrestamoDB db;

        public GarantesController (PrestamoDB db)
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Garante garante)
        {
            //Grabar el garante
            db.Garantes.Add(garante);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
