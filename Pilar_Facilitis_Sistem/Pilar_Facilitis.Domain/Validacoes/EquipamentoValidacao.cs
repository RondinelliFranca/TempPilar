using FluentValidation;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Util.FluentValidation;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Domain.Validacoes
{
    public class EquipamentoValidacao : AbstractValidator<Equipamento>
    {
        public EquipamentoValidacao()
        {
            RuleFor(x => x.NumDeSerie)
                .Must(ValidacaoCustomizada.CampoObrigatorioPreenchido)
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Número de serie"));
        }
    }
}