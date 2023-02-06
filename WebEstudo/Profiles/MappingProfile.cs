using AutoMapper;
using WebEstudo.DTO.Entidades;
using WebEstudo.Entidades;

namespace WebEstudo.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.descricao,
                    map => map.MapFrom(src => $"{src.id_usuario} - {src.nm_usuario}"))
                .ReverseMap();
            CreateMap<Produtos, ProdutoDTO>().ReverseMap();
        }
    }
}
