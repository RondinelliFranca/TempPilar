using System;
using System.Threading.Tasks;
using AutoMapper;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Services.Service
{
    public class PontoAtendimentoService : IPontoAtendimentoService
    {
        private readonly IPontoAtendimentoRepository _repository;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;

        public PontoAtendimentoService(IPontoAtendimentoRepository pontoAtendimentoRepository, IUnidadeTrabalho unidadeTrabalho, IMapper mappeer)
        {
            _repository = pontoAtendimentoRepository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mappeer;
        }
        public Task<Resposta> Adcionar(PontoAtendimentoViewModel pontoAtendimento)
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> Atualizar(PontoAtendimentoViewModel pontoAtendimento)
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> ObterPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}