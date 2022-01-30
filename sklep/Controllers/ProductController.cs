using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sklep.Dtos;
using sklep.InterfaceRepository;
using sklep.Models;

namespace sklep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepositry;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepositry, IMapper mapper)
        {
            _productRepositry = productRepositry;
            _mapper = mapper;
        }
        [HttpGet("{shopId}/shops")]
        public async Task<IActionResult> GetAllProductsShop(int shopId)
        {
            var products = await _productRepositry.ListShopProductAsync(shopId);
            var mappedProducts = _mapper.Map<List<ProductGetDto>>(products);
            return Ok(mappedProducts);
        }
        [HttpGet("{shopId}/products/{productId}")]
        public async Task<IActionResult> GetShopProductById(int shopId, int productId)
        {
            var product = await _productRepositry.GetShopProductByIdAsync(shopId, productId);
            var mappedRoom = _mapper.Map<ProductGetDto>(product);

            return Ok(mappedRoom);

        }

        [HttpPost("{shopId}/products")]
        public async Task<IActionResult> AddShopProduct(int shopId, [FromBody] ProductCreateDto newRoom)
        {
            var product = _mapper.Map<Product>(newRoom);
            await _productRepositry.CreateShopProductAsync(shopId, product);

            var mappedProduct = _mapper.Map<ProductGetDto>(product);

            return CreatedAtAction(nameof(GetShopProductById), new { shopId = shopId, productId = mappedProduct.ProductId }, mappedProduct);

        }
        [HttpPut("{shopId}/products/{productId}")]
        public async Task<IActionResult> UpdateShopProduct(int shopId, int productId, [FromBody] ProductCreateDto updatedProduct)
        {
            var toUpdated = _mapper.Map<Product>(updatedProduct);
            toUpdated.ProductId = productId;
            toUpdated.ShopId = shopId;

            await _productRepositry.UpdateShopProductAsync(shopId, toUpdated);
            return NoContent();
        }
        [HttpDelete("{shopId}/products/{productId}")]
        public async Task<IActionResult> RemoveProductFromShop(int shopId, int productId)
        {
            var product = await _productRepositry.DeleteShopProductAsync(shopId, productId);

            if (product == null)
            {
                return NotFound("Product not Foudn");
            }
            return NoContent();
        }

    }
}
