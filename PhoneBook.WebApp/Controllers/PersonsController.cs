﻿using Microsoft.AspNetCore.Mvc;
using PhoneBook.WebApp.Models;
using PhoneBook.WebApp.Services.Abstact;

namespace PhoneBook.WebApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            var personList = _personService.GetAll();
            return View(personList.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _personService.Add(personViewModel);
                if (result.Success)
                    return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = _personService.Delete(id);
                if (result.Success)
                    return RedirectToAction("Index");
            }
            return View();
        }


    }
}
