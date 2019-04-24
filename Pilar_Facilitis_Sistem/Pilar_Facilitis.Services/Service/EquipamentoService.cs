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
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _repository;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;

        public EquipamentoService(IEquipamentoRepository repository, IUnidadeTrabalho unidadeTrabalho, IMapper mappeer)
        {
            _repository = repository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mappeer;
        }

        public async Task<Resposta> Adcionar(EquipamentoViewModel equipamentoViewModel)
        {
            try
            {
                var equipamentoModel = _mapeador.Map<Equipamento>(equipamentoViewModel);
                var resposta = Validar(equipamentoModel);

                if (!resposta.Sucesso) return resposta;

                var equipamentoBd = await _repository.InsereAsync(equipamentoModel);
                await _unidadeTrabalho.SalvaAlteracoesAsync();

                return resposta.Retorno(_mapeador.Map<EquipamentoViewModel>(equipamentoBd));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> Atualizar(EquipamentoViewModel equipamentoViewModel)
        {
            try
            {
                var equipamentoModel = _mapeador.Map<Equipamento>(equipamentoViewModel);
                var resposta = Validar(equipamentoModel);

                if (!resposta.Sucesso) return resposta;

                await _repository.Edita(equipamentoModel);
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

                var equipamento = await _repository.BuscaAsync(id);

                if (equipamento != null)
                {
                    return resposta.Retorno(_mapeador.Map<EquipamentoViewModel>(equipamento));
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
                    _mapeador.Map<IEnumerable<Equipamento>, IEnumerable<EquipamentoViewModel>>(
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
                _mapeador.Map<IEnumerable<Equipamento>, IEnumerable<EquipamentoViewModel>>(
                    await _repository.BuscarPorNome(nome)));
        }

        public async Task<Resposta> Remover(Guid id)
        {
            try
            {
                var resposta = new Resposta();
                var equipamento = await _repository.BuscaAsync(id);
                if (equipamento == null)
                {
                    resposta.AdicionaErro("Inconsitência!", "Equipamento não foi localizado!");
                    return resposta;
                }

                _repository.Exclui(equipamento);
                await _unidadeTrabalho.SalvaAlteracoesAsync();
                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        private Resposta Validar(Equipamento equipamento)
        {
            var resposta = new Resposta();

            var validacao = new EquipamentoValidacao().Validate(equipamento);
            if (validacao.IsValid) return resposta;
            foreach (var erro in validacao.Errors)
            {
                resposta.AdicionaErro(erro.PropertyName, erro.ErrorMessage);
            }

            return resposta;
        }
    }
}