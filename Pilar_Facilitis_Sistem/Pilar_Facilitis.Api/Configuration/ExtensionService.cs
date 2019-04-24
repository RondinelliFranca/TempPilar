using Microsoft.Extensions.DependencyInjection;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Infra.Data.Contexts;
using Pilar_Facilitis.Infra.Data.Contexts.Base;
using Pilar_Facilitis.Infra.Data.Repository;
using Pilar_Facilitis.Services.Service;

namespace Pilar_Facilitis.Api.Configuration
{
    public static class ExtensionService
    {
        public static void AdicionarEscopos(this IServiceCollection services)
        {
            #region Aplicação 

            services.AddScoped<IContexto, ContextPilarFacilitis>();
            //services.AddScoped<IContextoRequisicao, ContextoRequisicao>();
            services.AddScoped<IUnidadeTrabalho, UnidadeTrabalhoEntity>();

            #endregion

            #region Repository

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IPontoAtendimentoRepository, PontoAtendimentoRepository>();

            #endregion

            #region Service

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IServicoService, ServicoService>();

            #endregion
        }
    }
}