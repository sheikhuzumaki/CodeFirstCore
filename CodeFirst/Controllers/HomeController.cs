using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Employee> obj = _db.Employees.ToList();
            return View(obj);
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int Id)
        {
            Employee obj = _db.Employees.Find(Id);
            return View(obj);
        }
        public IActionResult Delete(int Id)
        {
            Employee obj = _db.Employees.Find(Id);
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult StoreProcedure(int Id)
        {
            List<StoreProcedure> obj = _db.StoreProcedure.FromSqlInterpolated($"Exec Test @Id = {Id}").ToList();

            return View(obj);
        }


        [HttpPost]
        public IActionResult Add(Employee e)
        {
            _db.Employees.Add(e);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            _db.Employees.Update(e);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
