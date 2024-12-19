using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace EclipseWorks.DesafioTecnico.Services.Validators.Tarefas
{
    public class RemoverTarefaValidator : AbstractValidator<RemoverTarefaCommand>
    {
        private ValidationResult ValidationResult { get; set; }
        public string[] CriticasNegocio => ValidationResult.Criticas();

        public RemoverTarefaValidator(ITarefaRepository tarefaRepository)
        {
            WhenAsync(async (projeto, cancellationToken) => !await tarefaRepository.TarefaExiste(projeto.IdProjeto, projeto.IdTarefa), () =>
            {
                RuleFor(a => a).Must(a => false).WithMessage("Operação inválida. Tarefa não encontrada.");
            });
        }

        public async Task<bool> OperacaoValida(RemoverTarefaCommand inputModel)
        {
            ValidationResult = await ValidateAsync(inputModel);
            return ValidationResult.IsValid;
        }
    }
}