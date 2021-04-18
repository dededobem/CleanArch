using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductViewModel product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            await _productRepository.Add(mapProduct);
        }

        public async Task Delete(int? id)
        {
            var result = await _productRepository.GetById(id);
            await _productRepository.Delete(result);
        }

        public async Task<ProductViewModel> GetById(int? id)
        {
            var result = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(result);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var list = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(list);
        }

        public async Task Update(ProductViewModel product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            await _productRepository.Update(mapProduct);
        }
    }
}
