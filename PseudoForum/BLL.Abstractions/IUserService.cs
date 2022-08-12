using Core;
using Core.ViewModels;

namespace BLL.Abstractions
{
    public interface IUserService
    {
        Task<User> IsItRightCredentials(UserViewModel user);

        Task<bool> RegisterNewUser(User newUser);
    }
}
