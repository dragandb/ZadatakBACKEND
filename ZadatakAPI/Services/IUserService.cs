using Microsoft.AspNetCore.Identity;
using ZadatakAPI.Models;
using ZadatakAPI.Models.DTO;

namespace ZadatakAPI.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterUserModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginUserModel model);
    }

    
}
