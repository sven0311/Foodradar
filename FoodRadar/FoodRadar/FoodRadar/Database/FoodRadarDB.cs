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

        public void addData()
        {


            List<string> RestaurantName = new List<string>() { "Applebee's",
"Big Smoke Burger",
"Buffalo Wild Wings",
"Chili's",
"Domino's",
"Asia Town",
"Din Tai Fung",
"Joe's Shanghai",
"Panda Inn",
"Tom's BaoBao",
"Les Amis",
"Caprice",
"Galatoire's",
"RIA",
"Pierre",
"Mr. Greek ",
"Jimmy the Greek ",
"Alexis Restaurant",
"Taverna",
"Papa Cristo's",
"Indian Mehfil",
"My Desi Twist Indian Counter",
"Punjabi Rasoi",
"Karma",
"Palace",
"Bella Italia",
"Mosconi",
"The Pizza Company",
"Tony Macaroni",
"Veniero's",
"Sake Restaurant & Bar",
"Mitoki Japanese Modern Tapas",
"Kabuki Teppanyaki Restaurant",
"Sushi Seki",
"Zuma",
"Comuna Cantina",
"La Quinta Mexican Cafe & Bar",
"Big City Burrito",
"Casa Bonita",
"Don Pablo's",
"Siam Square Thai Restaurant",
"Kasalong Thai Restaurant",
"Spice I Am",
"Moon Restaurant",
"Longrain",
};

            List<string> Description = new List<string>() {
"Our newly refurbished and extended restaurant has been designed with a warm and contemporary feel, carefully designed to enable space yet intimacy.",
"Ensuring that better food, prepared from whole, unprocessed ingredients is accessible to everyone. ",
"Our mission today is the same as it’s always been: That every guest who chooses us leaves happy.",
"To help citizens of the world live better by making healthy food convenient & affordable.",
"Bettering people's days.",
"Becoming a real part of every neighborhood we open in.",
};


            List<string> Address = new List<string>()  {
"163 Kingston Street North Royalton, OH 44133",
"699 Third Ave. Morganton, NC 28655",
"9052 West Beach Dr. Billings, MT 59101",
"367 Sunnyslope St. Sioux City, IA 51106",
"528 S. Vine Ave. Tiffin",
"86 Sunnyslope Dr. Eastlake",
"3983 Quiet Valley Lane",
"",
};

            List<string> OpeningHours = new List<string>() {
"8:00 - 16:00",
"9:00 - 19:00",
"12:00 - 23:00",
"13:00 - 21:00",
"14:00 - 21:00",
"16:00 - 00:00",
"10:00 - 22:00",
"11:00 - 22:00",
"10:00 - 16:00",
"10:00 - 17:00",
};


            //medaltal af meal price
            List<int> Price = new List<int>() { 1, 2, 3, 4, 5 };

            //needs to be updated

            List<int> Rating = new List<int>() { 1, 2, 3, 4, 5 };

            List<string> Url = new List<string>() {
"ka.com",
"restaurantmadness.com",
"whatisfordinner.com",
"restaurants.com",
"mymeal.com",
};

///pupulate database

            double bla = -27.470125;
            double bla2 = 53.021072;
            Random rnd = new Random();


            for (int i = 0; i < RestaurantName.Count; i++)
            {
                bla = bla + 0.0001 * rnd.Next(1, 101);
                bla2 = bla2 + 0.0001 * rnd.Next(1, 101);

                Restaurant restaurant = new Restaurant
                {
                    name = RestaurantName[i],

                    desc = Description[rnd.Next(0, Description.Count - 1)],

                    lat = bla,

                    lon = bla2,

                    address = Address[rnd.Next(0, Address.Count - 1)],

                    price = Price[rnd.Next(0, Price.Count - 1)],

                    openingHours = OpeningHours[rnd.Next(0, OpeningHours.Count - 1)],

                    url = Url[rnd.Next(0, Url.Count - 1)],

                };
            }


            //////

            List<string> Cuisines = new List<string>() {
"Armenian",
"Chinese",
"French",
"Greek",
"Indian",
"Italian",
"Japanese",
"Mexican",
"Thai",
};

for (int i = 0; i< Cuisines.Count; i++)
{

                Cuisine cuisine = new Cuisine
                {
                    name = Cuisines[i],

                };

}

            //////

            List<string> MealName = new List<string>() {
"Pizza Pepparoni",
"Pizza Vegetarian",
"Vegan Pizza",
"Babyback Ribs",
"Egg Noodles",
"Chicken Noodles",
"Rice Bowl",
"Egg Rice",
"Spicy Noodles",
"onion soup",
"Chicken confit",
"Confit de canard",
"Cassoulet",
"Beef bourguignon",
"Taramasalata",
"Olives and olive oil",
"Dolmades",
"Grilled meat ",
"Feta & cheeses",
"Rogan Josh",
"Samosas",
"Matar Paneer",
"Tandoori Chicken",
"Malai Kofta",
"Bruschetta",
"Margherita Pizza",
"Pasta Carbonara",
"Mushroom Risotto",
"Lasagna",
"Tempura",
"Udon",
"Avacado Maki sushi ",
"Salmon Maki sushi",
"Rice and fish",
"Chicken Tostadas",
"Yellow Rice",
"Quesadillas",
"Salsa and Chips.",
"Pinto Bean Salsa Salad",
"picy Shrimp Soup",
"Spicy Green Papaya Salad",
"Thai style Fried Noodles",
"Fried Rice",
"Green Chicken Curry",
};

for (int i = 0; i< Cuisines.Count; i++)
{

for(int j = 1; j< 6; j++)
{

                    Meal meal = new Meal
                    {

                        name = MealName[i * 5 + j],

                        cuisineId = i,

                        restaurantId = (i * 5) + j,

                        price = rnd.Next(10, 51),

                        rating = rnd.Next(1, 6),

                    };
  } 
}







        }


            

    }
}
