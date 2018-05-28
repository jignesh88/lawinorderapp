using System;
namespace LawInOrderApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool commit();
    }
}
