using IRunesApp.Services;
using IRunesApp.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunesApp.Controllers
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
            return this.View();
        }

        [HttpPost()]
        public HttpResponse Login(LoginInputViewModel input)
        {
            string userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
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
            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Username.Length < 4 || input.Username.Length >10)
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
