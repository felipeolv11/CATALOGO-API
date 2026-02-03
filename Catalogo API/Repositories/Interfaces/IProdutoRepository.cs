using Catalogo_API.Models;

namespace Catalogo_API.Repositories.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
}
