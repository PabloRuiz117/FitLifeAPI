using Common.Utils;
using Domain.Identity;
using Domain.Identity.DTOS;
using Domain.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.IServices.Identity;

namespace BaseWeb.Controllers.Identity
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IApplicationUserService applicationUserService,
        IJWTService jWTService
        ) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            ApplicationUser user;

            ResponseHelper response = new();

            user = await userManager.FindByEmailAsync(model.Email);

            if (user is not null)
            {
                if (!user.IsDeleted)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                    if (!result.Succeeded) return BadRequest();

                    string jwt = jWTService.GenerateToken(user);

                    LoginResponse loginResponse = new()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Token = jwt
                    };

                    response.IsSuccess = true;

                    response.Data = loginResponse;

                    return Ok(response);
                }

                response.Message = "El usuario se encuentra eliminado.";
                return BadRequest(response);
            }

            response.Message = "El email o contraseña no es valido.";

            return BadRequest(response);
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
