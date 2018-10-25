using FoodRadar.Database.DatabaseModels;
using Plugin.Geolocator;
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
            resetDatabase();
            addData();

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

        public Task<int> SaveMealAsync(Meal item)
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

        public Task<List<Rating>> getRatings()
        {
            return database.Table<Rating>().ToListAsync();
        }

        public Meal getMealById(int id)
        {
            return database.Table<Meal>().Where(i => i.Id == id).FirstOrDefaultAsync().Result;
        }

        public Restaurant getRestaurantById(int id)
        {
            return database.Table<Restaurant>().Where(i => i.Id == id).FirstOrDefaultAsync().Result;
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

        public Task<int> SaveRating(Rating item)
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

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static double CalculateDistance(Xamarin.Forms.Labs.Services.Geolocation.Position location1, Xamarin.Forms.Labs.Services.Geolocation.Position location2)
        {
            double circumference = 40000.0; // Earth's circumference at the equator in km
            double distance = 0.0;

            //Calculate radians
            double latitude1Rad = DegreesToRadians(location1.Latitude);
            double longitude1Rad = DegreesToRadians(location1.Longitude);
            double latititude2Rad = DegreesToRadians(location2.Latitude);
            double longitude2Rad = DegreesToRadians(location2.Longitude);

            double logitudeDiff = Math.Abs(longitude1Rad - longitude2Rad);

            if (logitudeDiff > Math.PI)
            {
                logitudeDiff = 2.0 * Math.PI - logitudeDiff;
            }

            double angleCalculation =
                Math.Acos(
                    Math.Sin(latititude2Rad) * Math.Sin(latitude1Rad) +
                    Math.Cos(latititude2Rad) * Math.Cos(latitude1Rad) * Math.Cos(logitudeDiff));

            distance = circumference * angleCalculation / (2.0 * Math.PI);

            return distance;
        }

        // ALL SEARCH FUNCTIONS *************************************
        public List<Meal> SearchMeals(string searchString, Xamarin.Forms.Labs.Services.Geolocation.Position userPos = null,int distanceFilter = 0, int priceFilter = 0)
        {
            var cuisines = database.Table<Cuisine>().ToListAsync().Result;
            Cuisine cuisineResults = database.Table<Cuisine>().Where(i => i.name.ToLower() == searchString.ToLower()).FirstOrDefaultAsync().Result;
            List<Meal> mealResults = database.Table<Meal>().Where(i => i.name.ToLower().Contains(searchString.ToLower()) ).ToListAsync().Result;
            List<Meal> meals = new List<Meal>();

            var ms = database.Table<Meal>().ToListAsync().Result;

            if (cuisineResults != null) meals.AddRange(getMealsByCuisine(cuisineResults.Id));
            if(mealResults != null) meals.AddRange(mealResults);

            List<int> mealsToRemove = new List<int>();
            if (distanceFilter != 0 && userPos != null)
            {
                
                //userPos = getUserPos().Result;
                foreach(var m in meals)
                {
                    Restaurant rest = GetRestaurantById(m.restaurantId);

                    var restPos = new Xamarin.Forms.Labs.Services.Geolocation.Position()
                    {
                        Latitude = rest.lat,
                        Longitude = rest.lon
                    };


                    var distance = CalculateDistance(restPos, userPos);
                    if (distance > (distanceFilter/1000)) mealsToRemove.Add(m.Id);
                }
                foreach (var i in mealsToRemove)
                {
                    meals.RemoveAll(meal => meal.Id == i);
                }
            }
            if(priceFilter != 0)
            {
                mealsToRemove = new List<int>();
                foreach(var m in meals)
                {
                    if (m.price < priceFilter) mealsToRemove.Add(m.Id);
                }
                foreach(var i in mealsToRemove)
                {
                    meals.RemoveAll(meal => meal.Id == i);
                }
            }

            return meals;
        }
        
        private async Task<Xamarin.Forms.Labs.Services.Geolocation.Position> getUserPos()
        {
            Xamarin.Forms.Labs.Services.Geolocation.Position userPos = new Xamarin.Forms.Labs.Services.Geolocation.Position();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync();

            userPos.Latitude = position.Latitude;
            userPos.Longitude = position.Longitude;

            return userPos;
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

        public Cuisine GetCuisineById(int id)
        {
            Cuisine c = database.Table<Cuisine>().Where(i => i.Id == id).FirstOrDefaultAsync().Result;
            return c;
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

            double orig1 = -27.4707 - 0.015;
            double orig2 = 153.024 - 0.015;
            double bla;
            double bla2;
            Random rnd = new Random();


            for (int i = 0; i < RestaurantName.Count; i++)
            {
                int rnd1 = rnd.Next(1, 150);
                int rnd2 = rnd.Next(1, 150);
                bla = orig1 + (0.0001 * rnd1);

                bla2 = orig2 + (0.0001 * rnd2);
                


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

                SaveItemAsync(restaurant);
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
                SaveItemAsync(cuisine);
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
"Piri piri chicken"
};

for (int i = 0; i< Cuisines.Count; i++)
{

for(int j = 0; j< 5; j++)
{

                    Meal meal = new Meal
                    {
                        name = MealName[i * 5 + j],

                        cuisineId = GetCuisineId(Cuisines[i]),

                        restaurantId = GetRestaurantId(RestaurantName[(i * 5) + j]),

                        price = rnd.Next(10, 51),

                        rating = rnd.Next(1, 6),

                    };
                    SaveItemAsync(meal);
  } 
}







        }


            


         public Task<int> DeleteRatingAsync(Rating item)
        {
            return database.DeleteAsync(item);
        }

    }
}
