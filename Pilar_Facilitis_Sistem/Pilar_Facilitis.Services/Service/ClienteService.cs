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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        private readonly IMapper _mapeador;
        public ClienteService(IClienteRepository clienteRepository, IUnidadeTrabalho unidadeTrabalho, IMapper mappeer)
        {
            _clienteRepository = clienteRepository;
            _unidadeTrabalho = unidadeTrabalho;
            _mapeador = mappeer;
        }
        public async Task<Resposta> Adcionar(ClienteViewModel clienteViewModel)
        {
            try
            {
                var clienteModel = _mapeador.Map<Cliente>(clienteViewModel);
                var resposta = ValidarCliente(clienteModel);

                if (!resposta.Sucesso) return resposta;                
                            
                var clienteBd = await _clienteRepository.InsereAsync(clienteModel);
                await _unidadeTrabalho.SalvaAlteracoesAsync();

                return resposta.Retorno(_mapeador.Map<ClienteViewModel>(clienteBd));                
            }
            catch (Exception e)
            {
                return new Resposta(e);
            }                        
        }

        public async Task<Resposta> Atualizar(ClienteViewModel clienteViewModel)
        {
            try
            {
                var clienteModel = _mapeador.Map<Cliente>(clienteViewModel);
                var resposta = ValidarCliente(clienteModel);

                if (!resposta.Sucesso) return resposta;

                await _clienteRepository.Edita(clienteModel); //atualizar
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
            var resposta = new Resposta();

            var cliente = await _clienteRepository.BuscaAsync(id);

            if (cliente != null)
            {
                return resposta.Retorno(_mapeador.Map<ClienteViewModel>(cliente));
            }

             resposta.AdicionaErro(Mensagens.NaoEncontrado, Mensagens.NaoLocalizado);
             return resposta;
        }

        public Task<IEnumerable<Resposta>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        private Resposta ValidarCliente(Cliente cliente)
        {
            var resposta = new Resposta();
            
            var validacao = new ClienteValidacao().Validate(cliente);
            if (validacao.IsValid) return resposta;
            foreach (var erro in validacao.Errors)
            {
                resposta.AdicionaErro(erro.PropertyName, erro.ErrorMessage);
            }

            return resposta;            
        }
    }
}