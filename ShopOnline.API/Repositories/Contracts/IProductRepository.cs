using ShopOnline.API.Entities;

namespace ShopOnline.API.Repositories.Contracts
{
    public interface IProductRepository
    {
        //Returning lists/collections sometime in future (asynchronously)
        //These methods retrieve data from database
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);
    }
}
