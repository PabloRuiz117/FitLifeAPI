using Domain.Identity;
using Domain.Identity.DTOS;
using Domain.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.IServices.Identity;
using Services.Services.Identity;

namespace BaseWeb.Controllers.Identity
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController(
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager,
        IRoleService roleService
        
        ) :ControllerBase
    {
        private readonly IRoleService _roleService = roleService;

        [HttpGet("getroles")]
        public async Task<IActionResult> GetRoles()
        {

            var result = await _roleService.GetRolesAsync();

            if (!result.IsSuccess)
            {
                return BadRequest("Error al obtener los roles.");
            }

            return Ok(result.Data);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRole([FromBody] RoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.AddRoleAsync(roleDTO);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPut("updaterole")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.UpdateRoleAsync(roleViewModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("deleterole/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var result = await _roleService.DeleteRoleAsync(roleId);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }


    }
}
