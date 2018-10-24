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
            /*SQLiteCommand command = new SQLiteCommand(database);
            command.CommandText = "Query ";
            command.ExecuteQuery<Customer>(); */
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


        public Task<int> SaveItemAsync(Customer item)
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

        public Task<int> SaveItemAsync(Restaurant item)
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

        public Task<int> SaveItemAsync(Meal item)
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

        public Task<int> SaveItemAsync(Cuisine item)
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

        public Task<List<Rating>> getRatingsforCustomer(int id)
        {
            return database.Table<Rating>().Where(i => i.customerId == id).ToListAsync();
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

        public Restaurant GetRestaurantById(int id)
        {
            return database.Table<Restaurant>().Where(i => i.Id == id).FirstOrDefaultAsync().Result;
        }


        // ALL SEARCH FUNCTIONS *************************************
        public List<Meal> SearchMeals(string searchString)
        {
            Cuisine cuisineResults = database.Table<Cuisine>().Where(i => i.name.ToLower() == searchString.ToLower()).FirstOrDefaultAsync().Result;
            List<Meal> mealResults = database.Table<Meal>().Where(i => i.name.ToLower().Contains(searchString.ToLower()) ).ToListAsync().Result;
            List<Meal> meals = new List<Meal>();
            
            if(cuisineResults != null) meals.AddRange(getMealsByCuisine(cuisineResults.Id));
            if(mealResults != null) meals.AddRange(mealResults);
            return meals;
        }


        public List<Meal> getMealsByCuisine(int cuisineId)
        {
            return database.Table<Meal>().Where(i => i.cuisineId == cuisineId).ToListAsync().Result;
            
        }
        // ALL SEARCH FUNCTIONS **************************************
        public Task<List<Meal>> GetMeals()
        {
            return database.Table<Meal>().ToListAsync();
        }

        public int GetCuisineId(string cuisine)
        {
            Cuisine c = database.Table<Cuisine>().Where(i => i.name == cuisine).FirstOrDefaultAsync().Result;
            return c.Id;
        }

        public int GetRestaurantId(string restaurant)
        {
            Restaurant r = database.Table<Restaurant>().Where(i => i.name == restaurant).FirstOrDefaultAsync().Result;
            return r.Id;
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
