using System;
using System.Threading.Tasks;
using AutoMapper;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.Modelos;

namespace Pilar_Facilitis.Services.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;
        private readonly IEstadoRepository _estadoRepository;
        private readonly ICidadeRepository _cidadeRepository;

        public EnderecoService(IUnidadeTrabalho unidadeTrabalho, IMapper mapper, IEstadoRepository estadoRepository, ICidadeRepository cidadeRepository)
        {
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mapper;
            _estadoRepository = estadoRepository;
            _cidadeRepository = cidadeRepository;
        }

        public async Task<Resposta> ObterTodosEstados()
        {
            try
            {
                var resposta = new Resposta();
                return resposta.Retorno(await _estadoRepository.BuscaTodosAsync());

            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> ObterCidades(int id)
        {
            try
            {
                var resposta = new Resposta();
                return resposta.Retorno(_cidadeRepository.BuscaTodosAsync(id));

            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }
    }
}