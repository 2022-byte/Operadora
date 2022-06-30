using Microsoft.AspNetCore.Mvc;
using Operadora.Data;
using Operadora.Models;

namespace Operadora.Controllers
{
    public class ClienteController :   Controller
    {
        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> objClienteList = _db.Clientes.ToList();


            return View(objClienteList);
        }
       

        // get action
        public IActionResult Create()
        {


            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente obj)
        {
            if (obj.NomeCliente == obj.Email.ToString())
            {
                ModelState.AddModelError("NomeCliente", "O nome do Cliente é igual ao endereço de email. ");
            }
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Cliente");

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

            var clienteFromDb = _db.Clientes.Find(id);
            //var pacoteFromDbFirst = _db.Pacotes.FirstOrDefault(u => u.IdPacote==id);
            //var pacoteFromDbSingle = _db.Pacotes.SingleOrDefault(u => u.IdPacote == id);

            if (clienteFromDb == null)
            {
                return NotFound();
            }

            return View(clienteFromDb);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente obj)
        {
            if (obj.NomeCliente == obj.Email.ToString())
            {
                ModelState.AddModelError("NomeCliente", "O nome do Cliente é igual ao endereço de email. ");
            }
            if (ModelState.IsValid)
            {
                _db.Clientes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Cliente");

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

            var clienteFromDb = _db.Clientes.Find(id);
            //var pacoteFromDbFirst = _db.Pacotes.FirstOrDefault(u => u.IdPacote==id);
            //var pacoteFromDbSingle = _db.Pacotes.SingleOrDefault(u => u.IdPacote == id);

            if (clienteFromDb == null)
            {
                return NotFound();
            }

            return View(clienteFromDb);

        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Clientes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Clientes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");




        }
    }
}
