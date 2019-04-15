using System;
using System.Collections.Generic;

namespace Pilar_Facilitis.Domain.Modelos
{
    public class Resposta
    {
        public bool Sucesso { get; set; } = true;
        public bool Erro { get; set; }
        public object Dados { get; set; }
        public List<Erro> Erros { get; set; }

        public Resposta()
        {
            Erro = false;
            Erros = new List<Erro>();
        }

        public Resposta(Exception ex)
        {
            Sucesso = false;
            Erro = true;
            Erros.Add(new Erro { Chave = "Exceção", Mensagem = ex.Message });
        }

        public Resposta Retorno(object dados = null)
        {
            Dados = dados;
            return this;
        }

        public void AdicionaErro(string chave, string mensagem)
        {
            var erro = new Erro
            {
                Chave = chave,
                Mensagem = mensagem
            };
            Erros.Add(erro);
            Sucesso = false;
            Erro = true;
        }

        public Resposta RetornaErro(string chave, string mensagem)
        {
            Erros.Add(new Erro { Chave = chave, Mensagem = mensagem });
            Sucesso = false;
            Erro = true;
            return this;
        }
    }
}