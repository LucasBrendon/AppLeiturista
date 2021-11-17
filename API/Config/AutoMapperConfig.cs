using AutoMapper;
using Business.Models;
using Business.ViewModels.Leitura;
using Business.ViewModels.Leiturista;
using Business.ViewModels.Ocorrencia;
using Business.ViewModels.Usuario;

namespace API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Leiturista, CriaLeituristaViewModel>().ReverseMap();
            CreateMap<Leiturista, ExibiLeituristaViewModel>().ReverseMap();

            CreateMap<Usuario, CriarUsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, ExibirUsuarioViewModel>().ReverseMap();
            CreateMap<Usuario,EditarUsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, LoginViewModel>().ReverseMap();

            CreateMap<Ocorrencia, CriarOcorrenciaViewModel>().ReverseMap();
            CreateMap<Ocorrencia, ExibirOcorrenciaViewModel>().ReverseMap();

            CreateMap<Leitura, CriarLeituraViewModel>().ReverseMap();
            CreateMap<Leitura, ExibirLeituraViewModel>()
                .ForMember(x => x.LeituristaId, l => l.MapFrom(l => l.Leiturista))
                .ForMember(x => x.OcorrenciaId, o => o.MapFrom(o => o.Ocorrencia))
                .ReverseMap();
            CreateMap<Leitura, EditarLeituraViewModel>().ReverseMap();
        }
    }
}
