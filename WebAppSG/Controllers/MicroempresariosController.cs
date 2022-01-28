using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace WebAppSG.Controllers
{
    public class MicroempresariosController : Controller
    {
        private readonly PrestamoDB db;

        public MicroempresariosController (PrestamoDB db)
        {
            this.db = db;
        }
        //Listar los garantes---------------------------------
        public IActionResult Index()
        {
            IEnumerable<Microempresario> listaMicroempresarios = db.Microempresarios;

            return View(listaMicroempresarios);
        }

        //Creación de microempresarios-----------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Microempresario microempresario)
        {
            //Grabar el garante
            db.Microempresarios.Add(microempresario);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
