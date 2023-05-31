using MinimalJwt.Models;

namespace MinimalJwt.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
        public User Create(User user);
        public User GetById(int id);
        public List<User> UsersList();
        public User Update(User user);
        public bool Delete(int id);
    }
}
