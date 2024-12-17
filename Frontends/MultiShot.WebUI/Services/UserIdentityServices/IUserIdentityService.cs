using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShot.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
