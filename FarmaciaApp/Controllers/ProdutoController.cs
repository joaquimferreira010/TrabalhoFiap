using FarmaciaApp.Interfaces;
using FarmaciaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaApp.Controllers
{
    public class ProdutoController : Controller
    {

        public readonly IProdutosRepository _repository;

        //public Create(IProdutosRepository repository)
        //{
        //    this._repository = repository;
        //    this.Produto = new ProdutoViewModel();
        //}

        public void OnGet()
        {

        }

        [BindProperty]
        public ProdutoViewModel Produto { get; set; }

        [HttpPost]
        public IActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repository.Add(Produto);
            return RedirectToPage("./Create");
        }
    }
}
