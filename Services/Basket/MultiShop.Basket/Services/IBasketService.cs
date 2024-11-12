using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string id);
        Task SaveBasket(BasketTotalDto basket);
        Task DeleteBasket(string id);
    }
}
