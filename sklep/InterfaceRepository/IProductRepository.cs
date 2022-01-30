using sklep.Models;

namespace sklep.InterfaceRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> ListShopProductAsync(int shopId);
        Task<Product> GetShopProductByIdAsync(int shopId, int productId);
        Task<Product> CreateShopProductAsync(int shopId, Product product);
        Task<Product> UpdateShopProductAsync(int shopId,Product updatedProduct);
        Task<Product> DeleteShopProductAsync(int shopId, int productId);
    }
}
