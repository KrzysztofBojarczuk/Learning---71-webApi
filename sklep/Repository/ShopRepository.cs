using Microsoft.EntityFrameworkCore;
using sklep.Data;
using sklep.InterfaceRepository;
using sklep.Models;

namespace sklep.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly DataContext _ctx;

        public ShopRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Shop> CreateShopAsync(Shop shop)
        {
            _ctx.Shops.Add(shop);
            await _ctx.SaveChangesAsync();
            return shop;
        }

        public async Task<Shop> DeleteShopAsync(int id)
        {
            var shop = await _ctx.Shops.FirstOrDefaultAsync(h => h.ShopId == id);

            if (shop == null)
            {
                return null;
            }
            _ctx.Shops.Remove(shop);
            await _ctx.SaveChangesAsync();
            return shop;
        }

        public async Task<List<Shop>> GetAllShopAsync()
        {
            return await _ctx.Shops.ToListAsync();
        }

        public async Task<Shop> GetShopByIdAsync(int id)
        {
            var shop = await _ctx.Shops.Include(h => h.Products).FirstOrDefaultAsync(h => h.ShopId == id);

            if (shop == null)
            {
                return null;
            }
            return shop;
        }

        public async Task<Shop> UpdateShopAsync(Shop updatedShop)
        {
            _ctx.Shops.Update(updatedShop);
            await _ctx.SaveChangesAsync();
            return updatedShop;
        }
    }
}
