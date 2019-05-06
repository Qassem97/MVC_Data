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
                return BadRequest();

            }
            else
            {
                _personService.CreateUser(person.Name, person.Number, person.City);
                return PartialView("_People", _personService.GetPeople());
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
                .Where(m => m.Name.Contains(searchString) || m.City.Contains(searchString))
                .ToList();// lambda
                var vm = new PersonViewModel();
                vm.People = people;
                return View(vm);
            }
            //var people = from m in _personService.GetPeople()   //It works!!
            //             where m.Name.Contains(searchString)
            //             select m;

        }
        public IActionResult Delete(int id)
        {
            _personService.DeletePerson(id);

            return Ok();
        }
        public IActionResult SingUp()
        {
            Person model = new Person();
            return PartialView("_SingUp", model);
        }

        public IActionResult Edit(int id)
        {
            var person = _personService.FindPerson(id);
            return PartialView("_Edit", person);
        }

        [HttpPost]
        public IActionResult Edit(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Edit", person);
            }
            if(id != person.Id)
            {
                return BadRequest();
            }
            if (_personService.UpdatePerson(person))
            {
                return PartialView("_Person", person);
            }
            return PartialView("_Edit", person);

        }
    }
}