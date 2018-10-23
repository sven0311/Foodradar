using FoodRadar.Database.DatabaseModels;
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
            database.CreateTableAsync<Restaurant>().Wait();
            database.CreateTableAsync<Cuisine>().Wait();
            database.CreateTableAsync<Meal>().Wait();
            database.CreateTableAsync<Rating>().Wait();
        }

        public void resetDatabase()
        {
            database.DeleteAllAsync<Customer>();
            database.DeleteAllAsync<Restaurant>();
            database.DeleteAllAsync<Cuisine>();
            database.DeleteAllAsync<Rating>();
            database.DeleteAllAsync<Meal>();
        }

        public Task<int> SaveCustomerAsync(Customer item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<Customer> GetCustomerAsync(int id)
        {
            return database.Table<Customer>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<Customer> CheckEmail(string email) //??
        {
            return database.Table<Customer>().Where(i => i.email == email).FirstOrDefaultAsync();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return database.Table<Customer>().ToListAsync();
        }

        public Task<int> SaveRestaurant(Restaurant item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<List<Restaurant>> GetRestaurants()
        {
            return database.Table<Restaurant>().ToListAsync();
        }

        public Customer getPassword(String email)
        {
            
        string queryString = "SELECT * FROM [Customer] WHERE [email] = " + email;
            Customer c = database.Table<Customer>().Where(i => i.email == email).FirstOrDefaultAsync().Result;
        /*
            if (l.Count == 0)
            {
                return null;
            }
            if (l.Count != 1)
            {
                throw new Exception("more than 1 user with same email");
            }*/

            return c;
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
