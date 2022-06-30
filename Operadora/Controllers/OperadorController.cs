using Microsoft.AspNetCore.Mvc;
using Operadora.Data;
using Operadora.Models;

namespace Operadora.Controllers
{
    public class OperadorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OperadorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Operador> objOperadorList = _db.Operadors.ToList();

            return View(objOperadorList);
        }

        // get action
        public IActionResult Create()
        {


            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Operador obj)
        {
            if (obj.NomeOperador == obj.EmailOperador.ToString())
            {
                ModelState.AddModelError("NomeOperador", "O nome do Operador é igual ao endereço de email. ");
            }
            if (ModelState.IsValid)
            {
                _db.Operadors.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Operador");

            }

            return View(obj);
        }

        // get action
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var operadorFromDb = _db.Operadors.Find(id);
            //var pacoteFromDbFirst = _db.Pacotes.FirstOrDefault(u => u.IdPacote==id);
            //var pacoteFromDbSingle = _db.Pacotes.SingleOrDefault(u => u.IdPacote == id);

            if (operadorFromDb == null)
            {
                return NotFound();
            }

            return View(operadorFromDb);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Operador obj)
        {
            if (obj.NomeOperador == obj.EmailOperador.ToString())
            {
                ModelState.AddModelError("NomeOperador", "O nome do Operador é igual ao endereço de email. ");
            }
            if (ModelState.IsValid)
            {
                _db.Operadors.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Operador");

            }

            return View(obj);
        }
        // get action
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var operadorFromDb = _db.Operadors.Find(id);
            //var pacoteFromDbFirst = _db.Pacotes.FirstOrDefault(u => u.IdPacote==id);
            //var pacoteFromDbSingle = _db.Pacotes.SingleOrDefault(u => u.IdPacote == id);

            if (operadorFromDb == null)
            {
                return NotFound();
            }

            return View(operadorFromDb);

        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Operadors.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Operadors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");




        }
    }
}

