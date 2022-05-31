using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Domain.DTOs;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IUsersService
    {
        Task<UserDTO> Login(string email, string password);
        Task<UserDTO> Register(RegisterDTO input);
        Task<object> ChangePassword(int userId, ChangePasswordDTO input);
        Task<object> EditProfile(int userId, EditProfileDTO input);
        Task<UserDTO> GetProfile(int userId);
    }
}
