using FoodRadar.DB.DataModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodRadar.DB
{
    public class FoodRadarDB
    {
        public SQLiteAsyncConnection database { get; }
        public FoodRadarDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Customer>().Wait();
        }

        public Task<int> SaveItemAsync(Customer item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<Customer> GetItemAsync(int id)
        {
            return database.Table<Customer>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
     
        public Task<List<Customer>> GetItemsAsync()
        {
            return database.Table<Customer>().ToListAsync();
        }
        /*
         public Task<List<TodoItem>> GetItemsNotDoneAsync()
         {
           return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
         }

         public Task<TodoItem> GetItemAsync(int id)
         {
           return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
         }

         public Task<int> SaveItemAsync(TodoItem item)
         {
           if (item.ID != 0)
           {
             return database.UpdateAsync(item);
           }
           else {
             return database.InsertAsync(item);
           }
         }

         public Task<int> DeleteItemAsync(TodoItem item)
         {
           return database.DeleteAsync(item);
         }
         */
    }
}
