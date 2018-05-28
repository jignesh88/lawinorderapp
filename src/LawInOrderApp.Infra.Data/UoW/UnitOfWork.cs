using System;
using LawInOrderApp.Domain.Interfaces;
using LawInOrderApp.Infra.Data.Context;

namespace LawInOrderApp.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LawInOrderAppContext _context;

        public UnitOfWork(LawInOrderAppContext context)
        {
            _context = context;
        }


        public bool commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
