using Azure.Storage.Blobs.Models;
using FarmaciaApp.Interfaces;
using FarmaciaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmaciaApp.Views.Home
{
    public class Create : PageModel
    {
        public readonly IProdutosRepository _repository;

        public Create(IProdutosRepository repository)
        {
            this._repository = repository;
            this.Produto = new ProdutoViewModel();
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public ProdutoViewModel Produto { get; set; }       
            
        public IActionResult OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _repository.Add(Produto);
            return RedirectToPage("./Create");
        }
       
        
    }
}
