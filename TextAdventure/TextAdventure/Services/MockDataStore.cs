using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAdventure.Models;

namespace TextAdventure.Services
{
    public class MockDataStore : IDataStore<old_Item>
    {
        readonly List<old_Item> items;

        public MockDataStore()
        {
            items = new List<old_Item>()
            {
                new old_Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new old_Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new old_Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new old_Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new old_Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new old_Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(old_Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(old_Item item)
        {
            var oldItem = items.Where((old_Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((old_Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<old_Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<old_Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}