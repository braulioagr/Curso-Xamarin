using ListasDemo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListasDemo.Data
{
    public class FriendDataBase
    {
        private readonly SQLiteAsyncConnection database;

        public FriendDataBase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Friend>().Wait();
        }

        public async Task<List<Friend>> GetItemsAysinc()
        {
            return await database.Table<Friend>().ToListAsync();
        }


        public Task<Friend> GetItemAysinc(int id) {
            return database.Table<Friend>()
                .Where( i => i.Id == id )
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAysinc(Friend item)
        {
            if(item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAysinc(Friend item)
        {
            return database.DeleteAsync(item);
        }

    }
}
