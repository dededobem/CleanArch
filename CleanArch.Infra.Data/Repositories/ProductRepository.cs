using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }        

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(int? id) =>
            await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetProducts() => await _context.Products.ToListAsync();

        public async Task Update(Product product)
        {
             _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
