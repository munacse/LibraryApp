using LibraryApp.Mongo.Interfaces;
using LibraryApp.Mongo.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace LibraryApp.Mongo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NoteContext _context = null;

        public ProductRepository(NoteContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product item)
        {
            try
            {
                await _context.Products.InsertOneAsync(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _context.Products.Find(p => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Product> GetProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq("Id", id);

            try
            {
                return await _context.Products.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
