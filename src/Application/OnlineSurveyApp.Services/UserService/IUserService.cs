using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.DTOs.Responses.UserResponses;
using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDisplayResponse>> GetAllUsersAsync();
        Task<UserDisplayResponse> GetUserByIdAsync(int userId);
        Task CreateUserAsync(CreateNewUserRequest createNewUserRequest);
        Task UpdateUserAsync(UpdateUserRequest updateUserRequest);
        Task DeleteAsync(int userId);
        Task<bool> UserIsExistsAsync(int userId);
        Task<User?> ValidateUserAsync(string username, string password);
    }
}
