using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

   
using FoodOrderingApp.Model;
using System.Security.Cryptography;
using Firebase.Database.Query;

namespace FoodOrderingApp.Services
{
    public class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://app1-910c7-default-rtdb.firebaseio.com/");
        }
        public async Task<bool> IsUserExists(string uname)
        { 
        
            var user =(await client.Child("Users")
                .OnceAsync<user>()).Where(u => u.Object.Username == uname).FirstOrDefault();
            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if(await IsUserExists(uname)== false)
            {
                await client.Child("user")
                    .PostAsync(new user()
                    {
                        Username = uname,
                        Password = passwd
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string passwd) //method to support login
        {

            var user = (await client.Child("Users")
                .OnceAsync<user>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();
            return (user != null);
        }





    }
}
