using AutoMapper;
using Data.Entities;
using Hamnava.Core.Repository.Interfaces;
using Hamnava.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
   
    public class ProductController : BaseApiController
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var products = await _context.productUW.GetAllAsync(null, null, "ProductType,ProductBrand");
            return _mapper.Map<List<ProductToReturnDto>>(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProductById(int id)
        {
            var product = await _context.productUW.GetAllAsync(x=> x.Id == id, null, "ProductType,ProductBrand");

            return _mapper.Map<List<ProductToReturnDto>>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _context.productBrandUW.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _context.productTypeUW.GetAllAsync());
        }
    }
}
