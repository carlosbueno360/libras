using System.Collections.Generic;
using System.Security.Claims;

namespace TecLibras.UI.Web.Models
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}