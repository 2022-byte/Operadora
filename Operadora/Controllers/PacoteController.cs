using Microsoft.AspNetCore.Mvc;
using Operadora.Data;
using Operadora.Models;

namespace Operadora.Controllers
{
    public class PacoteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PacoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Pacote> objPacoteList = _db.Pacotes.ToList();

            return View(objPacoteList);
        }

        // get action
        public IActionResult Create()
        {


            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pacote obj)
        {
            if (obj.NomePacote == obj.ConteudoPacote.ToString())
            {
                ModelState.AddModelError("NomePacote", "O nome do conteudo é igual ao nome do pacote. ");
            }
            if (ModelState.IsValid)
            {
                _db.Pacotes.Add(obj);
                _db.SaveChanges();
                TempData["Sucesso"] = "Pacote Criado com Sucesso";
                return RedirectToAction("Index", "Pacote");

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

            var pacoteFromDb = _db.Pacotes.Find(id);
            //var pacoteFromDbFirst = _db.Pacotes.FirstOrDefault(u => u.IdPacote==id);
            //var pacoteFromDbSingle = _db.Pacotes.SingleOrDefault(u => u.IdPacote == id);

            if (pacoteFromDb == null)
            {
                return NotFound();
            }

            return View(pacoteFromDb);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pacote obj)
        {
            if (obj.NomePacote == obj.ConteudoPacote.ToString())
            {
                ModelState.AddModelError("NomePacote", "O nome do conteudo é igual ao nome do pacote. ");
            }
            if (ModelState.IsValid)
            {
                _db.Pacotes.Update(obj);
                _db.SaveChanges();
                TempData["Sucesso"] = "Pacote update com Sucesso";
                return RedirectToAction("Index", "Pacote");

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

            var pacoteFromDb = _db.Pacotes.Find(id);
            //var pacoteFromDbFirst = _db.Pacotes.FirstOrDefault(u => u.IdPacote==id);
            //var pacoteFromDbSingle = _db.Pacotes.SingleOrDefault(u => u.IdPacote == id);

            if (pacoteFromDb == null)
            {
                return NotFound();
            }

            return View(pacoteFromDb);

        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Pacotes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Pacotes.Remove(obj);
                _db.SaveChanges();
                TempData["Sucesso"] = "Pacote deleted com Sucesso";
            return RedirectToAction("Index");

            

            
        }
    }
}
