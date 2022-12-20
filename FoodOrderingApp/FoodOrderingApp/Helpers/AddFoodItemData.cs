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
  public  class AddFoodItemData
    { 
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }
        public AddFoodItemData()
        {
            client = new FirebaseClient("https://app1-910c7-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductID= 1,
                    CategoryID= 1,
                    ImageUrl="Pizza.png",
                    Name="Burger",
                    Description="Our Best-Selling Burger with crispy Chicken Patty",
                    Rating="4.5",
                    RatingDetails=" (150 ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=150,
                 },

                 new FoodItem()
                {
                    ProductID= 2,
                    CategoryID= 1,
                    ImageUrl="B.jpg",
                    Name="Burger",
                    Description="Our Best-Selling Burger with crispy Chicken Patty",
                    Rating="4.5",
                    RatingDetails=" (150 ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=150,
                 },

                  new FoodItem()
                {
                    ProductID= 3,
                    CategoryID= 2,
                    ImageUrl="B.jpg",
                    Name="Burger",
                    Description="Our Best-Selling Burger with crispy Chicken Patty",
                    Rating="4.5",

                    RatingDetails=" (150 ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=150,
                 },

                   new FoodItem()
                {
                    ProductID= 6,
                    CategoryID= 2,
                    ImageUrl="B.jpg",
                    Name="Burger",
                    Description="Our Best-Selling Burger with crispy Chicken Patty",
                    Rating="4.5",
                    RatingDetails=" (150 ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=150,
                 },

                    new FoodItem()
                {
                    ProductID= 7,
                    CategoryID= 3,
                    ImageUrl="B.jpg",
                    Name="Burger",
                    Description="Our Best-Selling Burger with crispy Chicken Patty",
                    Rating="4.5",
                    RatingDetails="(150 ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=150,
                 },

                     new FoodItem()
                {
                    ProductID= 8,
                    CategoryID= 3,
                    ImageUrl="B.jpg",
                    Name="Burger",
                    Description="Our Best-Selling Burger with crispy Chicken Patty",
                    Rating="4.5",
                    RatingDetails="(150 ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=150,
                 }
            };
        }
        public async Task  AddFoodItemAsync()
        {
            try
            {
                foreach(var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetails = item.RatingDetails,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price,
                    });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
           
    }
}
