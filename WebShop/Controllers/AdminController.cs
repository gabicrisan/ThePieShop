using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public AdminController(IPieRepository pieRepository)
        {

            _pieRepository = pieRepository;
        }

        public ViewResult List()
        {
            AdminListViewModel adminListViewModel = new AdminListViewModel();
            adminListViewModel.Pies = _pieRepository.AllPies;

            return View(adminListViewModel);
        }

        public IActionResult AddNewItemForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewItemForm(Pie pie)
        {
            if(ModelState.IsValid)
            {
                _pieRepository.AddNewPie(pie);
                return RedirectToAction("List");
            }

            return View(pie);
        }

        public IActionResult RemovePie(int pieId)
        {
            var selectedPie = _pieRepository.GetPieById(pieId);

            _pieRepository.RemovePie(selectedPie);
            return RedirectToAction("List");
        }

        public IActionResult EditPieForm(int pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);
            if (pie == null)
                return NotFound();
            return View(pie);
        }

        [HttpPost]
        public IActionResult EditPieForm(Pie pie)
        {
            if (ModelState.IsValid)
            {
                _pieRepository.EditPie(pie);
                return RedirectToAction("List");
            }

            return View(pie);
        }
    }
}
