using System.Collections.Generic;
using Domain.Domain.Model.Users;
using MyLibrary.Options;

namespace InMemoryDataStore.Users {
    public class UserRepository : IUserRepository {
        private Dictionary<UserId, User> db = new Dictionary<UserId, User>();

        public Option<User> Find(UserId id)
        {
            if (db.TryGetValue(id, out var user)) {
                return Option<User>.Create(user);
            } else {
                return Option<User>.None();
            }
        }
    }
}
