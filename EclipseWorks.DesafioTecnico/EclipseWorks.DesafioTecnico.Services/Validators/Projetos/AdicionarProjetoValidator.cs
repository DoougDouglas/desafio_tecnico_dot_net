using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace EclipseWorks.DesafioTecnico.Services.Validators.Projetos
{
    public class AdicionarProjetoValidator : AbstractValidator<AdicionarProjetoCommand>
    {
        private ValidationResult ValidationResult { get; set; }
        public string[] CriticasNegocio => ValidationResult.Criticas();

        public AdicionarProjetoValidator()
        {
            RuleFor(a => a.Nome)
              .NotEmpty()
              .WithMessage("O campo Nome é obrigatório.");

            RuleFor(a => a.Nome)
              .MaximumLength(255)
              .WithMessage("O campo Nome deve possuir no máximo 255 caracteres.")
              .When(a => !string.IsNullOrEmpty(a.Nome));
        }

        public bool OperacaoValida(AdicionarProjetoCommand inputModel)
        {
            ValidationResult = Validate(inputModel);
            return ValidationResult.IsValid;
        }
    }
}
