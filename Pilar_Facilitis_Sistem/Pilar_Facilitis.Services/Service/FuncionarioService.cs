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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IUnidadeTrabalho unidadeTrabalho, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resposta> Adcionar(FuncionarioViewModel funcionarioViewModel)
        {
            try
            {
                var funcionarioModel = _mapeador.Map<Funcionario>(funcionarioViewModel);
                var resposta = Validar(funcionarioModel);

                if (!resposta.Sucesso) return resposta;

                var funcionarioDb = await _funcionarioRepository.InsereAsync(funcionarioModel);
                await _unidadeTrabalho.SalvaAlteracoesAsync();

                return resposta.Retorno(_mapeador.Map<FuncionarioViewModel>(funcionarioDb));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        public async Task<Resposta> Atualizar(FuncionarioViewModel funcionarioViewModel)
        {
            try
            {
                var funcionarioModel = _mapeador.Map<Funcionario>(funcionarioViewModel);
                var resposta = Validar(funcionarioModel);

                if (!resposta.Sucesso) return resposta;

                await _funcionarioRepository.Edita(funcionarioModel);
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

                var funcionario = await _funcionarioRepository.BuscaAsync(id);

                if (funcionario != null)
                {
                    return resposta.Retorno(_mapeador.Map<FuncionarioViewModel>(funcionario));
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
                    _mapeador.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(
                        await _funcionarioRepository.BuscaTodosAsync()));
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
                _mapeador.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(
                    await _funcionarioRepository.BuscarPorNome(nome)));
        }

        public async Task<Resposta> Remover(Guid id)
        {
            try
            {
                var resposta = new Resposta();
                var funcionario = await _funcionarioRepository.BuscaAsync(id);
                if (funcionario == null)
                {
                    resposta.AdicionaErro("Inconsitência!", "Funcionario não foi localizado!");
                    return resposta;
                }

                _funcionarioRepository.Exclui(funcionario);
                await _unidadeTrabalho.SalvaAlteracoesAsync();
                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        private Resposta Validar(Funcionario funcionario)
        {
            var resposta = new Resposta();

            var validacao = new FuncionarioValidacao().Validate(funcionario);
            if (validacao.IsValid) return resposta;
            foreach (var erro in validacao.Errors)
            {
                resposta.AdicionaErro(erro.PropertyName, erro.ErrorMessage);
            }

            return resposta;
        }
    }
}