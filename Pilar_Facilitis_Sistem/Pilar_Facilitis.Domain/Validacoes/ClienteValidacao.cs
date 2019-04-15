using FluentValidation;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Util.FluentValidation;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Domain.Validacoes
{
    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(x => x.CNPJ)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "CNPJ"))
                .Must(ValidacaoCustomizada.CNPJValido).WithMessage(string.Format(Mensagens.CampoInvalido, "CNPJ"));

            RuleFor(x => x.NomeFantasia)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Nome Fantasia"));

            RuleFor(x => x.Celular)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Celular"));

            RuleFor(x => x.Email)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "E-mail"));
        }
    }
}