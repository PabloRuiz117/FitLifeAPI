using Common.Messages.Identity;
using Common.Utils;
using Domain.Identity;
using Domain.Identity.DTOS;
using Domain.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.IServices.Identity;

namespace Services.Services.Identity
{
    public class RoleService(
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager,
        ILogger<RoleService> logger) : IRoleService
    {
        public async Task<ResponseHelper> AddRoleAsync(RoleDTO roleDTO)
        {
            ResponseHelper response = new();
            try
            {
                var roleExists = await roleManager.RoleExistsAsync(roleDTO.Name);

                if (roleExists)
                {
                    response.Message = RoleMessages.ExistingRole;
                    return response;
                }

                ApplicationRole applicationRole = new()
                {
                    Name = roleDTO.Name.ToLower(),
                    RowVersion = DateTime.Now,
                };

                var result = await roleManager.CreateAsync(applicationRole);

                if (result.Succeeded)
                {
                    response.IsSuccess = true;
                    response.Message = RoleMessages.SuccessfullyAdded;
                    return response;
                }
                else
                {
                    response.Message = RoleMessages.ErrorAdded;
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {ex.Message}", ex.Message);
                response.Message = RoleMessages.ErrorAdded;
            }

            return response;
        }

        public async Task<ResponseHelper> GetRolesAsync()
        {
            ResponseHelper response = new();
            try
            {
                var roles = await roleManager.Roles.ToListAsync();

                if (roles.Count > 0)
                {
                    List<RoleViewModel> rolesViewModel = [];

                    foreach (var role in roles)
                    {
                        rolesViewModel.Add(new RoleViewModel()
                        {
                            Id = role.Id,
                            Name = role.Name,
                        });
                    }

                    response.IsSuccess = true;
                    response.Data = rolesViewModel;
                    return response;
                }

                response.Message = RoleMessages.EmptyRoles;
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {ex.Message}", ex.Message);
                response.Message = RoleMessages.ErrorGetRoles;
            }

            return response;
        }

        public async Task<ResponseHelper> DeleteRoleAsync(string roleId)
        {
            ResponseHelper response = new();
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);

                if (role is null)
                {
                    response.Message = RoleMessages.RoleNotFound;
                    return response;
                }

                var isEnrolled = await userManager.GetUsersInRoleAsync(role.Name);

                if (isEnrolled.Count > 0)
                {
                    response.Message = RoleMessages.RoleIsEnrolled;
                    return response;
                }

                var result = await roleManager.DeleteAsync(role);

                if (!result.Succeeded)
                {
                    response.Message = RoleMessages.ErrorDeleted;
                    return response;
                }

                response.IsSuccess = true;
                response.Message = RoleMessages.SuccessfullyDeleted;
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {ex.Message}", ex.Message);
                response.Message = RoleMessages.ErrorDeleted;
            }

            return response;
        }

        public async Task<ResponseHelper> UpdateRoleAsync(RoleViewModel viewModel)
        {
            ResponseHelper response = new();
            try
            {
                var roleExists = await roleManager.RoleExistsAsync(viewModel.Name);

                if (roleExists)
                {
                    response.Message = RoleMessages.ExistingRole;
                    return response;
                }

                var role = await roleManager.FindByIdAsync(viewModel.Id);

                if (role is null)
                {
                    response.Message = RoleMessages.ErrorUpdated;
                    return response;
                }

                role.RowVersion = DateTime.Now;
                role.Name = viewModel.Name.ToLower();

                var result = await roleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    response.Message = RoleMessages.ErrorUpdated;
                    return response;
                }

                response.IsSuccess = true;
                response.Message = RoleMessages.SuccessfullyUpdated;
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {ex.Message}", ex.Message);
                response.Message = RoleMessages.ErrorUpdated;
            }
            return response;
        }
    }
}
