
using System;

namespace AlternativaTest.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}