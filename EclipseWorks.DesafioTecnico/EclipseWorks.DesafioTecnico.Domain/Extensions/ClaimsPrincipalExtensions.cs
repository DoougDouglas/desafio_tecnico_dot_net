using System.Security.Claims;

namespace EclipseWorks.DesafioTecnico.Domain.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(null, nameof(principal));
            }

            return Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
