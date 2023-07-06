using FarmaciaWebApp.Models;

namespace FarmaciaWebApp.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produduto, int id);
        Task<bool> Apagar(int id);
    }
}
