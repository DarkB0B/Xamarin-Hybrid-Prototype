﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin_Hybrid_Prototype.Models;

namespace Xamarin_Hybrid_Prototype.Services
{
    public class FakeDb : IDataStore<Party>
    {
        User user = new User { Id = 1, Name = "George", Surname = "Gergeowsky", PhoneNumber = 666666666 };
        private readonly List<Party> parties;

        public FakeDb()
        {
            parties = new List<Party>()
            {
                new Party {  Id = 1, Name = "Dance Party", Description = "90's Disco Music Party", Date = new DateTime(2024,11,15), Organiser = user},
                new Party {  Id = 2, Name = "Train Lovers Meeting", Description = "Place to show your favourite trains", Date = new DateTime(2024,12,15), Organiser = user},
                new Party {  Id = 3, Name = "Fun And Fun", Description = "Good Beer", Date = new DateTime(2024,12,16), Organiser = user}
            };
        }
        public async Task<bool> AddItemAsync(Party party)
        {
            parties.Add(party);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = parties.Where((Party arg) => arg.Id == id).FirstOrDefault();
            parties.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateItemAsync(Party party)
        {
            var oldItem = parties.Where((Party arg) => arg.Id == party.Id).FirstOrDefault();
            parties.Remove(oldItem);
            parties.Add(party);

            return await Task.FromResult(true);
        }
        public async Task<Party> GetItemAsync(int id)
        {
            return await Task.FromResult(parties.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Party>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(parties);
        }

    }

    
}