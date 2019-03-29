using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCData.Models;

namespace MVCData.Controllers
{
    public class HomeController : Controller
    {
        IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index(string name, string number, string city)
        {
            var people = _personService.GetPeople();
            return View(people);
        }

        [HttpPost]
        public IActionResult SingUp(string name, string number, string city)
        {
            if (name == null || city == null || number == null)
            {
                //string.IsNullOrWhiteSpace(name); DOSENT WORK!
                //string.IsNullOrWhiteSpace(number);
                //string.IsNullOrWhiteSpace(city);
                return RedirectToAction("Index");

            }
            else
            {
                _personService.CreateUser(name, number, city);
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
    }
}