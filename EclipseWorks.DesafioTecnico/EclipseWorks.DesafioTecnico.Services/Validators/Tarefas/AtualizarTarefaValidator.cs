using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Repositories;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace EclipseWorks.DesafioTecnico.Services.Validators.Tarefas
{
    public class AtualizarTarefaValidator : AbstractValidator<AtualizarTarefaCommand>
    {
        private ValidationResult ValidationResult { get; set; }
        public string[] CriticasNegocio => ValidationResult.Criticas();

        public AtualizarTarefaValidator(ITarefaRepository repository)
        {
            WhenAsync(async (tarefa, cancellationToken) => await repository.TarefaExiste(tarefa.IdProjeto, tarefa.IdTarefa), () =>
            {
                RuleFor(tarefa => tarefa.Titulo)
                 .NotEmpty()
                 .WithMessage("O campo Titulo é obrigatório.");

                RuleFor(tarefa => tarefa.Titulo)
                   .MaximumLength(255)
                   .WithMessage("O campo Titulo deve possuir no máximo 255 caracteres.")
                   .When(a => !string.IsNullOrEmpty(a.Titulo));

                RuleFor(tarefa => tarefa.Descricao)
                 .NotEmpty()
                 .WithMessage("O campo Descrição é obrigatório.");

                RuleFor(tarefa => tarefa.Descricao)
                   .MaximumLength(1000)
                   .WithMessage("O campo Descricao deve possuir no máximo 1000 caracteres.")
                   .When(a => !string.IsNullOrEmpty(a.Descricao));

                RuleFor(tarefa => tarefa.DataVencimento)
                   .Must(dataVencimento => dataVencimento.Date >= DateTime.Now.Date)
                   .WithMessage("O campo Data venciento deve ser maior que a data atual.");

                RuleFor(tarefa => tarefa.Status)
                     .IsInEnum()
                     .WithMessage("O campo Status é Invalido.");

            }).Otherwise(() =>
            {
                RuleFor(a => a).Must(a => false).WithMessage("Operação inválida. Tarefa não encontrada.");
            });
        }

        public async Task<bool> OperacaoValida(AtualizarTarefaCommand inputModel)
        {
            ValidationResult = await ValidateAsync(inputModel);
            return ValidationResult.IsValid;
        }
    }
}