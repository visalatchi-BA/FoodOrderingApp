using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using FoodOrderingApp.Model;

namespace FoodOrderingApp.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://app1-910c7-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Category>>GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category

                {
                    CategoryID = c.Object.CategoryID,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    ImageURL = c.Object.ImageURL
                }).ToList();
            return categories;
                   
        }

        
        
    }
}
