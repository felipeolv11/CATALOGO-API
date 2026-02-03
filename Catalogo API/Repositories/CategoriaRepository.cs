using Catalogo_API.Context;
using Catalogo_API.Models;
using Catalogo_API.Repositories.Interfaces;

namespace Catalogo_API.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(CatalogoDbContext context) : base(context)
    {
    }
}
