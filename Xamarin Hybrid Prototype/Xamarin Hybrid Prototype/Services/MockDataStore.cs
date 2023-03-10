using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.Services
{
    public class MockDataStore : IDataStore<Party>
    {
        
        private readonly List<Party> parties;
        private List<User> organisers = new List<User>{new User{Name = "Organiser", Surname = "Organiser", PhoneNumber = "424242424"}};
        
        public MockDataStore()
        {
            
            
            parties = new List<Party>()
            {
                new Party {  Id = 0, Name = "Dance Party", Description = "90's Disco Music Party", Date = new DateTime(2024,11,15), Users = organisers },
                new Party {  Id = 1, Name = "Train Lovers Meeting", Description = "Place to show your favourite trains", Date = new DateTime(2024,12,15), Users = organisers},
                new Party {  Id = 2, Name = "Fun And Fun", Description = "Good Beer", Date = new DateTime(2024,12,16), Users = organisers}
            };
        }

         
        public async Task<bool> AddPartyAsync(Party party)
        {
            parties.Add(party);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePartyAsync(int id)
        {
            var oldItem = parties.Where((Party arg) => arg.Id == id).FirstOrDefault();
            parties.Remove(oldItem);

            return await Task.FromResult(true);
        }

        

        public async Task<bool> UpdatePartyAsync(Party party)
        {
            var oldItem = parties.Where((Party arg) => arg.Id == party.Id).FirstOrDefault();
            parties.Remove(oldItem);
            parties.Add(party);

            return await Task.FromResult(true);
        }
        public async Task<Party> GetPartyAsync(int id)
        {
            return await Task.FromResult(parties.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Party>> GetPartiesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(parties);
        }

    }

    
}