using TechStore.Models;

namespace TechStore.ViewModels
{
    public class ProdutoVM
    {
        public Produto Produto { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}