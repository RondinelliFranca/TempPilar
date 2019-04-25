using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.Validacoes;
using Pilar_Facilitis.Domain.ViewModel;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Services.Service
{
    public class PontoAtendimentoService : IPontoAtendimentoService
    {
        private readonly IPontoAtendimentoRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;

        public PontoAtendimentoService(IPontoAtendimentoRepository pontoAtendimentoRepository, IUnidadeTrabalho unidadeTrabalho, IMapper mappeer, IClienteRepository clienteRepository)
        {
            _repository = pontoAtendimentoRepository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mappeer;
            _clienteRepository = clienteRepository;
        }
        public async Task<Resposta> Adcionar(PontoAtendimentoViewModel pontoAtendimentoViewModel)
        {
            try
            {
                var pontoAtendimentoModel = _mapeador.Map<PontoAtendimentos>(pontoAtendimentoViewModel);
                var resposta = Validar(pontoAtendimentoModel);
                
                pontoAtendimentoModel.Cliente = await _clienteRepository.BuscaAsync(pontoAtendimentoViewModel.ClienteId);

                if (!resposta.Sucesso) return resposta;

                var pontoAtendimentoBd = await _repository.InsereAsync(pontoAtendimentoModel);
                await _unidadeTrabalho.SalvaAlteracoesAsync();

                return resposta.Retorno(_mapeador.Map<PontoAtendimentoViewModel>(pontoAtendimentoBd));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> Atualizar(PontoAtendimentoViewModel pontoAtendimento)
        {
            try
            {
                var pontoAtendimentosModel = _mapeador.Map<PontoAtendimentos>(pontoAtendimento);
                var resposta = Validar(pontoAtendimentosModel);

                if (!resposta.Sucesso) return resposta;

                await _repository.Edita(pontoAtendimentosModel);
                await _unidadeTrabalho.SalvaAlteracoesAsync();

                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> ObterPorID(Guid id)
        {
            try
            {
                var resposta = new Resposta();

                var pontoAtendimento = await _repository.BuscaAsync(id);

                if (pontoAtendimento != null)
                {
                    return resposta.Retorno(_mapeador.Map<PontoAtendimentoViewModel>(pontoAtendimento));
                }

                resposta.AdicionaErro(Mensagens.NaoEncontrado, Mensagens.NaoLocalizado);
                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> ObterTodos()
        {
            try
            {
                var resposta = new Resposta();
                return resposta.Retorno(
                    _mapeador.Map<IEnumerable<PontoAtendimentos>, IEnumerable<PontoAtendimentoViewModel>>(
                        await _repository.BuscaTodosAsync()));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> ObterPorNome(string nome)
        {
            try
            {
                var resposta = new Resposta();
                return resposta.Retorno(
                    _mapeador.Map<IEnumerable<PontoAtendimentos>, IEnumerable<PontoAtendimentoViewModel>>(
                        await _repository.BuscarPorNome(nome)));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
            
        }

        public async Task<Resposta> Remover(Guid id)
        {
            try
            {
                var resposta = new Resposta();
                var pontoAtendimento = await _repository.BuscaAsync(id);
                if (pontoAtendimento == null)
                {
                    resposta.AdicionaErro("Inconsitência!", "PontoAtendimento não foi localizado!");
                    return resposta;
                }

                _repository.Exclui(pontoAtendimento);
                await _unidadeTrabalho.SalvaAlteracoesAsync();
                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        private Resposta Validar(PontoAtendimentos pontoAtendimentos)
        {
            var resposta = new Resposta();

            var validacao = new PontoAtendimentoValidacao().Validate(pontoAtendimentos);
            if (validacao.IsValid) return resposta;
            foreach (var erro in validacao.Errors)
            {
                resposta.AdicionaErro(erro.PropertyName, erro.ErrorMessage);
            }

            return resposta;
        }
    }
}