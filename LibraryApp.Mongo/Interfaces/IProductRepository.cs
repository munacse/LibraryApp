using LibraryApp.Mongo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Mongo.Interfaces
{
    public interface IProductRepository
    {
        // add new note document
        Task AddProduct(Product item);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(string id);
    }
}
