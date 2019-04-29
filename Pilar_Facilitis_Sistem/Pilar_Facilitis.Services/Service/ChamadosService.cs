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
    public class ChamadosService : IChamadosService
    {
        private readonly IChamadosRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly IPontoAtendimentoRepository _pontoAtendimentoRepository;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;

        public ChamadosService(IChamadosRepository chamadosRepository, IClienteRepository clienteRepository, IUnidadeTrabalho unidadeTrabalho, IMapper mapeador, IServicoRepository servicoRepository, IPontoAtendimentoRepository pontoAtendimentoRepository)
        {
            _repository = chamadosRepository;
            _clienteRepository = clienteRepository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mapeador;
            _servicoRepository = servicoRepository;
            _pontoAtendimentoRepository = pontoAtendimentoRepository;
        }
        public async Task<Resposta> Adcionar(ChamadosViewModel chamadoViewModel)
        {
            var chamadoModel = _mapeador.Map<Chamado>(chamadoViewModel);
            await ConfigurarChamado(chamadoViewModel, chamadoModel);
            var resposta = Validar(chamadoModel);

            if (!resposta.Sucesso) return resposta;

            var chamadodb = await _repository.InsereAsync(chamadoModel);
            await _unidadeTrabalho.SalvaAlteracoesAsync();


            return resposta;
        }       

        public async Task<Resposta> Atualizar(ChamadosViewModel chamadoViewModel)
        {
            var chamadoModel = _mapeador.Map<Chamado>(chamadoViewModel);
            await ConfigurarChamado(chamadoViewModel, chamadoModel);
            var resposta = Validar(chamadoModel);

            if (!resposta.Sucesso) return resposta;

            var chamadodb = await _repository.InsereAsync(chamadoModel);
            await _unidadeTrabalho.SalvaAlteracoesAsync();


            return resposta;

        }

        public async Task<Resposta> ObterPorId(Guid id)
        {
            try
            {
                var resposta = new Resposta();

                var pontoAtendimento = await _repository.BuscaPorId(id);

                if (pontoAtendimento != null)
                {
                    return resposta.Retorno(_mapeador.Map<ChamadosViewModel>(pontoAtendimento));
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
                    _mapeador.Map<IEnumerable<Chamado>, IEnumerable<ChamadosViewModel>>(
                        await _repository.BuscaTodosAsync()));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }

        private Resposta Validar(Chamado chamadoModel)
        {
            var resposta = new Resposta();

            var validacao = new ChamadoValidacao().Validate(chamadoModel);
            if (validacao.IsValid) return resposta;
            foreach (var erro in validacao.Errors)
            {
                resposta.AdicionaErro(erro.PropertyName, erro.ErrorMessage);
            }

            return resposta;
        }

        private async Task ConfigurarChamado(ChamadosViewModel chamadoViewModel, Chamado chamado)
        {
            chamado.Cliente = await _clienteRepository.BuscaAsync(chamadoViewModel.IdCliente);
            chamado.PontoAtendimento = await _pontoAtendimentoRepository.BuscaAsync(chamadoViewModel.IdPontoAtendimento);
            chamado.Servico = await _servicoRepository.BuscaAsync(chamadoViewModel.IdServico);
        }

        public async Task<Resposta> ObterTodosPorClienteId(Guid id)
        {
            try
            {
                var resposta = new Resposta();
                return resposta.Retorno(
                    _mapeador.Map<IEnumerable<Chamado>, IEnumerable<ChamadosViewModel>>(
                        await _repository.BuscaTodosPorClienteAsync(id)));
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }
        }
    }
}