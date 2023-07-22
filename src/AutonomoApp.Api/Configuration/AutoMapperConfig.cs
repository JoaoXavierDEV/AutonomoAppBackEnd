using AutoMapper;
using AutonomoApp.Business.DTO;
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
            .ForMember(x => x.Id, y => y.MapFrom(m => m.Id))
            .ForMember(x => x.Subcategoria, y => y.MapFrom(src => src.Subcategorias))
            //.ForMember(x => x.Subcategoria,y => y.MapFrom(src => src.Subcategorias))
            .ReverseMap();

        CreateMap<Subcategoria, SubCategoriaViewModel>()
            .ForMember(x => x.Nome, y => y.MapFrom(x => x.Nome))
            .ForMember(x => x.Descricao, y => y.MapFrom(x => x.Descricao))
            //.ForMember(x => x.IdCategoria , y => y.MapFrom(x => x.CategoriaId))
            .ReverseMap();

        CreateMap<Categoria, ServicoViewModel>()
            .ForMember(dest => dest.CategoriaId, otp => otp.MapFrom(x => x.Id));

        CreateMap<Categoria, Servico>()
            .ForMember(dest => dest.Categoria, otp => otp.MapFrom(x => x));

        CreateMap<Guid, ServicoViewModel>();

        Action<ServicoViewModel, Servico> teste = (view,ser) =>
        {
            ser.Categoria = new Categoria();
            ser.Categoria.Id = view.CategoriaId;

            ser.Subcategoria = new();
            ser.Subcategoria.Id = view.SubcategoriaId;

            ser.ClientePrestador = new PessoaFisica();
            ser.ClientePrestador.Id = view.Prestador;
        };


        CreateMap<ServicoViewModel, Servico>()
            .ForMember(dest => dest.Nome, otp => otp.MapFrom(x => x.Nome))
            .ForMember(dest => dest.Descricao, y => y.MapFrom(x => x.Descricao))
            .ForMember(dest => dest.Tags, y => y.MapFrom(x => x.Tags))
            .ForMember(dest => dest.Valor, y => y.MapFrom(x => x.Valor))

            .ForMember(dest => dest.ClientePrestadorId, y => y.MapFrom(x => x.Prestador))
            .ForMember(dest => dest.CategoriaId, y => y.MapFrom(x => x.CategoriaId))
            .ForMember(dest => dest.SubcategoriaId, y => y.MapFrom(x => x.SubcategoriaId))
            //.AfterMap(teste)
            .ReverseMap();

    }
}