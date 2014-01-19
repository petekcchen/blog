using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewObserver
{
    public static class Repository
    {
        private static List<User> _users = new List<User>();

        static Repository()
        {
            _users.Add(new User()
            {
                Id = 1,
                FirstName = "Pete",
                LastName = "Chen",
                PhoneNumber = "09xx123456"
            });

            _users.Add(new User()
            {
                Id = 2,
                FirstName = "Claire",
                LastName = "Chang",
                PhoneNumber = "09xx234567"
            });

            _users.Add(new User()
            {
                Id = 3,
                FirstName = "Pudding",
                LastName = "Chen",
                PhoneNumber = "09xx345678"
            });

            _users.Add(new User()
            {
                Id = 4,
                FirstName = "Jelly",
                LastName = "Chen",
                PhoneNumber = "09xx456789"
            });

        }

        public static void Update(User user)
        {
            User current = _users.Single(c => c.Id == user.Id);
            current = user;
        }

        public static IList<User> GetUsers()
        {
            return _users;
        }
    }
}
