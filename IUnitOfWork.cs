using System.Threading.Tasks;

namespace RepositoryPattern.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
