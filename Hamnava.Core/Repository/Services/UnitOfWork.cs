using Data.ApplicationContext;
using Data.Entities;
using Hamnava.Core.PublicClasses;
using Hamnava.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamnava.Core.Repository.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        private GenericClasses<Product> _product;
        private GenericClasses<ProductBrand> _productBrand;
        private GenericClasses<ProductType> _productType;

        // It is for ProductType 
        public GenericClasses<ProductType> productTypeUW
        {
            get
            {
                if (_productType == null)
                {
                    _productType = new GenericClasses<ProductType>(_context);
                }
                return _productType;
            }
        }


        // It is for ProductBrand
        public GenericClasses<ProductBrand> productBrandUW
        {
            get
            {
                if (_productBrand == null)
                {
                    _productBrand = new GenericClasses<ProductBrand>(_context);
                }
                return _productBrand;
            }
        }


        // It is for Product 
        public GenericClasses<Product> productUW
        {
            get
            {
                if (_product == null)
                {
                    _product = new GenericClasses<Product>(_context);
                }
                return _product;
            }
        }
        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }

       
    }
}
