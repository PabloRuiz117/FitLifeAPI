using Domain.Identity;
using Domain.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseWeb.Controllers.Identity
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager
        ) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            ApplicationUser user;

            user = await userManager.FindByEmailAsync(model.Email);

            if (user is not null)
            {
                if (!user.IsDeleted)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                    if (!result.Succeeded) return BadRequest();
                }
                return BadRequest("El usuario se encuentra eliminado.");
            }

            return BadRequest("El email o contraseña no es valido.");
        }
    }
}
