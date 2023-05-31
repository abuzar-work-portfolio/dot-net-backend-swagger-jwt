using MinimalJwt.Models;
using MinimalJwt.Repositories;

namespace MinimalJwt.Services
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRepository.Users.FirstOrDefault(o => o.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userLogin.Password));

            return user;
        }

        public User Create(User user)
        {
            user.Id = UserRepository.Users.Count + 1;
            UserRepository.Users.Add(user);

            return user;
        }

        public User GetById(int id)
        {
            var user = UserRepository.Users.FirstOrDefault(o => o.Id == id);

            if (user is null) return null;

            return user;
        }

        public List<User> UsersList()
        {
            var users = UserRepository.Users;

            return users;
        }

        public User Update(User newUser)
        {
            var oldUser = UserRepository.Users.FirstOrDefault(o => o.Id == newUser.Id);

            if (oldUser is null) return null;

            oldUser.Username = newUser.Username;
            oldUser.EmailAddress = newUser.EmailAddress;
            oldUser.Surname = newUser.Surname;
            oldUser.Role = newUser.Role;
            oldUser.GivenName = newUser.GivenName;
            oldUser.Password = newUser.Password;

            return newUser;
        }

        public bool Delete(int id)
        {
            var oldUser = UserRepository.Users.FirstOrDefault(o => o.Id == id);

            if (oldUser is null) return false;

            UserRepository.Users.Remove(oldUser);

            return true;
        }
    }
}
