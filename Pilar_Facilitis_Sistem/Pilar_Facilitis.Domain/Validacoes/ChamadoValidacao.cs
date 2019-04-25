using FluentValidation;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Util.FluentValidation;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Domain.Validacoes
{
    public class ChamadoValidacao : AbstractValidator<Chamado>
    {
        public ChamadoValidacao()
        {
            RuleFor(x => x.DescricaoProblema)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Descrição"));
        }
    }
}