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
    public class LoginModel : PageModel
    {
        private readonly Hasher _hasher;
        private readonly IUserService _userService;
        private readonly AuthentificationOptions _authOptions;

        [BindProperty]
        public UserViewModel LogedUser { get; set; }

        public LoginModel(Hasher hasher, IUserService userService, IOptions<AuthentificationOptions> authOptions)
        {
            _hasher = hasher;
            _userService = userService;
            _authOptions = authOptions.Value ?? throw new ArgumentNullException(nameof(authOptions));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string oldPassword = LogedUser.Password;

            LogedUser.Password = _hasher.HashStringSha(LogedUser.Password);

            User user = await _userService.IsItRightCredentials(LogedUser);

            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("Id", user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.Username));

                ClaimsIdentity identity = new ClaimsIdentity(claims, _authOptions.AuthScheme);

                await HttpContext.SignInAsync(_authOptions.AuthScheme, new ClaimsPrincipal(identity));

                return Redirect("~/Index");
            }

            LogedUser.Password = oldPassword;

            return Page();
        }
    }
}
