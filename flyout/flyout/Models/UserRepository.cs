using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace flyout.Models
{
    public class UserRepository
    {
        static string webAPIKey = "AIzaSyCNkM5CD92xsPhcRtgKyskopNYlE7SOWUo";
        FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        public async Task<bool> Register(string email, string password, string name)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                await authProvider.SendEmailVerificationAsync(token.FirebaseToken);
                return true;
            }
            return false;
        }
        public async Task<string> SignIn(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            var content = await token.LinkToAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                if (content.User.IsEmailVerified == false)
                {
                    var action = await App.Current.MainPage.DisplayAlert("Alear", "Vui lòng xác thực email", "Yes", "No");
                    if (action)
                    {
                        await authProvider.SendEmailVerificationAsync(token.FirebaseToken);
                    }
                }
                else
                    return token.FirebaseToken;
            }
            return "";
        }
        public async Task<bool> Reset(string email)
        {
            await authProvider.SendPasswordResetEmailAsync(email);
            return true;
        }
        public async Task<EmailUser> GetUser(string email,string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            EmailUser user = new EmailUser() { Email = token.User.Email, ID = token.User.LocalId, Name = token.User.DisplayName };
            return user;
        }
    }
}
