using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin_Hybrid_Prototype.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddPartyAsync(T item);
        Task<bool> UpdatePartyAsync(T item);
        Task<bool> DeletePartyAsync(int id);
        Task<T> GetPartyAsync(int id);
        Task<IEnumerable<T>> GetPartiesAsync(bool forceRefresh = false);
    }
}
