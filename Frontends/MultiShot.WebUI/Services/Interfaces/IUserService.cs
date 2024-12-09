using MultiShot.WebUI.Models;

namespace MultiShot.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
