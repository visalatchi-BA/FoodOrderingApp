using FoodOrderingApp.Services;
using FoodOrderingApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Firebase.Database.Query;

namespace FoodOrderingApp.ViewModels
{
    public class LoginViewModel : BaseViewModel //inherits baseview model

    {
        //properites required for login view
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

        private string _Password;
        public string Password
        {
            set
            {
               this._Password = value;
                OnpropertChanged();


            }
            get
            {
                return this._Password;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
               this._IsBusy = value;
                OnpropertChanged();


            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnpropertChanged();


            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () =>  await RegisterCommandAsync());
        }





        private async Task RegisterCommandAsync()
        {

            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username,Password);
                if (Result)
                
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "Ok");
                
                else
                
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists with this Credentials", "Ok");
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try 
            { 


            IsBusy = true;
            var userService = new UserService();
            Result = await userService.LoginUser(Username, Password);
            if (Result)
            {

                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");


                }



            else
            {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());



                  

            }

        }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

       

    }
}


