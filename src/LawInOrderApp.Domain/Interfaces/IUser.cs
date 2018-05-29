using System.Security.Claims;
using System.Collections.Generic;
namespace LawInOrderApp.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string Role { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
