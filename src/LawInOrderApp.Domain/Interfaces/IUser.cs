using System;
using System.Security.Claims;
namespace LawInOrderApp.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string Role { get; }
        bool IsAuthenticated();
        IEquatable<Claim> GetClaimsIdentity();
    }
}
