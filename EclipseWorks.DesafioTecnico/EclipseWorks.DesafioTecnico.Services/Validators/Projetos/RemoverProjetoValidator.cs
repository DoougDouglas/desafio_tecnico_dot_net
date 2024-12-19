using EclipseWorks.DesafioTecnico.Domain.Projetos.Commands;
using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace EclipseWorks.DesafioTecnico.Services.Validators.Projetos
{
    public class RemoverProjetoValidator : AbstractValidator<RemoverProjetoCommand>
    {
        private ValidationResult ValidationResult { get; set; }
        public string[] CriticasNegocio => ValidationResult.Criticas();

        public RemoverProjetoValidator(IProjetoRepository repository)
        {
            WhenAsync(async (tarefa, cancellationToken) => await repository.ProjetoExisteAsync(tarefa.IdProjeto), () =>
            {
                RuleFor(a => a.IdProjeto)
                 .MustAsync(async (idProjeto, cancellationToken) => !await repository.PossuiTarefasPendentesAsync(idProjeto))
                 .WithMessage("O projeto possui tarefas pendentes. Conclua as tarefas ou remova-as do projeto antes de excluí-lo.");

            }).Otherwise(() =>
            {
                RuleFor(a => a).Must(a => false).WithMessage("Operação inválida. Projeto não encontrado.");
            });
        }

        public async Task<bool> OperacaoValida(RemoverProjetoCommand inputModel)
        {
            ValidationResult = await ValidateAsync(inputModel);
            return ValidationResult.IsValid;
        }
    }
}
