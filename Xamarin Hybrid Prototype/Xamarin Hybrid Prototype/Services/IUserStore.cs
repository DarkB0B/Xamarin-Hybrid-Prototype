using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Hybrid_Prototype.Services
{
    public interface IUserStore<T>
    {
        Task<bool> AddUserAsync(T item);
        Task<bool> UpdateUserAsync(T item);
        Task<T> GetUserAsync(int id);
        Task<IEnumerable<T>> GetUsersAsync(bool forceRefresh = false);
    }
}
