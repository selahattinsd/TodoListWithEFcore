using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoWithEFCore.Models;

namespace TodoWithEFCore.Controllers
{
  
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //" Server = 104.247.162.242\\MSSQLSERVER2017;Database=akadem58_sd;User Id = akadem58_sd; Password=Hfoe27!96;"
            _logger = logger;
        }

        public IActionResult Index()
        {
            using var db = new TodoAppContext();


            return View();
        }

        public IActionResult List()
        {
            using var db = new TodoAppContext();
            
            return View(db.Todos.ToList());

        }

        public IActionResult Create() 
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Todo save)
        {
            using var db = new TodoAppContext();
            db.Todos.Add(save);
            db.SaveChanges();
            
            return RedirectToAction("List");

        }
        public IActionResult Edit(int id)
        {
            using var db = new TodoAppContext();
            return View(db.Todos.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(int id,Todo todo)
        {
            using var db = new TodoAppContext();
            db.Entry(todo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
            
        }
        public IActionResult Delete(int id)
        {
            using var db = new TodoAppContext();
            return View(db.Todos.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(int id, Todo Sil) {
            using var db = new TodoAppContext();
            Sil = db.Todos.Where(x => x.Id == id).FirstOrDefault();
            db.Todos.Remove(Sil);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}