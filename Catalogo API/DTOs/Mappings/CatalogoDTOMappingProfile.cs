using AutoMapper;
using Catalogo_API.Models;

namespace Catalogo_API.DTOs.Mappings;

public class CatalogoDTOMappingProfile : Profile
{
    public CatalogoDTOMappingProfile()
    {
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateRequest>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateResponse>().ReverseMap();
    }
}
