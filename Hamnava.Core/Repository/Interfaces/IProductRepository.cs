using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamnava.Core.Repository.Interfaces
{
    public interface IProductRepository
    {
        #region Product
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllProductAsync();
        #endregion


        #region ProductBrands
        Task<ProductBrand> GetProductBrandByIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
        #endregion


        #region ProductTypes
        Task<ProductType> GetProductTypeByIdAsync(int id);
        Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
        #endregion


    }
}
