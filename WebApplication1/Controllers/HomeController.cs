using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using MVCData.ViewModel;

namespace MVCData.Controllers
{
    public class HomeController : Controller
    {
        IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            var vm = new PersonViewModel();
            vm.People = _personService.GetPeople();
            return View(vm);
        }

        [HttpPost]
        public IActionResult SingUp(Person person)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");

            }
            else
            {
                _personService.CreateUser(person.Name, person.Number, person.City);
                return RedirectToAction("Index");
            }

        }

        //public IActionResult 
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {

                return RedirectToAction("Index");
            }
            else
            {
                var people = _personService.GetPeople()
                .Where(m => m.Name.Contains(searchString) || m.City.Contains(searchString));// lambda

                return View(people.ToList());
            }
            //var people = from m in _personService.GetPeople()   //It works!!
            //             where m.Name.Contains(searchString)
            //             select m;

        }
        public IActionResult Delete(int id)
        {
            _personService.DeletePerson(id);

            return RedirectToAction("Index");
        }
        public IActionResult SingUp()
        {
            Person model = new Person();
            return PartialView("_SingUp", model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            _personService.FindPerson(id);
            return PartialView("_Edit", _personService.FindPerson(id));
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _personService.UpdatePerson(person);
            return PartialView("_Edit", _personService.UpdatePerson(person));

        }
    }
}