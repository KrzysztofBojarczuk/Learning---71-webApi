using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sklep.Dtos;
using sklep.InterfaceRepository;
using sklep.Models;

namespace sklep.Automapper
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopController(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShops()
        {
            var shops = await _shopRepository.GetAllShopAsync();
            var shopsGet = _mapper.Map<List<ShopGetDto>>(shops);
            return Ok(shopsGet);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopById(int id)
        {
            var shop = await _shopRepository.GetShopByIdAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            var shopGet = _mapper.Map<ShopGetDto>(shop);
            return Ok(shopGet);
        }
        [HttpPost]
        public async Task<IActionResult> CrateShop([FromBody] ShopCreateDto shop)
        {
            if (ModelState.IsValid)
            {

            }
            var domainShop = _mapper.Map<Shop>(shop);
            await _shopRepository.CreateShopAsync(domainShop);
            var shopGet = _mapper.Map<ShopGetDto>(domainShop);
            return CreatedAtAction(nameof(GetShopById), new { id = domainShop.ShopId }, shopGet);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop([FromBody] ShopCreateDto updated,int id)
        {
            var toUpdate = _mapper.Map<Shop>(updated);
            toUpdate.ShopId = id;

            await _shopRepository.UpdateShopAsync(toUpdate);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _shopRepository.DeleteShopAsync(id);

            if (shop == null)
            {
                return NotFound();
            }
            return NoContent();
        }



    }
}
