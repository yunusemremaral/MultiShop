using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShot.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
