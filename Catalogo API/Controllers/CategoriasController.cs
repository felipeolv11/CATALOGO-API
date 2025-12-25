using Catalogo_API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo_API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly CatalogoDbContext _context;

    public CategoriasController(CatalogoDbContext context)
    {
        _context = context;
    }
}
