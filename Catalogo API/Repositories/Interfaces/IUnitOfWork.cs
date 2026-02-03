namespace Catalogo_API.Repositories.Interfaces;

public interface IUnitOfWork
{
    ICategoriaRepository CategoriaRepository { get; }
    IProdutoRepository ProdutoRepository { get; }
    void Commit();
}
