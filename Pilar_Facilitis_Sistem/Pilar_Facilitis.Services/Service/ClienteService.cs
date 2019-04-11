using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.ViewModel;

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
        public async Task<Cliente> Adcionar(ClienteViewModel cliente)
        {
            try
            {
                var cc = _mapeador.Map<Cliente>(cliente);
                //cc.Endereco.Cliente = cc;
                //cc.Endereco.ClienteId = cc.ClienteId;
                var clienteBd = await _clienteRepository.InsereAsync(cc);
                await _unidadeTrabalho.SalvaAlteracoesAsync();
                return clienteBd;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }                        
        }

        public Task<Cliente> Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObterPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}