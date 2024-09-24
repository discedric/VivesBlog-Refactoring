using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VivesBlog.Core;
using VivesBlog.Model;
using VivesBlog.Service;

namespace VivesBlog.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleService _peopleService;
        public PeopleController()
        {
            _peopleService = new PeopleService();
        }

        [HttpGet("People/Index")]
        public IActionResult Index()
        {
            var people = _peopleService.getPersons();
            return View(people);
        }

        [HttpGet("People/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("People/Create")]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _peopleService.AddPerson(person);

            return RedirectToAction("Index");
        }

        [HttpGet("People/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var person = _peopleService.GetPerson(id);

            return View(person);
        }

        [HttpPost("People/Edit/{id}")]
        public IActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _peopleService.UpdatePerson(person);

            return RedirectToAction("Index");
        }

        [HttpGet("People/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var person = _peopleService.GetPerson(id);

            return View(person);
        }

        [HttpPost("People/Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _peopleService.DeletePerson(id);

            return RedirectToAction("Index");
        }
    }
}
