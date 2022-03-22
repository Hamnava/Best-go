
using System.Threading.Tasks;

namespace Hamnava.Core.Repository.Interfaces
{
    public interface IEntityDatabaseTransaction
    {
        Task Commit();
        Task RollBack();
    }
}
