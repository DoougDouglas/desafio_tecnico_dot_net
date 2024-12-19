using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace EclipseWorks.DesafioTecnico.Services.Validators.Tarefas
{
    public class AdicionarComentarioTarefaValidator : AbstractValidator<AdicionarComentarioTarefaCommand>
    {
        private ValidationResult ValidationResult { get; set; }
        public string[] CriticasNegocio => ValidationResult.Criticas();

        public AdicionarComentarioTarefaValidator(ITarefaRepository repository)
        {
            WhenAsync(async (tarefa, cancellationToken) => await repository.TarefaExiste(tarefa.IdProjeto, tarefa.IdTarefa), () =>
            {
                RuleFor(a => a.Comentario)
                    .NotEmpty()
                    .WithMessage("O campo Comentario é obrigatório.");

                RuleFor(a => a.Comentario)
                    .MaximumLength(255)
                    .WithMessage("O campo Comentario deve possuir no máximo 255 caracteres.")
                    .When(a => !string.IsNullOrEmpty(a.Comentario));

            }).Otherwise(() =>
            {
                RuleFor(a => a).Must(a => false).WithMessage("Operação inválida. Tarefa não encontrada.");
            });
        }

        public async Task<bool> OperacaoValida(AdicionarComentarioTarefaCommand inputModel)
        {
            ValidationResult = await ValidateAsync(inputModel);
            return ValidationResult.IsValid;
        }
    }
}
