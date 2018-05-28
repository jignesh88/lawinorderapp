using System;
namespace LawInOrderApp.Domain.Core.Events
{
    public interface IHandler<in T> where T: Message
    {
        void Handle(T Message);
    }
}
