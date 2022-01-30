using Microsoft.EntityFrameworkCore;
using sklep.Data;
using sklep.InterfaceRepository;
using sklep.Models;

namespace sklep.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _ctx;

        public ProductRepository(DataContext ctx)
        {
            
            _ctx = ctx;
        }

        public async Task<Product> CreateShopProductAsync(int shopId, Product product)
        {
            var shop = await _ctx.Shops.Include(h => h.Products)
                .FirstOrDefaultAsync(h => h.ShopId == shopId);

            shop.Products.Add(product);

            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteShopProductAsync(int shopId, int productId)
        {
            var product = await _ctx.Products.SingleOrDefaultAsync(r => r.ProductId == productId && r.ShopId == shopId);

            if (product == null)
            {
                return null;
            }
            _ctx.Products.Remove(product);

            await _ctx.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetShopProductByIdAsync(int shopId, int productId)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(r => r.ShopId == shopId && r.ProductId == productId);

            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<List<Product>> ListShopProductAsync(int shopId)
        {
            return await _ctx.Products.Where(r => r.ShopId == shopId).ToListAsync();
        }

        public async Task<Product> UpdateShopProductAsync(int shopId, Product updatedProduct)
        {
            _ctx.Products.Update(updatedProduct);
            await _ctx.SaveChangesAsync();

            return updatedProduct;
        }
    }
}
