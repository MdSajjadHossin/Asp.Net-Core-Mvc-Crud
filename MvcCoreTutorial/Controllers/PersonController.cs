using Microsoft.AspNetCore.Mvc;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Controllers
{
    
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx) 
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            //ViewBag & ViewData can send data only from Controller to View
            ViewBag.greeting = "Hello form asp.net ViewBag";
            ViewData["greeting2"] = "Hello form asp.net ViewData";
            //TempData can send data from one Controller method to another Controller method
            TempData["greeting3"] = "Hello from temp Data";
            return View();
        }

        //get method
        public IActionResult AddPerson()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added Successfull";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not Added !!!!";
                return View();
            }
            
            
        }
        
        public IActionResult DisplayPersons() 
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }

        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);
            return View();
        }

        public IActionResult DeletePersons(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("DisplayPersons");
            
        }
    }
}
