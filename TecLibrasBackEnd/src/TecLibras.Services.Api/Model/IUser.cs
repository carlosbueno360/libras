using System.Collections.Generic;
using System.Security.Claims;

namespace TecLibras.Services.Api.Model
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}