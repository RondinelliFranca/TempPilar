using AutoMapper;
using Pilar_Facilitis.Api.ViewModel;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Services.Configuracoes
{
    public class Mapeador
    {
        public static MapperConfiguration RegistrarMapeamentos()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DominioParaDtoMapeador());
                cfg.AddProfile(new DtoParaDominioMapeador());
            });
        }

        public class DominioParaDtoMapeador : Profile
        {
            public DominioParaDtoMapeador()
            {
                CreateMap<Cliente, ClienteViewModel>();
                CreateMap<Endereco, EnderecoViewModel>();
            }
        }

        public class DtoParaDominioMapeador : Profile
        {
            public DtoParaDominioMapeador()
            {
                CreateMap<ClienteViewModel, Cliente>();
                CreateMap<EnderecoViewModel, Endereco>();
            }
        }
    }
}