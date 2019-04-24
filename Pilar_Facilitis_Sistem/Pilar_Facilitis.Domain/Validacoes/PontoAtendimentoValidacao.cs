using FluentValidation;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Util.FluentValidation;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Domain.Validacoes
{
    public class PontoAtendimentoValidacao : AbstractValidator<PontoAtendimentos>
    {
        public PontoAtendimentoValidacao()
        {
            RuleFor(x => x.Nome)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Nome"));
        }
    }
}