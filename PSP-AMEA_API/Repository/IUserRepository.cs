using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}