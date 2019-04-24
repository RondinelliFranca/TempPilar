using FluentValidation;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Util.FluentValidation;
using Pilar_Facilitis.Util.Mensagens;

namespace Pilar_Facilitis.Domain.Validacoes
{
    public class ServicoValidacao : AbstractValidator<Servico>
    {
        public ServicoValidacao()
        {
            RuleFor(x => x.Area)
                .NotNull()
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Área"));

            RuleFor(x => x.Desc_Servicos)
                .NotNull()
                .WithMessage(string.Format(Mensagens.CampoObrigatorio, "Descrição do serviço"));

        }
    }
}