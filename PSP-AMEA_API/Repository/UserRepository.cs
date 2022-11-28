using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User() { Username = "Karolis", Password = "Karolaitis",  Id = Guid.NewGuid() },
            new User() { Username = "Jonas", Password = "Jonaitis",  Id = Guid.NewGuid() },
            new User() { Username = "Petras", Password = "Petraitis", Id = Guid.NewGuid() }
        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(Guid id)
        {
            return users.SingleOrDefault(user => user.Id == id);
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == user.Id);
            users[index] = user;
        }

        public void DeleteUser(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
        }

    }
}
