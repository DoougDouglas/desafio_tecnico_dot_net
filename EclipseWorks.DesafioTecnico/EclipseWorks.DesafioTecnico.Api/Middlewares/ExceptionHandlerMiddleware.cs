using EclipseWorks.DesafioTecnico.Api.Models;
using EclipseWorks.DesafioTecnico.Domain.Exceptions;
using EclipseWorks.DesafioTecnico.Api.Extensions;
using System.Net;

namespace EclipseWorks.DesafioTecnico.Api.Middlewares
{
    internal sealed class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionHandlerMiddleware> logger)
        {
            context.Response.ContentType = "application/json";

            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                var response = ResponseModel<string>.CreateNotFoundResponse(ex.Message);
                await HandleErrorAsync(context, response, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + ": Erro inesperado ao realizar a operação.");
                var response = ResponseModel<string>.CreateInternalServerErrorResponse(ex.Message);

                await HandleErrorAsync(context, response, HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleErrorAsync(HttpContext httpcontext, ResponseModel<string> response, HttpStatusCode statusCode)
        {
            httpcontext.Response.StatusCode = (int)statusCode;
            await httpcontext.Response.WriteAsync(response.Serialize());
        }
    }
}
