using Microsoft.AspNetCore.Mvc;
using ModeloDB;
using ModeloProyecto.Entidades;
using System.Collections;
using System.Collections.Generic;

namespace WebAppSG.Controllers
{
    public class BancosController : Controller
    {
        private readonly PrestamoDB db;

        public BancosController (PrestamoDB db)
        {
            this.db = db;
        }
        //Listar los bancos-------------------------------------
        public IActionResult Index()
        {
            IEnumerable<Banco> listaBancos = db.Bancos;

            return View(listaBancos);
        }

        //Creación de bancos-----------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Banco banco)
        {
            //Grabar el garante
            db.Bancos.Add(banco);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
