using Catalogo_API.Context;
using Catalogo_API.Models;
using Catalogo_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo_API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriasController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _categoriaRepository.GetAll();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _categoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult Post (Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest();
        }

        var categoriaCriada = _categoriaRepository.Create(categoria);

        return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoriaCriada.CategoriaId }, categoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put (int id, Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest();
        }

        _categoriaRepository.Update(categoria);

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Categoria> Delete(int id)
    {
        var categoria = _categoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
        {
            return NotFound();
        }

        var categoriaExcluida = _categoriaRepository.Delete(categoria);

        return Ok(categoriaExcluida);
    }
}
