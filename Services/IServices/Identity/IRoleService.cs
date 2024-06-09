using Common.Utils;
using Domain.Identity.DTOS;
using Domain.Identity.ViewModels;

namespace Services.IServices.Identity
{
    public interface IRoleService
    {
        Task<ResponseHelper> GetRolesAsync();
        Task<ResponseHelper> AddRoleAsync(RoleDTO roleDTO);
        Task<ResponseHelper> DeleteRoleAsync(string roleId);
        Task<ResponseHelper> UpdateRoleAsync(RoleViewModel viewModel);
    }
}
