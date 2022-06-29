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
            IEnumerable<Pacote> objPacoteList = _db.Pacotes.ToList();

            return View(objPacoteList);
        }
    }
}
