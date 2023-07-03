using FarmaciaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FarmaciaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<ProdutoViewModel> produtos = new List<ProdutoViewModel>();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Produto()
        {
           
            return View(produtos);
        }

        public IActionResult Create()
        {
            var produtoVm = new ProdutoViewModel();
            return View(produtoVm);
        }
        public IActionResult CreateProduto(ProdutoViewModel produtoViewModel)
        {
            //return View("Produto");
            produtos.Add(produtoViewModel);
            return RedirectToAction(nameof(Produto));

        }

        public IActionResult Projeto()
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