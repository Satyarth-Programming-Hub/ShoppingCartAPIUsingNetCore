using ShoppingCartApi.Models;

namespace ShoppingCartApi.Services.UserService
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        public User AddUser(User user);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
    }
}
