using AutoMapper;
using AutonomoApp.Business.Models;
using AutonomoApp.WebApi.ViewModels;

namespace AutonomoApp.WebApi.Configuration;

public class AutoMapperConfig : Profile

{

    public AutoMapperConfig()
    {
        CreateMap<Categoria, CategoriaViewModel>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(x => x.Descricao, y => y.MapFrom(src => src.Descricao))
            .ForMember(x => x.Id, y => y.MapFrom(m => m.Id ))
            .ForMember(x => x.Subcategoria,y => y.MapFrom(src => src.Subcategorias))
            //.ForMember(x => x.Subcategoria,y => y.MapFrom(src => src.Subcategorias))
            .ReverseMap();

        CreateMap<Subcategoria, SubCategoriaViewModel>()
            .ForMember(x => x.Nome, y => y.MapFrom(x => x.Nome))
            .ForMember(x => x.Descricao, y => y.MapFrom(x => x.Descricao))
            //.ForMember(x => x.IdCategoria , y => y.MapFrom(x => x.CategoriaId))
            
            .ReverseMap();

    }
}