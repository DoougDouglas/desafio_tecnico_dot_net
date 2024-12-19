using EclipseWorks.DesafioTecnico.Domain.Projetos.Repositories;
using EclipseWorks.DesafioTecnico.Domain.Tarefas.Commands;
using EclipseWorks.DesafioTecnico.Services.Extensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Services.Validators.Tarefas
{
    public class AdicionarTarefaValidator : AbstractValidator<AdicionarTarefaCommand>
    {
        private ValidationResult ValidationResult { get; set; }
        public string[] CriticasNegocio => ValidationResult.Criticas();

        public AdicionarTarefaValidator(IProjetoRepository projetoRepository)
        {
            WhenAsync(async (projeto, cancellationToken) => await projetoRepository.ProjetoExisteAsync(projeto.IdProjeto), () =>
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

                RuleFor(tarefa => tarefa.Prioridade)
                     .IsInEnum()
                     .WithMessage("O campo Prioridade é Invalido.");

                RuleFor(tarefa => tarefa)
                  .MustAsync(async (tarefa, cancellationToken) => await projetoRepository.RecuperarTotalTarefasProjetoAsync(tarefa.IdProjeto) < 20)
                  .WithMessage("O número máximo de tarefas por projeto é 20.");


            }).Otherwise(() =>
            {
                RuleFor(a => a).Must(a => false).WithMessage("Operação inválida. Projeto não encontrado.");
            });
        }

        public async Task<bool> OperacaoValida(AdicionarTarefaCommand inputModel)
        {
            ValidationResult = await ValidateAsync(inputModel);
            return ValidationResult.IsValid;
        }
    }
}
