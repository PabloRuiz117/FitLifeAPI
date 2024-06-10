using Domain.Identity;
using Domain.Identity.DTOS;
using Domain.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.IServices.Identity;

namespace BaseWeb.Controllers.Identity
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IApplicationUserService applicationUserService
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

                    return Ok(user);
                }
                return BadRequest("El usuario se encuentra eliminado.");
            }

            return BadRequest("El email o contraseña no es valido.");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserDTO applicationUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await applicationUserService.AddApplicationUserAsync(applicationUserDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
