using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShot.WebUI.Services.OrderServices.OrderOderingServices
{
    public interface IOrderOderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
