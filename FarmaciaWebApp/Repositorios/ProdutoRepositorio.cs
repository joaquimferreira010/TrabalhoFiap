using FarmaciaApp.Interfaces;
using FarmaciaWebApp.Data;
using FarmaciaWebApp.Models;
using FarmaciaWebApp.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaWebApp.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutoDbContext _dbcontext;
        public ProdutoRepositorio(ProdutoDbContext bancoContext)
        {
            _dbcontext = bancoContext;
        }
        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbcontext.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbcontext.Produtos.AddAsync(produto);
            await _dbcontext.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o Id:{id} não foi encontrado na base de dados.");
            }
            produtoPorId.Id = produto.Id;
            produtoPorId.Nome = produto.Nome;
            produtoPorId.Preco = produto.Preco;

            _dbcontext.Produtos.Update(produtoPorId);
            await _dbcontext.SaveChangesAsync();
            return produtoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o Id:{id} não foi encontrado na base de dados.");
            }

            _dbcontext.Produtos.Remove(produtoPorId);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

               
    }
}
