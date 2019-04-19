using FluentValidation;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Util.FluentValidation;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Domain.Validacoes
{
    public class FuncionarioValidacao : AbstractValidator<Funcionario>
    {
        public FuncionarioValidacao()
        {
            RuleFor(x => x.Nome)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Nome"));

            RuleFor(x => x.CPF)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "CPF"))
                .Must(ValidacaoCustomizada.CPFValido).WithMessage(string.Format(Mensagens.CampoInvalido, "CPF"));

            RuleFor(x => x.Telefone_Cel)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Telefone"));

            RuleFor(x => x.Email)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Email"));
        }
    }
}