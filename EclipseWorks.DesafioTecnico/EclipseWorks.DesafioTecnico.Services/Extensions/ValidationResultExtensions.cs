using FluentValidation.Results;

namespace EclipseWorks.DesafioTecnico.Services.Extensions
{
    internal static class ValidationResultExtensions
    {
        public static string[] Criticas(this ValidationResult validationResult)
        {
            return validationResult?.Errors?.Select(a => a.ErrorMessage).Distinct()?.ToArray();
        }

        public static void AddErrors(this ValidationResult validationResult, string[] errors)
        {
            foreach (var error in errors)
            {
                validationResult.Errors.Add(new ValidationFailure(Guid.NewGuid().ToString(), error));
            }
        }
    }
}
