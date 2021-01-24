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
    public class PieController : Controller
    { 
        //setam variabile locale pt repository-uri
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            // dependinte setate in startup 
            // salvam in variabilele locale instante de repos injectate cu ajutorul sistemului de dependinte 
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = _pieRepository.AllPies;
            piesListViewModel.CurrentCategory = "Cheese cakes";

            return View(piesListViewModel);
        }
    }
}
