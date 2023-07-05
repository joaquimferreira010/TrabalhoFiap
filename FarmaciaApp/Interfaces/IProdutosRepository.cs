using FarmaciaApp.Models;

namespace FarmaciaApp.Interfaces
{
    public interface IProdutosRepository
    {
        int Add(ProdutoViewModel produto);
        IEnumerable<ProdutoViewModel> GetAll();
    }
}
