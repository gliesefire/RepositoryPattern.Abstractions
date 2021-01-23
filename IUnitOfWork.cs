using System;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();
    }
}
