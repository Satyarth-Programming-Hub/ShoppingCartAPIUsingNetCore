using ShoppingCartApi.DatabaseContext;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApiDbContext _dbContext;

        public UserService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User AddUser(User user)
        {
            var addedUser = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return addedUser.Entity;
        }

        public User UpdateUser(User user)
        {
            var updatedUser = _dbContext.Update(user);
            _dbContext.SaveChanges();
            return updatedUser.Entity;
        }

        public User DeleteUser(User user)
        {
            var deletedUser = _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return deletedUser.Entity;
        }

    }
}
