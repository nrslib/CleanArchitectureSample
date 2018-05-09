using MyLibrary.Options;

namespace Domain.Domain.Model.Users {
    public interface IUserRepository
    {
        Option<User> Find(UserId id);
    }
}
