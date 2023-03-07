using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.Services
{
    public class MockUserStore : IUserStore<User>
    {

        private readonly List<Party> parties;
        private readonly List<User> users;
        public MockUserStore()
        {
            users = new List<User>()
            {
                new User {Name = "John", Surname = "Doe", PhoneNumber = "665666555" }
            };

        }
        public async Task<bool> AddUserAsync(User user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var oldItem = users.Where((User arg) => arg.PhoneNumber == user.PhoneNumber).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(user);

            return await Task.FromResult(true);
        }

        

        async Task<User> IUserStore<User>.GetUserAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.PhoneNumber == id));
        }

        async Task<IEnumerable<User>> IUserStore<User>.GetUsersAsync(bool forceRefresh)
        {
            return await Task.FromResult(users);
        }
        

    }
}
