using Data.Entities;
using Hamnava.Core.PublicClasses;
using System.Threading.Tasks;

namespace Hamnava.Core.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task Dispose();
        GenericClasses<Product> productUW { get; }
        GenericClasses<ProductBrand> productBrandUW { get; }
        GenericClasses<ProductType> productTypeUW { get; }
    }
}
