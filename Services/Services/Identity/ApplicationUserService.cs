using Common.Messages.Identity;
using Common.Utils;
using Domain.Identity;
using Domain.Identity.DTOS;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Services.IServices.Identity;

namespace Services.Services.Identity
{
    public class ApplicationUserService(
        UserManager<ApplicationUser> userManager,
        ILogger<ApplicationUserService> logger) : IApplicationUserService
    {
        public async Task<ResponseHelper> AddApplicationUserAsync(ApplicationUserDTO applicationUserDTO)
        {
           ResponseHelper response = new();
            try
            {
                ApplicationUser applicationUser = new()
                {
                    Email = applicationUserDTO.Email,
                    UserName = applicationUserDTO.Email
                };

                var result = await userManager.CreateAsync(applicationUser, applicationUserDTO.Password);

                if (result.Succeeded)
                {
                    response.IsSuccess = true;
                    response.Message = ApplicationUserMessages.SuccessfullyAdded;
                    return response;
                }
                else
                {
                    response.Message = ApplicationUserMessages.ErrorAdded;
                   
                    var duplicateUserError = result.Errors.FirstOrDefault(e => e.Code == "DuplicateUserName");
                    if (duplicateUserError != null)
                    {
                      
                        response.IsSuccess = false;
                        response.Message = ApplicationUserMessages.DuplicateUserNameError;
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {ex.Message}", ex.Message);
                response.Message = ApplicationUserMessages.ErrorAdded;
            }
            return response;
        }
    }
}
