using BLL;
using BLL.Abstractions;
using Core;
using Core.Options;
using Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace PseudoForum.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly Hasher _hasher;
        private readonly AuthentificationOptions _authOptions;

        [BindProperty]
        public User NewUser { get; set; }

        public RegisterModel(Hasher hasher, IUserService userService, IOptions<AuthentificationOptions> authOptions)
        {
            _hasher = hasher;
            _userService = userService;
            _authOptions = authOptions.Value ?? throw new ArgumentNullException(nameof(authOptions));
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string oldPass = NewUser.Password;

            NewUser.Password = _hasher.HashStringSha(NewUser.Password);

            if (await _userService.RegisterNewUser(NewUser))
            {
                User user = await _userService.IsItRightCredentials(new UserViewModel() { Login = NewUser.Email, Password = NewUser.Password});

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("Id", user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.Username));

                ClaimsIdentity identity = new ClaimsIdentity(claims, _authOptions.AuthScheme);

                await HttpContext.SignInAsync(_authOptions.AuthScheme, new ClaimsPrincipal(identity));

                return Redirect("~/Index");
            }

            NewUser.Password = oldPass;

            return Page();
        }
    }
}
