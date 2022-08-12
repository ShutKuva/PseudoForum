using BLL.Abstractions;
using Core;
using Core.ViewModels;
using DAL.Abstractions;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> IsItRightCredentials(UserViewModel user)
        {
            IQueryable<User> actualUser = await _repository.GetByCondition(dbUser => (dbUser.Username == user.Login || dbUser.Email == user.Login) && dbUser.Password == user.Password);
            return actualUser.FirstOrDefault();
        }

        public async Task<bool> RegisterNewUser(User newUser)
        {
            IQueryable<User> user = await _repository.GetByCondition(dbUser => dbUser.Username == newUser.Username || dbUser.Email == newUser.Email);

            if (user.Count() > 0)
            {
                return false;
            }

            await _repository.Create(newUser);

            return true;
        }
    }
}
