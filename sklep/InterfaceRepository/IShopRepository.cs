using sklep.Models;

namespace sklep.InterfaceRepository
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetAllShopAsync();
        Task<Shop> GetShopByIdAsync(int id);
        Task<Shop> CreateShopAsync(Shop shop);
        Task<Shop> UpdateShopAsync(Shop updatedShop);
        Task<Shop> DeleteShopAsync(int id);
    }
}
