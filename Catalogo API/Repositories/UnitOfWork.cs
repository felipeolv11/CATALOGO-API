using Catalogo_API.Context;
using Catalogo_API.Repositories.Interfaces;

namespace Catalogo_API.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private ICategoriaRepository? _categoriaRepo;
    private IProdutoRepository? _produtoRepo;

    public CatalogoDbContext _context;
    public UnitOfWork(CatalogoDbContext context)
    {
        _context = context;
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
        }
    }
    public IProdutoRepository ProdutoRepository
    {
        get
        {
            return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
