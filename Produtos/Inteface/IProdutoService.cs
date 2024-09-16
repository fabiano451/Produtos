using Produtos.Dominio;

namespace Produtos.Inteface
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAppleAsyync();
    }
}
