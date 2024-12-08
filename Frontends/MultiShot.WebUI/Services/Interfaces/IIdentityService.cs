using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShot.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
    }
}
