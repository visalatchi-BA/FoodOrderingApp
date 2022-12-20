using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderingApp.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient("https://app1-910c7-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Burger",
                    CategoryPoster = "MainBurger",
                    ImageURL = "Pizza.png",
                },
                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Pizza",
                    CategoryPoster = "MainPizza",
                    ImageURL = "Pizza.png",
                },
                new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Grill",
                    CategoryPoster = "MainGrill",
                    ImageURL = "Grill.jpg",
                },
                new Category()
                {
                    CategoryID = 4,
                    CategoryName = "Briyani",
                    CategoryPoster = "MainBriyani",
                    ImageURL = "Briyani.jpg",
                },
                new Category()
                {
                    CategoryID = 5,
                    CategoryName = "Cakes",
                    CategoryPoster = "MainCakes",
                    ImageURL = "Cake.jpg",
                },
                new Category()
                {
                    CategoryID = 6,
                    CategoryName = "Desserts",
                    CategoryPoster = "MainDesserts",
                    ImageURL = "kunafa.png",
                }
            };
        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageURL = category.ImageURL,

                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }

}
