using EclipseWorks.DesafioTecnico.Domain.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EclipseWorks.DesafioTecnico.Domain
{

    public interface IUser
    {
        Guid Id { get; }
        string Name { get; }
        bool Authenticated { get; }
        IEnumerable<Claim> ClaimsIdentity { get; }
    }

    public class AspNetUser(IHttpContextAccessor accessor) : IUser
    {
        private readonly IHttpContextAccessor _accessor = accessor;

        public Guid Id
        {
            get
            {
                if (Authenticated)
                {
                    return _accessor.HttpContext.User.GetUserId();
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> ClaimsIdentity => _accessor.HttpContext.User.Claims;

        public bool Authenticated => _accessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
