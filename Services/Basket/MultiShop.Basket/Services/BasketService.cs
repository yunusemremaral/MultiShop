using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string id)
        {
            await _redisService.GetDb().KeyDeleteAsync(id);
        }

        public async Task<BasketTotalDto> GetBasket(string id)
        {
            var existbasket= await _redisService.GetDb().StringGetAsync(id);
            return JsonSerializer.Deserialize<BasketTotalDto>(existbasket);

        }

        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}
