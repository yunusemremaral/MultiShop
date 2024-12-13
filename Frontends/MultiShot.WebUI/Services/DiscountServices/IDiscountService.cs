using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShot.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
