using Common.Utils;
using Domain.Identity.DTOS;

namespace Services.IServices.Identity
{
    public interface IApplicationUserService
    {
        Task<ResponseHelper> AddApplicationUserAsync(ApplicationUserDTO applicationUserDTO);
    }
}
