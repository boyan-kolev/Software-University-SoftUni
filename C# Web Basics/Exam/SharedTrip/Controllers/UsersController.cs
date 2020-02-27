using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginIputViewModel input)
        {
            string userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }


            return this.Redirect("/Users/Login");

        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputViewModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Username) || string.IsNullOrEmpty(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(input.Password) || string.IsNullOrEmpty(input.Password))
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsEmailExist(input.Email)
                || this.usersService.IsUsernameExist(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
