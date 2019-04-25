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

                return resposta.Retorno(_mapeador.Map<ServicoViewModel>(pontoAtendimentoBd));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }
      
        public async Task<Resposta> Atualizar(ServicoViewModel servicoViewModel)
        {
            try
            {
                var servicoModel = _mapeador.Map<Servico>(servicoViewModel);
                var resposta = Validar(servicoModel);

                if (!resposta.Sucesso) return resposta;

                await _repository.Edita(servicoModel);
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

                var servico = await _repository.BuscaAsync(id);

                if (servico != null)
                {
                    return resposta.Retorno(_mapeador.Map<ServicoViewModel>(servico));
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
                    _mapeador.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(
                        await _repository.BuscaTodosAsync()));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> ObterPorNome(string nome)
        {
            var resposta = new Resposta();
            return resposta.Retorno(
                _mapeador.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(
                    await _repository.BuscarPorNome(nome)));
        }

        public async Task<Resposta> Remover(Guid id)
        {
            try
            {
                var resposta = new Resposta();
                var servico = await _repository.BuscaAsync(id);
                if (servico == null)
                {
                    resposta.AdicionaErro("Inconsitência!", "Serviço não foi localizado!");
                    return resposta;
                }

                _repository.Exclui(servico);
                await _unidadeTrabalho.SalvaAlteracoesAsync();
                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        private Resposta Validar(Servico servicoModel)
        {
            var resposta = new Resposta();

            var validacao = new ServicoValidacao().Validate(servicoModel);
            if (validacao.IsValid) return resposta;
            foreach (var erro in validacao.Errors)
            {
                resposta.AdicionaErro(erro.PropertyName, erro.ErrorMessage);
            }

            return resposta;
        }

    }
}