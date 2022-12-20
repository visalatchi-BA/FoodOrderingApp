using Android.Preferences;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.Text;

using FoodOrderingApp.Model;
using FoodOrderingApp.Services;
using Xamarin.Forms;
using Android.Views.Accessibility;
using System.Threading.Tasks;
using FoodOrderingApp.Views;

namespace FoodOrderingApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnpropertChanged();
            }
            get
            {
                return this._Username;
            }
        }
        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            set
            {
                this._UserCartItemsCount = value;
                OnpropertChanged();
            }
            get
            {
                return this._UserCartItemsCount;
            }
        }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatesItems { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public ProductsViewModel()
        {
            var uname = Preferences.Get("Username", string.Empty);
            if (string.IsNullOrEmpty(uname))
                Username = "Guest";
            else
                Username = uname;
            UserCartItemsCount = new CartItemService().GetUserCartCount();

            Categories = new ObservableCollection<Category>();
            LatesItems = new ObservableCollection<FoodItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());

            GetCategories();
            GetLatestItems();

           
        }

        private  async Task  ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());

        }

        private async Task  LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());

        }
        private  async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }

        }
        private  async void GetLatestItems()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatesItems.Clear();
            foreach (var item in data)
            {
                LatesItems.Add(item);
            }

        }


        }
    }

