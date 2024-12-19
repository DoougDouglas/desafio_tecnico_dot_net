namespace EclipseWorks.DesafioTecnico.Api.Models
{
    internal sealed record ResponseModel<T> where T : class
    {
        public T Data { get; }
        public IReadOnlyCollection<string> Errors { get; }

        private ResponseModel(T data, IReadOnlyCollection<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public static ResponseModel<T> CreateSuccessResponse(T data = null)
        {
            return new ResponseModel<T>(data: data, errors: null);
        }

        public static ResponseModel<T> CreateNotFoundResponse(string message = "Recurso não encontrado")
        {
            return new ResponseModel<T>(data: null, new[] { message });
        }

        public static ResponseModel<T> CreateBadRequestResponse(IReadOnlyCollection<string> errors)
        {
            return new ResponseModel<T>(data: null, errors: errors);
        }

        public static ResponseModel<T> CreateInternalServerErrorResponse(string message = "Atenção, erro inesperado ao realizar a operação!")
        {
            return new ResponseModel<T>(data: null, errors: new[] { message });
        }
    }
}
