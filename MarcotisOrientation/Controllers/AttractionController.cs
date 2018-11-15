using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MacrotisOrientation.Models;
using MacrotisOrientation.Services;
using Microsoft.AspNetCore.Mvc;

namespace MacrotisOrientation.Controllers
{
    public class AttractionController : Controller
    {
        private IAttractionService attractionService;
        public AttractionController(IAttractionService attractionService)
        {
            this.attractionService = attractionService;
        }

        public IActionResult Index()
        {
            return View(attractionService.ListAllAttractions());
        }

        [HttpPost]
        public IActionResult Add(Attractions attraction)
        {
            attractionService.AddAttraction(attraction);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", attractionService.GetAttractionById(id));
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(Attractions attractions)
        {
            attractionService.EditAttraction(attractions);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Filter(string category, string city) 
        {
            return Json(attractionService.CreateDTOBySearch(category, city));
        }
    }
}