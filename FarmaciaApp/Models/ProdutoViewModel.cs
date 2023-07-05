namespace FarmaciaApp.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            this.Nome = "";
            this.Qtd = null;
            this.Preco = null;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Qtd { get; set; }
        public double? Preco { get; set; }
    }
}
