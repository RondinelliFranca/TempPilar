using System;
using System.Threading.Tasks;
using AutoMapper;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Services.Service
{
    public class ServicoService : IServicoService
    {
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;
        private readonly IServicoRepository _repository;
        public ServicoService(IUnidadeTrabalho unidadeTrabalho, IMapper mappeer, IServicoRepository repository)
        {
            _repository = repository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mappeer;
        }
        public async Task<Resposta> Adcionar(ServicoViewModel servicoViewModel)
        {
            try
            {
                var servicoModel = _mapeador.Map<Servico>(servicoViewModel);
                var resposta = Validar(servicoModel);

                if (!resposta.Sucesso) return resposta;

                var pontoAtendimentoBd = await _repository.InsereAsync(servicoModel);
                await _unidadeTrabalho.SalvaAlteracoesAsync();

                return resposta.Retorno(_mapeador.Map<PontoAtendimentoViewModel>(pontoAtendimentoBd));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        private Resposta Validar(Servico servicoModel)
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> Atualizar(ServicoViewModel servico)
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