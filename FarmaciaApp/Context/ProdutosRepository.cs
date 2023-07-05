using Dapper;
using FarmaciaApp.Interfaces;
using FarmaciaApp.Models;
using System.Data.SqlClient;

namespace FarmaciaApp.Context
{
    public class ProdutosRepository : IProdutosRepository
    {
        IConfiguration _configuration;
        public ProdutosRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GetConnection()
        {
            //var conn = _configuration.GetSection("ConnectionStrings").GetSection("AppConnection").Value;
            var conn = _configuration.GetSection("AppConnection").Value;
            return conn;
        }
        int IProdutosRepository.Add(ProdutoViewModel produto)
        {
            var connection = this.GetConnection();
            using (var cn = new SqlConnection(connection))
            {
                var novo = cn.Execute("INSERT TBProdutos (Nome, Qtd, Preco) VALUES (@Nome',@Qtd, @Preco)", produto);
                return novo;
            }
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            var connection = this.GetConnection();
            using (var cn = new SqlConnection(connection))
            {
                var produtos = cn.Query<ProdutoViewModel>("Select * from TBProdutos");
                return produtos;
            }
        }
    }
}
